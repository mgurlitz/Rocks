﻿using Microsoft.CodeAnalysis;
using Rocks.Models;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Rocks.Builders.Create;

internal static class MockProjectedArgTypeBuilderV4
{
	internal static void Build(IndentedTextWriter writer, TypeMockModel type)
	{
		foreach (var esotericType in GetEsotericTypes(type))
		{
			ProjectedArgTypeBuilderV4.Build(writer, esotericType, type);
		}
	}

	private static HashSet<TypeReferenceModel> GetEsotericTypes(TypeMockModel type)
	{
		static void GetEsotericTypes(ImmutableArray<ParameterModel> parameters, HashSet<TypeReferenceModel> types)
		{
			foreach (var parameter in parameters)
			{
				if (parameter.Type.IsRefLikeType || parameter.Type.TypeKind == TypeKind.FunctionPointer)
				{
					types.Add(parameter.Type);
				}
			}
		}

		var types = new HashSet<TypeReferenceModel>();

		foreach (var method in type.Methods)
		{
			GetEsotericTypes(method.Parameters, types);
		}

		foreach (var property in type.Properties)
		{
			if (property.IsIndexer)
			{
				GetEsotericTypes(property.Parameters, types);
			}

			if (property.Type.IsRefLikeType || property.Type.TypeKind == TypeKind.FunctionPointer)
			{
				types.Add(property.Type);
			}
		}

		return types;
	}
}