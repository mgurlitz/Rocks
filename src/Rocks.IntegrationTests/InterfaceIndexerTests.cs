﻿using NUnit.Framework;

namespace Rocks.IntegrationTests;

public interface IInterfaceIndexerGetterInit
{
	int this[int a] { get; init; }
	int this[int a, string b] { get; init; }
}

public interface IInterfaceIndexerGetterSetter
{
	int this[int a] { get; set; }
	int this[int a, string b] { get; set; }
}

public interface IInterfaceIndexerGetter
{
	int this[int a] { get; }
	int this[int a, string b] { get; }

	event EventHandler MyEvent;
}

public interface IInterfaceIndexerInit
{
#pragma warning disable CA1044 // Properties should not be write only
   int this[int a] { init; }
   int this[int a, string b] { init; }
#pragma warning restore CA1044 // Properties should not be write only

	event EventHandler MyEvent;
}

public interface IInterfaceIndexerSetter
{
#pragma warning disable CA1044 // Properties should not be write only
	int this[int a] { set; }
	int this[int a, string b] { set; }
#pragma warning restore CA1044 // Properties should not be write only

	event EventHandler MyEvent;
}

public static class InterfaceIndexerTests
{
	[Test]
	[RockCreate<IInterfaceIndexerGetterInit>]
	public static void CreateWithOneParameterGetterAndInit()
	{
		var expectations = new IInterfaceIndexerGetterInitCreateExpectations();
		expectations.Indexers.Getters.This(3);

		var mock = expectations.Instance(null);
		var value = mock[3];

		expectations.Verify();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetterSetter>]
	public static void CreateWithOneParameterGetterAndSetter()
	{
		var expectations = new IInterfaceIndexerGetterSetterCreateExpectations();
		expectations.Indexers.Getters.This(3);
		expectations.Indexers.Setters.This(4, 3);

		var mock = expectations.Instance();
		var value = mock[3];
		mock[3] = 4;

		expectations.Verify();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockMake<IInterfaceIndexerGetterInit>]
	public static void MakeWithOneParameterGetterAndInit()
	{
		var mock = new IInterfaceIndexerGetterInitMakeExpectations().Instance(null);
		var value = mock[3];

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockMake<IInterfaceIndexerGetterSetter>]
	public static void MakeWithOneParameterGetterAndSetter()
	{
		var mock = new IInterfaceIndexerGetterSetterMakeExpectations().Instance();
		var value = mock[3];

		Assert.Multiple(() =>
		{
			Assert.That(value, Is.EqualTo(default(int)));
			Assert.That(() => mock[3] = 4, Throws.Nothing);
		});
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetter>]
	public static void CreateWithOneParameterGetter()
	{
		var expectations = new IInterfaceIndexerGetterCreateExpectations();
		expectations.Indexers.Getters.This(3);

		var mock = expectations.Instance();
		var value = mock[3];

		expectations.Verify();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockMake<IInterfaceIndexerGetter>]
	public static void MakeWithOneParameterGetter()
	{
		var mock = new IInterfaceIndexerGetterMakeExpectations().Instance();
		var value = mock[3];

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetter>]
	public static void CreateWithOneParameterGetterRaiseEvent()
	{
		var expectations = new IInterfaceIndexerGetterCreateExpectations();
		expectations.Indexers.Getters.This(3).AddRaiseEvent(new(nameof(IInterfaceIndexerGetter.MyEvent), EventArgs.Empty));

		var wasEventRaised = false;
		var mock = expectations.Instance();
		mock.MyEvent += (s, e) => wasEventRaised = true;
		var value = mock[3];

		expectations.Verify();

		Assert.Multiple(() =>
		{
			Assert.That(value, Is.EqualTo(default(int)));
			Assert.That(wasEventRaised, Is.True);
		});
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetter>]
	public static void CreateWithOneParameterGetterCallback()
	{
		var wasCallbackInvoked = false;
		var expectations = new IInterfaceIndexerGetterCreateExpectations();
		expectations.Indexers.Getters.This(3).Callback(_ =>
		{
			wasCallbackInvoked = true;
			return _;
		});

		var mock = expectations.Instance();
		var value = mock[3];

		expectations.Verify();

		Assert.Multiple(() =>
		{
			Assert.That(value, Is.EqualTo(3));
			Assert.That(wasCallbackInvoked, Is.True);
		});
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetter>]
	public static void CreateWithOneParameterGetterRaiseEventWithCallback()
	{
		var wasCallbackInvoked = false;
		var expectations = new IInterfaceIndexerGetterCreateExpectations();
		expectations.Indexers.Getters.This(3)
			.AddRaiseEvent(new(nameof(IInterfaceIndexerGetter.MyEvent), EventArgs.Empty))
			.Callback(_ =>
			{
				wasCallbackInvoked = true;
				return _;
			});

		var wasEventRaised = false;
		var mock = expectations.Instance();
		mock.MyEvent += (s, e) => wasEventRaised = true;
		var value = mock[3];

		expectations.Verify();

		Assert.Multiple(() =>
		{
			Assert.That(value, Is.EqualTo(3));
			Assert.That(wasEventRaised, Is.True);
			Assert.That(wasCallbackInvoked, Is.True);
		});
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetter>]
	public static void CreateWithOneParameterGetterMultipleCalls()
	{
		var expectations = new IInterfaceIndexerGetterCreateExpectations();
		expectations.Indexers.Getters.This(3).ExpectedCallCount(2);

		var mock = expectations.Instance();
		var value = mock[3];
		value = mock[3];

		expectations.Verify();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockCreate<IInterfaceIndexerInit>]
	public static void CreateWithOneParameterInit()
	{
		var expectations = new IInterfaceIndexerInitCreateExpectations();
		Assert.That(() => expectations.Instance(null), Throws.Nothing);
	}

