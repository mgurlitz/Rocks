﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using Rocks.Descriptors;
using Rocks.Diagnostics;
using System.Globalization;

namespace Rocks.Tests.Diagnostics;

public static class TypeHasNoAccessibleConstructorsDiagnosticTests
{
	[Test]
	public static void Create()
	{
		var syntaxTree = CSharpSyntaxTree.ParseText("public class X { }");
		var compilation = CSharpCompilation.Create("generator", new SyntaxTree[] { syntaxTree },
			Shared.References.Value, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
		var model = compilation.GetSemanticModel(syntaxTree, true);

		var typeSyntax = syntaxTree.GetRoot().DescendantNodes(_ => true)
			.OfType<TypeDeclarationSyntax>().Single();

		var invocation = SyntaxFactory.InvocationExpression(SyntaxFactory.ParseExpression("public static void Foo() { }"));

		var descriptor = TypeHasNoAccessibleConstructorsDiagnostic.Create(invocation, model.GetDeclaredSymbol(typeSyntax)!);

		Assert.Multiple(() =>
		{
			Assert.That(descriptor.GetMessage(CultureInfo.InvariantCulture), Is.EqualTo("The type X has no constructors that are accessible"));
			Assert.That(descriptor.Descriptor.Title.ToString(CultureInfo.CurrentCulture), Is.EqualTo(TypeHasNoAccessibleConstructorsDescriptor.Title));
			Assert.That(descriptor.Id, Is.EqualTo(TypeHasNoAccessibleConstructorsDescriptor.Id));
			Assert.That(descriptor.Severity, Is.EqualTo(DiagnosticSeverity.Error));
		});
	}
}