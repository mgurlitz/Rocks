﻿using NUnit.Framework;
using Rocks.Exceptions;
using System;
using System.Collections.Generic;

namespace Rocks.IntegrationTests
{
	public class ClassGenericMethod<T>
	{
		public virtual void Foo(List<string> values) { }
		public virtual void Quux(T value) { }
		public virtual void Bar<TParam>(TParam value) { }
		public virtual List<string>? FooReturn() => default;
		public virtual T? QuuxReturn() => default;
		public virtual TReturn BarReturn<TReturn>() => default!;
	}

	public static class ClassGenericMethodTests
	{
		[Test]
		public static void MockUsingGenericType()
		{
			var rock = Rock.Create<ClassGenericMethod<int>>();
			rock.Methods().Foo(Arg.Any<List<string>>());

			var chunk = rock.Instance();
			chunk.Foo(new List<string>());

			rock.Verify();
		}

		[Test]
		public static void MockWithGenericTypeParameter()
		{
			var rock = Rock.Create<ClassGenericMethod<int>>();
			rock.Methods().Quux(Arg.Any<int>());

			var chunk = rock.Instance();
			chunk.Quux(3);

			rock.Verify();
		}

		[Test]
		public static void MockWithGenericParameterType()
		{
			var rock = Rock.Create<ClassGenericMethod<int>>();
			rock.Methods().Bar(Arg.Any<int>());

			var chunk = rock.Instance();
			chunk.Bar(3);

			rock.Verify();
		}

		[Test]
		public static void MockWithGenericParameterTypeThatDoesNotMatch()
		{
			var rock = Rock.Create<ClassGenericMethod<int>>();
			rock.Methods().Bar(Arg.Any<int>());

			var chunk = rock.Instance();

			Assert.Multiple(() =>
			{
				Assert.That(() => chunk.Bar("3"), Throws.TypeOf<ExpectationException>());
			});
		}

		[Test]
		public static void MockUsingGenericTypeAsReturn()
		{
			var returnValue = new List<string>();
			var rock = Rock.Create<ClassGenericMethod<int>>();
			rock.Methods().FooReturn().Returns(returnValue);

			var chunk = rock.Instance();
			var value = chunk.FooReturn();

			rock.Verify();

			Assert.Multiple(() =>
			{
				Assert.That(value, Is.SameAs(returnValue));
			});
		}

		[Test]
		public static void MockWithGenericTypeParameterAsReturn()
		{
			var returnValue = 3;
			var rock = Rock.Create<ClassGenericMethod<int>>();
			rock.Methods().QuuxReturn().Returns(returnValue);

			var chunk = rock.Instance();
			var value = chunk.QuuxReturn();

			rock.Verify();

			Assert.Multiple(() =>
			{
				Assert.That(value, Is.EqualTo(returnValue));
			});
		}

		[Test]
		public static void MockWithGenericParameterTypeAsReturn()
		{
			var returnValue = 3;
			var rock = Rock.Create<ClassGenericMethod<int>>();
			rock.Methods().BarReturn<int>().Returns(returnValue);

			var chunk = rock.Instance();
			var value = chunk.BarReturn<int>();

			rock.Verify();

			Assert.Multiple(() =>
			{
				Assert.That(value, Is.EqualTo(returnValue));
			});
		}

		[Test]
		public static void MockWithGenericParameterTypeAsReturnThatDoesNotMatch()
		{
			var returnValue = 3;
			var rock = Rock.Create<ClassGenericMethod<int>>();
			rock.Methods().BarReturn<int>().Returns(returnValue);

			var chunk = rock.Instance();

			Assert.Multiple(() =>
			{
				Assert.That(() => chunk.BarReturn<string>(), Throws.TypeOf<InvalidCastException>());
			});
		}
	}
}