	[Test]
	[RockCreate<IInterfaceIndexerSetter>]
	public static void CreateWithOneParameterSetter()
	{
		var expectations = new IInterfaceIndexerSetterCreateExpectations();
		expectations.Indexers.Setters.This(4, 3);

		var mock = expectations.Instance();
		mock[3] = 4;

		expectations.Verify();
	}

	[Test]
	[RockMake<IInterfaceIndexerSetter>]
	public static void MakeWithOneParameterSetter()
	{
		var mock = new IInterfaceIndexerSetterMakeExpectations().Instance();

		Assert.That(() => mock[3] = 4, Throws.Nothing);
	}

	[Test]
	[RockCreate<IInterfaceIndexerSetter>]
	public static void CreateWithOneParameterSetterRaiseEvent()
	{
		var expectations = new IInterfaceIndexerSetterCreateExpectations();
		expectations.Indexers.Setters.This(4, 3).AddRaiseEvent(new(nameof(IInterfaceIndexerSetter.MyEvent), EventArgs.Empty));

		var wasEventRaised = false;
		var mock = expectations.Instance();
		mock.MyEvent += (s, e) => wasEventRaised = true;
		mock[3] = 4;

		expectations.Verify();

		Assert.That(wasEventRaised, Is.True);
	}

	[Test]
	[RockCreate<IInterfaceIndexerSetter>]
	public static void CreateWithOneParameterSetterCallback()
	{
		var wasCallbackInvoked = false;
		var expectations = new IInterfaceIndexerSetterCreateExpectations();
		expectations.Indexers.Setters.This(4, 3).Callback((a, value) => wasCallbackInvoked = true);

		var mock = expectations.Instance();
		mock[3] = 4;

		expectations.Verify();

		Assert.That(wasCallbackInvoked, Is.True);
	}

	[Test]
	[RockCreate<IInterfaceIndexerSetter>]
	public static void CreateWithOneParameterSetterRaiseEventWithCallback()
	{
		var wasCallbackInvoked = false;
		var expectations = new IInterfaceIndexerSetterCreateExpectations();
		expectations.Indexers.Setters.This(4, 3)
			.AddRaiseEvent(new(nameof(IInterfaceIndexerSetter.MyEvent), EventArgs.Empty))
			.Callback((a, value) => wasCallbackInvoked = true);

		var wasEventRaised = false;
		var mock = expectations.Instance();
		mock.MyEvent += (s, e) => wasEventRaised = true;
		mock[3] = 4;

		expectations.Verify();

		Assert.Multiple(() =>
		{
			Assert.That(wasEventRaised, Is.True);
			Assert.That(wasCallbackInvoked, Is.True);
		});
	}

