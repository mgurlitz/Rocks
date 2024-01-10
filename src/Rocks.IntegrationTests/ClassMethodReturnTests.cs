﻿using NUnit.Framework;
using Rocks.Exceptions;

namespace Rocks.IntegrationTests;

public class ClassMethodReturn
{
	public virtual int NoParameters() => default;
	public virtual int OneParameter(int a) => default;
	public virtual int MultipleParameters(int a, string b) => default;
}

public static class ClassMethodReturnTests
{
	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithNoParameters()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.NoParameters();

		var mock = expectations.Instance();
		var value = mock.NoParameters();

		expectations.Verify();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockMake<ClassMethodReturn>]
	public static void MakeWithNoParameters()
	{
		var mock = new ClassMethodReturnMakeExpectations().Instance();
		var value = mock.NoParameters();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithNoParametersWithReturn()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.NoParameters().ReturnValue(3);

		var mock = expectations.Instance();
		var value = mock.NoParameters();

		expectations.Verify();

		Assert.That(value, Is.EqualTo(3));
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithNoParametersMultipleCalls()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.NoParameters().ExpectedCallCount(2);

		var mock = expectations.Instance();
		mock.NoParameters();
		mock.NoParameters();

		expectations.Verify();
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithNoParametersMultipleCallsNotMet()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.NoParameters().ExpectedCallCount(2);

		var mock = expectations.Instance();
		mock.NoParameters();

		Assert.That(expectations.Verify, Throws.TypeOf<VerificationException>());
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithNoParametersAndCallback()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.NoParameters().Callback(() => 3);

		var mock = expectations.Instance();
		var value = mock.NoParameters();

		expectations.Verify();

		Assert.That(value, Is.EqualTo(3));
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithNoParametersNoExpectationSet()
	{
		var expectations = new ClassMethodReturnCreateExpectations();

		var mock = expectations.Instance();

		Assert.That(mock.NoParameters, Throws.Nothing);
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithNoParametersExpectationsNotMet()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.NoParameters();

		_ = expectations.Instance();

		Assert.That(expectations.Verify, Throws.TypeOf<VerificationException>());
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithOneParameter()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.OneParameter(3);

		var mock = expectations.Instance();
		var value = mock.OneParameter(3);

		expectations.Verify();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockMake<ClassMethodReturn>]
	public static void MakeWithOneParameter()
	{
		var mock = new ClassMethodReturnMakeExpectations().Instance();
		var value = mock.OneParameter(3);

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithOneParameterWithReturn()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.OneParameter(3).ReturnValue(3);

		var mock = expectations.Instance();
		var value = mock.OneParameter(3);

		expectations.Verify();

		Assert.That(value, Is.EqualTo(3));
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithOneParameterWithCallback()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.OneParameter(3).Callback(_ => 3);

		var mock = expectations.Instance();
		var value = mock.OneParameter(3);

		expectations.Verify();

		Assert.That(value, Is.EqualTo(3));
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithOneParameterArgExpectationNotMet()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.OneParameter(3);

		var mock = expectations.Instance();

		Assert.That(() => mock.OneParameter(1), Throws.TypeOf<ExpectationException>());
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithMultipleParameters()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.MultipleParameters(3, "b");

		var mock = expectations.Instance();
		var value = mock.MultipleParameters(3, "b");

		expectations.Verify();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockMake<ClassMethodReturn>]
	public static void MakeWithMultipleParameters()
	{
		var mock = new ClassMethodReturnMakeExpectations().Instance();
		var value = mock.MultipleParameters(3, "b");

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithMultipleParametersWithReturn()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.MultipleParameters(3, "b").ReturnValue(3);

		var mock = expectations.Instance();
		var value = mock.MultipleParameters(3, "b");

		expectations.Verify();

		Assert.That(value, Is.EqualTo(3));
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithMultipleParametersWithCallback()
	{
		var aValue = 0;
		var bValue = string.Empty;
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.MultipleParameters(3, "b").Callback((a, b) =>
		{
			(aValue, bValue) = (a, b);
			return 3;
		});

		var mock = expectations.Instance();
		var value = mock.MultipleParameters(3, "b");

		expectations.Verify();

		Assert.Multiple(() =>
		{
			Assert.That(aValue, Is.EqualTo(3));
			Assert.That(bValue, Is.EqualTo("b"));
			Assert.That(value, Is.EqualTo(3));
		});
	}

	[Test]
	[RockCreate<ClassMethodReturn>]
	public static void CreateWithMultipleParametersArgExpectationNotMet()
	{
		var expectations = new ClassMethodReturnCreateExpectations();
		expectations.Methods.MultipleParameters(3, "b");

		var mock = expectations.Instance();

		Assert.That(() => mock.MultipleParameters(3, "a"), Throws.TypeOf<ExpectationException>());
	}
}