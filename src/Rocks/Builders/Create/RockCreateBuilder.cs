﻿using Microsoft.CodeAnalysis.Text;
using Rocks.Extensions;
using Rocks.Models;
using System.CodeDom.Compiler;
using System.Text;

namespace Rocks.Builders.Create;

internal sealed class RockCreateBuilder
{
	internal RockCreateBuilder(TypeMockModel mockType)
	{
		this.MockType = mockType;
		(this.Name, this.Text) = this.Build();
	}

	private (string, SourceText) Build()
	{
		using var writer = new StringWriter();
		using var indentWriter = new IndentedTextWriter(writer, "\t");

		var mockNamespace = this.MockType.Type.Namespace;

		if (mockNamespace is not null)
		{
			indentWriter.WriteLine($"namespace {mockNamespace}");
			indentWriter.WriteLine("{");
			indentWriter.Indent++;
		}

		var wereTypesProjected = MockBuilder.Build(indentWriter, this.MockType);

		if (mockNamespace is not null)
		{
			indentWriter.Indent--;
			indentWriter.WriteLine("}");
		}

		var content = new List<string>
		{
			"// <auto-generated/>", string.Empty,
			"#nullable enable", string.Empty,
		};

		if (this.MockType.Aliases.Length > 0)
		{
			var requiredAliases = this.MockType.Aliases
				.Select(_ => $"extern alias {_};").ToArray();
			content.AddRange([string.Join(Environment.NewLine, requiredAliases), string.Empty]);
		}

		content.AddRange(["using Rocks.Extensions;", string.Empty]);

		content.Add(writer.ToString());

		var text = SourceText.From(
			string.Join(Environment.NewLine, content),
			Encoding.UTF8);
		var name = $"{this.MockType.Type.FullyQualifiedName.GenerateFileName()}_Rock_Create.g.cs";
		return (name, text);
	}

	public string Name { get; private set; }
	public SourceText Text { get; private set; }
	private TypeMockModel MockType { get; }
}