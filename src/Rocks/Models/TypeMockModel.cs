﻿using Microsoft.CodeAnalysis;
using Rocks.Discovery;
using Rocks.Extensions;
using System.Collections.Immutable;

namespace Rocks.Models;

internal sealed record TypeMockModel
{
	internal TypeMockModel(
		SyntaxNode node, ITypeSymbol type, Compilation compilation, SemanticModel model,
		ImmutableArray<IMethodSymbol> constructors, MockableMethods methods,
		MockableProperties properties, MockableEvents events,
		HashSet<ITypeSymbol> shims, TypeMockModelMemberCount memberCount, bool shouldResolveShims, BuildType buildType)
	{
		this.Type = new TypeReferenceModel(type, compilation);
		(this.ExpectationsName, this.ExpectationsNameNoGenerics, this.ExpectationsFullyQualifiedName) = compilation.GetExpectationsName(this.Type, buildType);
		this.MemberCount = memberCount;

		// TODO: Remember to sort all array so "equatable" will work,
		// EXCEPT FOR parameter order (including generic parameters).
		// Those have to stay in the order they exist in the definition.
		this.Aliases = compilation.GetAliases();
		this.Constructors = constructors.Select(_ =>
			new ConstructorModel(_, this.Type, compilation)).ToImmutableArray();
		this.Methods = methods.Results.Select(_ =>
			new MethodModel(_.Value, this.Type, compilation, _.RequiresExplicitInterfaceImplementation,
				_.RequiresOverride, _.RequiresHiding, _.MemberIdentifier)).ToImmutableArray();
		this.Properties = properties.Results.Select(_ =>
			new PropertyModel(_.Value, this.Type, compilation,
				_.RequiresExplicitInterfaceImplementation, _.RequiresOverride,
				_.Accessors, _.MemberIdentifier)).ToImmutableArray();
		this.Events = events.Results.Select(_ =>
			new EventModel(_.Value, this.Type, compilation,
				_.RequiresExplicitInterfaceImplementation, _.RequiresOverride)).ToImmutableArray();
		this.Shims = shouldResolveShims ?
			shims.Select(_ =>
				MockModel.Create(node, _, model, BuildType.Create, false).Information!.Type).ToImmutableArray() :
			ImmutableArray<TypeMockModel>.Empty;

		this.ConstructorProperties = type.GetMembers().OfType<IPropertySymbol>()
			.Where(_ => (_.IsRequired || _.GetAccessors() == PropertyAccessor.Init || _.GetAccessors() == PropertyAccessor.GetAndInit) &&
				_.CanBeSeenByContainingAssembly(compilation.Assembly))
			.Select(_ => new ConstructorPropertyModel(_, this.Type, compilation))
			.ToImmutableArray();

		this.ExpectationsPropertyName = this.GetExpectationsPropertyName();
	}

	private string GetExpectationsPropertyName()
	{
		const string ExpectationsName = "Expectations";

		var memberNames = new HashSet<string>(
			this.Methods.Select(_ => _.Name).Concat(this.Properties.Select(_ => _.Name)));

		var expectationsPropertyName = ExpectationsName;
		var index = 2;

		while (memberNames.Contains(expectationsPropertyName)) 
		{
			expectationsPropertyName = $"{ExpectationsName}{index++}";
		}

		return expectationsPropertyName;
	}

	internal EquatableArray<string> Aliases { get; }
	internal EquatableArray<ConstructorPropertyModel> ConstructorProperties { get; }
	internal EquatableArray<ConstructorModel> Constructors { get; }
	internal string ExpectationsFullyQualifiedName { get; }
	internal string ExpectationsName { get; }
	internal string ExpectationsNameNoGenerics { get; }
	internal string ExpectationsPropertyName { get; }
	internal EquatableArray<EventModel> Events { get; }
	internal TypeMockModelMemberCount MemberCount { get; }
	internal EquatableArray<MethodModel> Methods { get; }
	internal EquatableArray<PropertyModel> Properties { get; }
	internal EquatableArray<TypeMockModel> Shims { get; }
	internal TypeReferenceModel Type { get; }
}