	[Test]
	[RockCreate<IInterfaceIndexerSetter>]
	public static void CreateWithOneParameterSetterMultipleCalls()
	{
		var expectations = new IInterfaceIndexerSetterCreateExpectations();
		expectations.Indexers.Setters.This(4, 3).ExpectedCallCount(2);

		var mock = expectations.Instance();
		mock[3] = 4;
		mock[3] = 4;

		expectations.Verify();
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetterSetter>]
	public static void CreateWithMultipleParametersGetterAndSetter()
	{
		var expectations = new IInterfaceIndexerGetterSetterCreateExpectations();
		expectations.Indexers.Getters.This(3, "b");
		expectations.Indexers.Setters.This(4, 3, "b");

		var mock = expectations.Instance();
		var value = mock[3, "b"];
		mock[3, "b"] = 4;

		expectations.Verify();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockMake<IInterfaceIndexerGetterSetter>]
	public static void MakeWithMultipleParametersGetterAndSetter()
	{
		var mock = new IInterfaceIndexerGetterSetterMakeExpectations().Instance();
		var value = mock[3, "b"];

		Assert.Multiple(() =>
		{
			Assert.That(value, Is.EqualTo(default(int)));
			Assert.That(() => mock[3, "b"] = 4, Throws.Nothing);
		});
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetter>]
	public static void CreateWithMultipleParametersGetter()
	{
		var expectations = new IInterfaceIndexerGetterCreateExpectations();
		expectations.Indexers.Getters.This(3, "b");

		var mock = expectations.Instance();
		var value = mock[3, "b"];

		expectations.Verify();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockMake<IInterfaceIndexerGetter>]
	public static void MakeWithMultipleParametersGetter()
	{
		var mock = new IInterfaceIndexerGetterMakeExpectations().Instance();
		var value = mock[3, "b"];

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetter>]
	public static void CreateWithMultipleParametersGetterRaiseEvent()
	{
		var expectations = new IInterfaceIndexerGetterCreateExpectations();
		expectations.Indexers.Getters.This(3, "b").AddRaiseEvent(new(nameof(IInterfaceIndexerGetter.MyEvent), EventArgs.Empty));

		var wasEventRaised = false;
		var mock = expectations.Instance();
		mock.MyEvent += (s, e) => wasEventRaised = true;
		var value = mock[3, "b"];

		expectations.Verify();

		Assert.Multiple(() =>
		{
			Assert.That(value, Is.EqualTo(default(int)));
			Assert.That(wasEventRaised, Is.True);
		});
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetter>]
	public static void CreateWithMultipleParametersGetterCallback()
	{
		var wasCallbackInvoked = false;
		var expectations = new IInterfaceIndexerGetterCreateExpectations();
		expectations.Indexers.Getters.This(3, "b").Callback((a, b) =>
		{
			wasCallbackInvoked = true;
			return a;
		});

		var mock = expectations.Instance();
		var value = mock[3, "b"];

		expectations.Verify();

		Assert.Multiple(() =>
		{
			Assert.That(value, Is.EqualTo(3));
			Assert.That(wasCallbackInvoked, Is.True);
		});
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetter>]
	public static void CreateWithMultipleParametersGetterRaiseEventWithCallback()
	{
		var wasCallbackInvoked = false;
		var expectations = new IInterfaceIndexerGetterCreateExpectations();
		expectations.Indexers.Getters.This(3, "b")
			.AddRaiseEvent(new(nameof(IInterfaceIndexerGetter.MyEvent), EventArgs.Empty))
			.Callback((a, b) =>
			{
				wasCallbackInvoked = true;
				return a;
			});

		var wasEventRaised = false;
		var mock = expectations.Instance();
		mock.MyEvent += (s, e) => wasEventRaised = true;
		var value = mock[3, "b"];

		expectations.Verify();

		Assert.Multiple(() =>
		{
			Assert.That(value, Is.EqualTo(3));
			Assert.That(wasEventRaised, Is.True);
			Assert.That(wasCallbackInvoked, Is.True);
		});
	}

