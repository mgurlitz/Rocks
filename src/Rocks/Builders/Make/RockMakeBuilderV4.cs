﻿using Microsoft.CodeAnalysis.Text;
using Rocks.Extensions;
using Rocks.Models;
using System.CodeDom.Compiler;
using System.Text;

namespace Rocks.Builders.Make;

internal sealed class RockMakeBuilderV4
{
	internal RockMakeBuilderV4(TypeMockModel mockType)
	{
		this.MockType = mockType;
		(this.Name, this.Text) = this.Build();
	}

	private (string, SourceText) Build()
	{
		using var writer = new StringWriter();
		using var indentWriter = new IndentedTextWriter(writer, "\t");

		indentWriter.WriteLines(
			"""
			// <auto-generated/>

			#nullable enable

			""");

		if (this.MockType.Aliases.Length > 0)
		{
			var requiredAliases = this.MockType.Aliases
				.Select(_ => $"extern alias {_};").ToArray();
			foreach ( var requiredAlias in requiredAliases) 
			{
				indentWriter.WriteLine(requiredAlias);
			}

			indentWriter.WriteLine();
		}

		var mockNamespace = this.MockType.Type.Namespace;

		if (mockNamespace.Length > 0)
		{
			indentWriter.WriteLine($"namespace {mockNamespace}");
			indentWriter.WriteLine("{");
			indentWriter.Indent++;
		}

		MockExtensionsBuilder.Build(indentWriter, this.MockType);

		if (mockNamespace.Length > 0)
		{
			indentWriter.Indent--;
			indentWriter.WriteLine("}");
		}

		var text = SourceText.From(writer.ToString(), Encoding.UTF8);
		var name = $"{this.MockType.Type.FullyQualifiedName.GenerateFileName()}_Rock_Make.g.cs"; 
		return (name, text);
	}

	public string Name { get; private set; }
	public SourceText Text { get; private set; }
	private TypeMockModel MockType { get; }
}