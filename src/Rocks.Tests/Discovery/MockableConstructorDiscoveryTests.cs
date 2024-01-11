﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using Rocks.Discovery;

namespace Rocks.Tests.Discovery;

public static class MockableConstructorDiscoveryTests
{
	[Test]
	public static void GetMockableConstructorsForClass()
	{
		var code =
			"""
			public class Target 
			{
				public Target() { }
			}
			""";
		var (typeSymbol, obsoleteAttribute) = GetTypeSymbol(code);
		var constructors = new MockableConstructorDiscovery(typeSymbol, typeSymbol.ContainingAssembly, obsoleteAttribute).Constructors;

		Assert.That(constructors, Has.Length.EqualTo(1));
	}

	[Test]
	public static void GetMockableConstructorsForClassWhereConstructorCannotBeSeenByInvocationAssembly()
	{
		var code =
			"""
			public class Target 
			{
				internal Target() { }
			}
			""";
		var (typeSymbol, obsoleteAttribute) = GetTypeSymbol(code);

		var containingSyntaxTree = CSharpSyntaxTree.ParseText("public class Containing { }");
		var containingCompilation = CSharpCompilation.Create("InvocationAssembly", new SyntaxTree[] { containingSyntaxTree },
			Shared.References.Value, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

		var constructors = new MockableConstructorDiscovery(typeSymbol, containingCompilation.Assembly, obsoleteAttribute).Constructors;

		Assert.That(constructors, Has.Length.EqualTo(0));
	}

	[Test]
	public static void GetMockableConstructorsForInterface()
	{
		var code = "public interface Target { }";
		var (typeSymbol, obsoleteAttribute) = GetTypeSymbol(code);
		var constructors = new MockableConstructorDiscovery(typeSymbol, typeSymbol.ContainingAssembly, obsoleteAttribute).Constructors;

		Assert.That(constructors, Has.Length.EqualTo(0));
	}

	private static (ITypeSymbol type, INamedTypeSymbol obsoleteAttribute) GetTypeSymbol(string source)
	{
		var syntaxTree = CSharpSyntaxTree.ParseText(source);
		var compilation = CSharpCompilation.Create("generator", new SyntaxTree[] { syntaxTree },
			Shared.References.Value, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
		var model = compilation.GetSemanticModel(syntaxTree, true);

		var typeSyntax = syntaxTree.GetRoot().DescendantNodes(_ => true)
			.OfType<TypeDeclarationSyntax>().Single();
		var obsoleteAttribute = model.Compilation.GetTypeByMetadataName(typeof(ObsoleteAttribute).FullName!)!;
		return (model.GetDeclaredSymbol(typeSyntax)!, obsoleteAttribute);
	}
}