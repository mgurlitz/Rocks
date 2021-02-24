﻿using NUnit.Framework;
using System.Collections.Generic;

namespace Rocks.IntegrationTests
{
	public class ClassGenericIndexer<T>
	{
		public virtual List<string>? this[int a] => default;
		public virtual int this[int a, T b] => default;
		public virtual T? this[string a] => default;
	}

	public static class ClassGenericIndexerTests
	{
		[Test]
		public static void CreateUsingGenericType()
		{
			var returnValue = new List<string>();
			var rock = Rock.Create<ClassGenericIndexer<int>>();
			rock.Indexers().Getters().This(4).Returns(returnValue);

			var chunk = rock.Instance();
			var value = chunk[4];

			rock.Verify();

			Assert.That(value, Is.SameAs(returnValue));
		}

		[Test]
		public static void MakeUsingGenericType()
		{
			var chunk = Rock.Make<ClassGenericIndexer<int>>().Instance();
			var value = chunk[4];

			Assert.That(value, Is.EqualTo(default(List<string>)));
		}

		[Test]
		public static void CreateUsingGenericTypeParameter()
		{
			var returnValue = 3;
			var rock = Rock.Create<ClassGenericIndexer<int>>();
			rock.Indexers().Getters().This(4, 5).Returns(returnValue);

			var chunk = rock.Instance();
			var value = chunk[4, 5];

			rock.Verify();

			Assert.That(value, Is.EqualTo(returnValue));
		}

		[Test]
		public static void MakeUsingGenericTypeParameter()
		{
			var chunk = Rock.Make<ClassGenericIndexer<int>>().Instance();
			var value = chunk[4, 5];

			Assert.That(value, Is.EqualTo(default(int)));
		}

		[Test]
		public static void CreateUsingGenericTypeParameterAsReturn()
		{
			var returnValue = 3;
			var rock = Rock.Create<ClassGenericIndexer<int>>();
			rock.Indexers().Getters().This("b").Returns(returnValue);

			var chunk = rock.Instance();
			var value = chunk["b"];

			rock.Verify();

			Assert.That(value, Is.EqualTo(returnValue));
		}

		[Test]
		public static void MakeUsingGenericTypeParameterAsReturn()
		{
			var chunk = Rock.Make<ClassGenericIndexer<int>>().Instance();
			var value = chunk["b"];

			Assert.That(value, Is.EqualTo(default(int)));
		}
	}
}