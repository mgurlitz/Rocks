﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using Rocks.Extensions;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Rocks.Tests.Extensions
{
	[AttributeUsage(AttributeTargets.All)]
	public sealed class MyTestAttribute
		: Attribute
	{
		public MyTestAttribute(string a, double b, int c, uint d, Type e) =>
			(this.A, this.B, this.C, this.D, this.E) =
				(a, b, c, d, e);

		public string A { get; }
		public double B { get; }
		public int C { get; }
		public uint D { get; }
		public Type E { get; }
	}

	public static class AttributeDataExtensionsTests
	{
		[Test]
		public static void GetDescription()
		{
			var attributes = AttributeDataExtensionsTests.GetAttributes(
@"using Rocks.Tests.Extensions;
using System;

public interface IA
{
	[MyTest(""a value"", 12.34, 22, 44, typeof(Guid)]
	void Foo();
}");

			Assert.Multiple(() =>
			{
				Assert.That(attributes[0].GetDescription(), Is.EqualTo(@"MyTest(""a value"", 12.34, 22, 44, typeof(Guid))"));
			});
		}

		[Test]
		public static void GetDescriptionForArray()
		{
			var attributes = AttributeDataExtensionsTests.GetAttributes(
@"using Rocks.Tests.Extensions;
using System;

public interface IA
{
	[MyTest(""a value"", 12.34, 22, 44, typeof(Guid)]
	[MyTest(""b value"", 22.34, 33, 55, typeof(string)]
	void Foo();
}");

			Assert.Multiple(() =>
			{
				Assert.That(attributes.GetDescription(), 
					Is.EqualTo(@"[MyTest(""a value"", 12.34, 22, 44, typeof(Guid)), MyTest(""b value"", 22.34, 33, 55, typeof(string))]"));
			});
		}

		[Test]
		public static void GetDescriptionForArrayWithTarget()
		{
			var attributes = AttributeDataExtensionsTests.GetAttributes(
@"using Rocks.Tests.Extensions;
using System;

public interface IA
{
	[MyTest(""a value"", 12.34, 22, 44, typeof(Guid)]
	[MyTest(""b value"", 22.34, 33, 55, typeof(string)]
	void Foo();
}");

			Assert.Multiple(() =>
			{
				Assert.That(attributes.GetDescription(AttributeTargets.Method), 
					Is.EqualTo(@"[method: MyTest(""a value"", 12.34, 22, 44, typeof(Guid)), MyTest(""b value"", 22.34, 33, 55, typeof(string))]"));
			});
		}

		private static ImmutableArray<AttributeData> GetAttributes(string source)
		{
			var syntaxTree = CSharpSyntaxTree.ParseText(source);
			var references = AppDomain.CurrentDomain.GetAssemblies()
				.Where(_ => !_.IsDynamic && !string.IsNullOrWhiteSpace(_.Location))
				.Select(_ => MetadataReference.CreateFromFile(_.Location));
			var compilation = CSharpCompilation.Create("generator", new SyntaxTree[] { syntaxTree },
				references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
			var model = compilation.GetSemanticModel(syntaxTree, true);

			var methodSyntax = syntaxTree.GetRoot().DescendantNodes(_ => true)
				.OfType<MethodDeclarationSyntax>().Single();
			var methodSymbol = model.GetDeclaredSymbol(methodSyntax)!;

			return methodSymbol.GetAttributes();
		}
	}
}
