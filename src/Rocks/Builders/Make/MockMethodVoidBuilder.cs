﻿using Microsoft.CodeAnalysis;
using Rocks.Builders.Create;
using Rocks.Models;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Rocks.Builders.Make;

internal static class MockMethodVoidBuilder
{
	internal static void Build(IndentedTextWriter writer, MethodModel method)
	{
		var shouldThrowDoesNotReturnException = method.IsMarkedWithDoesNotReturn;
		var typeArgumentsNamingContext = method.IsGenericMethod ?
			new TypeArgumentsNamingContext(method.MockType) :
			new TypeArgumentsNamingContext();

		var explicitTypeNameDescription = method.RequiresExplicitInterfaceImplementation == RequiresExplicitInterfaceImplementation.Yes ?
			$"{method.ContainingType.FullyQualifiedName}." : string.Empty;

		var methodParameters = string.Join(", ", method.Parameters.Select(_ =>
		{
			var requiresNullable = _.RequiresNullableAnnotation ? "?" : string.Empty;
			var defaultValue = _.HasExplicitDefaultValue && method.RequiresExplicitInterfaceImplementation == RequiresExplicitInterfaceImplementation.No ? 
				$" = {_.ExplicitDefaultValue}" : string.Empty;
			var scoped = _.IsScoped ? "scoped " : string.Empty;
			var direction = _.RefKind switch
			{
				RefKind.Ref => "ref ",
				RefKind.Out => "out ",
				RefKind.In => "in ",
				RefKind.RefReadOnlyParameter => "ref readonly ",
				_ => string.Empty
			};
			var typeName = method.IsGenericMethod && method.TypeArguments.Any(m => m.FullyQualifiedName == _.Type.FullyQualifiedName) ?
				_.Type.BuildName(typeArgumentsNamingContext) : _.Type.FullyQualifiedName;
			var parameter = $"{scoped}{direction}{(_.IsParams ? "params " : string.Empty)}{typeName}{requiresNullable} @{_.Name}{defaultValue}";
			var attributes = _.AttributesDescription;
			return $"{(attributes.Length > 0 ? $"{attributes} " : string.Empty)}{parameter}";
		}));

		var typeArguments = method.IsGenericMethod ?
			$"<{string.Join(", ", method.TypeArguments.Select(_ => !method.MockType.TypeArguments.Contains(_) ? _.FullyQualifiedName : _.BuildName(typeArgumentsNamingContext)))}>" : string.Empty;
		var methodSignature = $"void {explicitTypeNameDescription}{method.Name}{typeArguments}({methodParameters})";

		if (method.AttributesDescription.Length > 0)
		{
			writer.WriteLine(method.AttributesDescription);
		}

		var isUnsafe = method.IsUnsafe ? "unsafe " : string.Empty;
		var isPublic = method.RequiresExplicitInterfaceImplementation == RequiresExplicitInterfaceImplementation.No ?
			$"{method.OverridingCodeValue} " : string.Empty;
		writer.WriteLine($"{isPublic}{isUnsafe}{(method.RequiresOverride == RequiresOverride.Yes ? "override " : string.Empty)}{methodSignature}");

		var constraints = new List<Constraints>();

		if (method.RequiresExplicitInterfaceImplementation == RequiresExplicitInterfaceImplementation.No &&
			method.ContainingType.TypeKind == TypeKind.Interface)
		{
			constraints.AddRange(method.Constraints);
		}

		if (method.RequiresExplicitInterfaceImplementation == RequiresExplicitInterfaceImplementation.Yes ||
			method.RequiresOverride == RequiresOverride.Yes)
		{
			constraints.AddRange(method.DefaultConstraints);
		}

		if (constraints.Count > 0)
		{
			writer.Indent++;

			foreach (var constraint in constraints)
			{
				writer.WriteLine(constraint.ToString(typeArgumentsNamingContext, method));
			}

			writer.Indent--;
		}

		writer.WriteLine("{");
		writer.Indent++;

		foreach (var outParameter in method.Parameters.Where(_ => _.RefKind == RefKind.Out))
		{
			writer.WriteLine($"{outParameter.Name} = default!;");
		}

		if (shouldThrowDoesNotReturnException)
		{
			writer.WriteLine("throw new global::Rocks.Exceptions.DoesNotReturnException();");
		}

		writer.Indent--;
		writer.WriteLine("}");
	}
}