﻿using NUnit.Framework;

namespace Rocks.IntegrationTests;

public class ReferenceTypeOne { }
public class ReferenceTypeTwo { }

public class ReferencedContainer<T> { }

public class GenericContainer
{
	// Add docs for multiple return values and using Callback()
	// public virtual Container<T> Set<T>() where T : class
	// public DbSet<TEntity> Set<TEntity() where TEntity : class
	public virtual ReferencedContainer<T> SetThings<T>() where T : class => new();
	public virtual TReturn Run<TReturn>() where TReturn : new() => new();
}

public interface IGenericContainer
{
	void Sprint<TReturn>();
	TReturn Run<TReturn>() where TReturn : new();
	TReturn Run<TInput, TReturn>(TInput input) where TReturn : new();
}

public static class GenericTests
{
	[Test]
	[RockCreate<GenericContainer>]
	public static void CreateWithMultipleExpectationsOfDifferentTypesForReturnThatUsesGenericFromClass()
	{
		var referencedContainerOne = new ReferencedContainer<ReferenceTypeOne>();
		var referencedContainerTwo = new ReferencedContainer<ReferenceTypeTwo>();

		var expectations = new GenericContainerCreateExpectations();
		expectations.Methods.SetThings<ReferenceTypeOne>().ReturnValue(referencedContainerOne);
		expectations.Methods.SetThings<ReferenceTypeTwo>().ReturnValue(referencedContainerTwo);

		var mock = expectations.Instance();
		Assert.Multiple(() =>
		{
			Assert.That(mock.SetThings<ReferenceTypeOne>(), Is.SameAs(referencedContainerOne));
			Assert.That(mock.SetThings<ReferenceTypeTwo>(), Is.EqualTo(referencedContainerTwo));
		});
		expectations.Verify();
	}

	[Test]
	[RockCreate<GenericContainer>]
	public static void CreateWithMultipleExpectationsOfDifferentTypesForReturnFromClass()
	{
		var guidReturn = Guid.NewGuid();

		var expectations = new GenericContainerCreateExpectations();
		expectations.Methods.Run<int>().ReturnValue(4);
		expectations.Methods.Run<Guid>().ReturnValue(guidReturn);

		var mock = expectations.Instance();
		Assert.Multiple(() =>
		{
			Assert.That(mock.Run<int>(), Is.EqualTo(4));
			Assert.That(mock.Run<Guid>(), Is.EqualTo(guidReturn));
		});
		expectations.Verify();
	}

	[Test]
	[RockCreate<IGenericContainer>]
	public static void CreateWithMultipleExpectationsOfDifferentTypesForReturnFromInterface()
	{
		var guidReturn = Guid.NewGuid();

		var expectations = new IGenericContainerCreateExpectations();
		expectations.Methods.Run<int>().ReturnValue(4);
		expectations.Methods.Run<Guid>().ReturnValue(guidReturn);

		var mock = expectations.Instance();
		Assert.Multiple(() =>
		{
			Assert.That(mock.Run<int>(), Is.EqualTo(4));
			Assert.That(mock.Run<Guid>(), Is.EqualTo(guidReturn));
		});

		expectations.Verify();
	}

	[Test]
	[RockCreate<IGenericContainer>]
	public static void CreateWithMultipleExpectationsOfDifferentTypesForParameterAndReturnFromInterface()
	{
		var guidReturn = Guid.NewGuid();
		var guidArgument = Guid.NewGuid();

		var expectations = new IGenericContainerCreateExpectations();
		expectations.Methods.Run<int, Guid>(4).ReturnValue(guidReturn);
		expectations.Methods.Run<Guid, int>(guidArgument).ReturnValue(5);

		var mock = expectations.Instance();
		Assert.Multiple(() =>
		{
			Assert.That(mock.Run<int, Guid>(4), Is.EqualTo(guidReturn));
			Assert.That(mock.Run<Guid, int>(guidArgument), Is.EqualTo(5));
		});
		expectations.Verify();
	}
}