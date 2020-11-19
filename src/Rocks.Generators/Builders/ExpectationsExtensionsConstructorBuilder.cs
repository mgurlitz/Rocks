﻿using Microsoft.CodeAnalysis;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Linq;

namespace Rocks.Builders
{
	internal static class ExpectationsExtensionsConstructorBuilder
	{
		internal static void Build(IndentedTextWriter writer, ITypeSymbol typeToMock,
			ImmutableArray<IParameterSymbol> parameters)
		{
			var instanceParameters = parameters.Length == 0 ?
				$"this Expectations<{typeToMock.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)}> self" :
				string.Join(", ", $"this Expectations<{typeToMock.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)}> self",
					string.Join(", ", parameters.Select(_ => $"{_.Type.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)} {_.Name}")));
			var rockInstanceParameters = parameters.Length == 0 ? "self" :
				string.Join(", ", "self", string.Join(", ", parameters.Select(_ => $"{_.Name}")));

			writer.WriteLine($"internal static {typeToMock.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)} Instance({instanceParameters})");
			writer.WriteLine("{");
			writer.Indent++;

			writer.WriteLine($"var mock = new Rock{typeToMock.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)}({rockInstanceParameters});");
			writer.WriteLine("self.Mocks.Add(mock);");
			writer.WriteLine("return mock;");

			writer.Indent--;
			writer.WriteLine("}");
		}
	}
}