	[Test]
	[RockCreate<IInterfaceIndexerGetter>]
	public static void CreateWithMultipleParametersGetterMultipleCalls()
	{
		var expectations = new IInterfaceIndexerGetterCreateExpectations();
		expectations.Indexers.Getters.This(3, "b").ExpectedCallCount(2);

		var mock = expectations.Instance();
		var value = mock[3, "b"];
		value = mock[3, "b"];

		expectations.Verify();

		Assert.That(value, Is.EqualTo(default(int)));
	}

	[Test]
	[RockCreate<IInterfaceIndexerSetter>]
	public static void CreateWithMultipleParametersSetter()
	{
		var expectations = new IInterfaceIndexerSetterCreateExpectations();
		expectations.Indexers.Setters.This(4, 3, "b");

		var mock = expectations.Instance();
		mock[3, "b"] = 4;

		expectations.Verify();
	}

	[Test]
	[RockMake<IInterfaceIndexerSetter>]
	public static void MakeWithMultipleParametersSetter()
	{
		var mock = new IInterfaceIndexerSetterMakeExpectations().Instance();

		Assert.That(() => mock[3, "b"] = 4, Throws.Nothing);
	}

	[Test]
	[RockCreate<IInterfaceIndexerSetter>]
	public static void CreateWithMultipleParametersSetterRaiseEvent()
	{
		var expectations = new IInterfaceIndexerSetterCreateExpectations();
		expectations.Indexers.Setters.This(4, 3, "b")
			.AddRaiseEvent(new(nameof(IInterfaceIndexerSetter.MyEvent), EventArgs.Empty));

		var wasEventRaised = false;
		var mock = expectations.Instance();
		mock.MyEvent += (s, e) => wasEventRaised = true;
		mock[3, "b"] = 4;

		expectations.Verify();

		Assert.That(wasEventRaised, Is.True);
	}

	[Test]
	[RockCreate<IInterfaceIndexerSetter>]
	public static void CreateWithMultipleParametersSetterCallback()
	{
		var wasCallbackInvoked = false;
		var expectations = new IInterfaceIndexerSetterCreateExpectations();
		expectations.Indexers.Setters.This(4, 3, "b").Callback((a, b, value) => wasCallbackInvoked = true);

		var mock = expectations.Instance();
		mock[3, "b"] = 4;

		expectations.Verify();

		Assert.That(wasCallbackInvoked, Is.True);
	}

	[Test]
	[RockCreate<IInterfaceIndexerSetter>]
	public static void CreateWithMultipleParametersSetterRaiseEventWithCallback()
	{
		var wasCallbackInvoked = false;
		var expectations = new IInterfaceIndexerSetterCreateExpectations();
		expectations.Indexers.Setters.This(4, 3, "b")
			.AddRaiseEvent(new(nameof(IInterfaceIndexerSetter.MyEvent), EventArgs.Empty))
			.Callback((a, b, value) => wasCallbackInvoked = true);

		var wasEventRaised = false;
		var mock = expectations.Instance();
		mock.MyEvent += (s, e) => wasEventRaised = true;
		mock[3, "b"] = 4;

		expectations.Verify();

		Assert.Multiple(() =>
		{
			Assert.That(wasEventRaised, Is.True);
			Assert.That(wasCallbackInvoked, Is.True);
		});
	}

	[Test]
	[RockCreate<IInterfaceIndexerSetter>]
	public static void CreateWithMultipleParametersSetterMultipleCalls()
	{
		var expectations = new IInterfaceIndexerSetterCreateExpectations();
		expectations.Indexers.Setters.This(4, 3, "b").ExpectedCallCount(2);

		var mock = expectations.Instance();
		mock[3, "b"] = 4;
		mock[3, "b"] = 4;

		expectations.Verify();
	}
}