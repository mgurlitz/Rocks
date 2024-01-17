﻿using Microsoft.CodeAnalysis;
using Rocks.Builders.Create;
using Rocks.Builders.Make;
using Rocks.Extensions;
using Rocks.Models;
using System.Collections.Immutable;

namespace Rocks;

[Generator]
internal sealed class RockAttributeGenerator
	: IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		static IncrementalValuesProvider<MockModelInformation> GetInformation(
			IncrementalGeneratorInitializationContext context, string attributeName, BuildType buildType) => 
			context.SyntaxProvider
				.ForAttributeWithMetadataName(attributeName, (_, _) => true,
					(context, token) =>
					{
						var models = new List<MockModelInformation>(context.Attributes.Length);

						for (var i = 0; i < context.Attributes.Length; i++)
						{
							// Need to grab the type attribute value.
							// Note that I'm assuming there will be at least one generic parameter.
							// If someone creates an attribute to mess with this...
							// well, I guess I could an add a diagnostic that informs users
							// that the attribute was invalid.
							var attributeClass = context.Attributes[i];
							var typeToMock = attributeClass.AttributeClass!.TypeArguments[0];

							if (!typeToMock.ContainsDiagnostics())
							{
								var model = MockModel.Create(attributeClass.ApplicationSyntaxReference!.GetSyntax(token),
								  typeToMock, context.SemanticModel, buildType, true);

								if (model.Information is not null)
								{
									models.Add(model.Information);
								}
							}
						}

						return models;
					})
				.SelectMany((names, _) => names);

		var mockCreateTypes = GetInformation(context, "Rocks.RockCreateAttribute`1", BuildType.Create);
		var mockMakeTypes = GetInformation(context, "Rocks.RockMakeAttribute`1", BuildType.Make);  

		context.RegisterSourceOutput(mockCreateTypes.Collect(),
			(context, source) => RockAttributeGenerator.CreateOutput(source, context));
		context.RegisterSourceOutput(mockMakeTypes.Collect(),
			(context, source) => RockAttributeGenerator.CreateOutput(source, context));
	}

	private static void CreateOutput(ImmutableArray<MockModelInformation> mocks, SourceProductionContext context)
	{
		foreach (var mock in mocks.Distinct())
		{
			if (mock.BuildType == BuildType.Create)
			{
				var builder = new RockCreateBuilder(mock.Type);
				context.AddSource(builder.Name, builder.Text);
			}
			else if (mock.BuildType == BuildType.Make)
			{
				var builder = new RockMakeBuilder(mock.Type);
				context.AddSource(builder.Name, builder.Text);
			}
		}
	}
}