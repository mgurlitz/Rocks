﻿using Microsoft.CodeAnalysis;
using Rocks.Builders.Shim;
using Rocks.Models;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Rocks.Builders.Create;

internal static class MockTypeBuilder
{
	internal static void Build(IndentedTextWriter writer, TypeMockModel type, string expectationsFullyQualifiedName)
	{
		var kind = type.Type.IsRecord ? "record" : "class";

		if (type.Type.AttributesDescription.Length > 0)
		{
			writer.WriteLine(type.Type.AttributesDescription);
		}

		writer.WriteLine($"private sealed {kind} Mock");
		writer.Indent++;

		var canRaiseEvents = type.Events.Length > 0;

		writer.WriteLine($": {type.Type.FullyQualifiedName}{(canRaiseEvents ? $", global::Rocks.IRaiseEvents" : string.Empty)}");
		writer.Indent--;

		writer.WriteLine("{");
		writer.Indent++;

		MockTypeBuilder.BuildShimFields(writer, type);
		MockTypeBuilder.BuildRefReturnFields(writer, type);

		if (type.Constructors.Length > 0)
		{
			foreach (var constructor in type.Constructors)
			{
				MockConstructorBuilder.Build(writer, type, constructor.Parameters, type.Shims, expectationsFullyQualifiedName);
			}
		}
		else
		{
			MockConstructorBuilder.Build(writer, type, ImmutableArray<ParameterModel>.Empty, type.Shims, expectationsFullyQualifiedName);
		}

		writer.WriteLine();

		foreach (var method in type.Methods)
		{
			if (method.ReturnsVoid)
			{
				MockMethodVoidBuilder.Build(writer, method, canRaiseEvents, expectationsFullyQualifiedName);
			}
			else
			{
				MockMethodValueBuilder.Build(writer, method, canRaiseEvents, expectationsFullyQualifiedName);
			}
		}

		var hasProperties = false;

		foreach (var property in type.Properties.Where(_ => !_.IsIndexer))
		{
			hasProperties = true;
			MockPropertyBuilder.Build(writer, property, canRaiseEvents);
		}

		if (hasProperties)
		{
			writer.WriteLine();
		}

		var hasIndexers = false;

		foreach (var indexer in type.Properties.Where(_ => _.IsIndexer))
		{
			hasIndexers = true;
			MockIndexerBuilder.Build(writer, indexer, canRaiseEvents);
		}

		if (hasIndexers)
		{
			writer.WriteLine();
		}

		if (canRaiseEvents)
		{
			MockEventsBuilder.Build(writer, type.Events);
			writer.WriteLine();
		}

		MockTypeBuilder.BuildShimTypes(writer, type);

		writer.WriteLine($"private {expectationsFullyQualifiedName} Expectations {{ get; }}");

		writer.Indent--;
		writer.WriteLine("}");
	}

	private static void BuildShimTypes(IndentedTextWriter writer, TypeMockModel type)
	{
		foreach (var shimType in type.Shims)
		{
			writer.WriteLine();
			ShimBuilder.Build(writer, shimType);
		}
	}

	private static void BuildShimFields(IndentedTextWriter writer, TypeMockModel type)
	{
		foreach (var shimType in type.Shims)
		{
			writer.WriteLine($"private readonly {shimType.Type.FullyQualifiedName} shimFor{shimType.Type.FlattenedName};");
		}
	}

	private static void BuildRefReturnFields(IndentedTextWriter writer, TypeMockModel type)
	{
		foreach (var method in type.Methods.Where(_ => _.ReturnsByRef || _.ReturnsByRefReadOnly))
		{
			writer.WriteLine($"private {method.ReturnType.FullyQualifiedName} rr{method.MemberIdentifier};");
		}

		foreach (var property in type.Properties.Where(_ => _.ReturnsByRef || _.ReturnsByRefReadOnly))
		{
			writer.WriteLine($"private {property.Type.FullyQualifiedName} rr{property.MemberIdentifier};");
		}
	}
}