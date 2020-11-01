﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Rocks.Builders;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;

namespace Rocks
{
	internal sealed class RockCreateBuilder
	{
		private readonly MockInformation information;

		internal RockCreateBuilder(MockInformation information)
		{
			this.information = information;
			(this.Diagnostics, this.Name, this.Text) = this.Build();
		}

		private (ImmutableArray<Diagnostic>, string, SourceText) Build()
		{
			var usings = new SortedSet<string>
			{
				"using Rocks;",
				"using System.Collections.Generic;",
				"using System.Collections.Immutable;"
			};

			if(!this.information.TypeToMock.ContainingNamespace?.IsGlobalNamespace ?? false)
			{
				usings.Add($"using {this.information.TypeToMock.ContainingNamespace!.ToDisplayString()};");
			}

			using var writer = new StringWriter();
			// TODO:
			// Can we read .editorconfig to figure out the space/tab + indention
			using var indentWriter = new IndentedTextWriter(writer, "	");
			var memberIdentifier = 0u;
			ExtensionsBuilder.Build(indentWriter, this.information, usings, ref memberIdentifier);

			var code = string.Join(Environment.NewLine,
				string.Join(Environment.NewLine, usings), string.Empty, writer.ToString());

			var text = SourceText.From(code, Encoding.UTF8);
			return (this.information.Diagnostics, $"{this.information.TypeToMock.Name}_Mock.g.cs", text);
		}

		public ImmutableArray<Diagnostic> Diagnostics { get; private set; }
		public string Name { get; private set; }
		public SourceText Text { get; private set; }
	}
}