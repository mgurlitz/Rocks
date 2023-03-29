﻿using System.ComponentModel;

namespace Rocks;

/// <summary>
/// Defines the base type for an argument expectation.
/// </summary>
[Serializable]
public abstract class Argument
{
	/// <summary>
	/// Creates a new <see cref="Argument"/> instance.
	/// </summary>
	protected Argument() { }
}

/// <summary>
/// Defines the base type for an argument expectation
/// with a specific type.
/// </summary>
/// <typeparam name="T">The type of the argument.</typeparam>
[Serializable]
public sealed class Argument<T>
	: Argument
{
	private readonly Predicate<T>? evaluation;
	private readonly T? value;
	private readonly ValidationState validation;

	/// <summary>
	/// Creates a new <see cref="Argument{T}"/> instance.
	/// </summary>
	internal Argument() => this.validation = ValidationState.None;

	/// <summary>
	/// Creates a new <see cref="Argument{T}"/> instance
	/// with a validation state.
	/// </summary>
	/// <param name="state">The validation state.</param>
	internal Argument(ValidationState state) => this.validation = state;

	/// <summary>
	/// Creates a new <see cref="Argument{T}"/> instance
	/// with a specific value.
	/// </summary>
	/// <param name="value">The value.</param>
	internal Argument(T value) =>
		(this.value, this.validation) = (value, ValidationState.Value);

	/// <summary>
	/// Creates a new <see cref="Argument{T}"/> instance
	/// with a validation delegate.
	/// </summary>
	/// <param name="evaluation">The validation delegate.</param>
	internal Argument(Predicate<T> evaluation) =>
		(this.evaluation, this.validation) = (evaluation, ValidationState.Evaluation);

	/// <summary>
	/// Converts a value to an <see cref="Argument{T}"/> instance.
	/// </summary>
	/// <param name="value">The value.</param>
	/// <returns>A new <see cref="Argument{T}"/> instance.</returns>
	public static implicit operator Argument<T>(T value) => new(value);

	/// <summary>
	/// Determines if the given value matches the expectation.
	/// </summary>
	/// <param name="value">The value to test.</param>
	/// <returns><c>true</c> if validation is successful; otherwise, <c>false</c>.</returns>
	/// <exception cref="NotSupportedException"></exception>
	/// <exception cref="InvalidEnumArgumentException"></exception>
	public bool IsValid(T value) =>
		this.validation switch
		{
			ValidationState.None => true,
			ValidationState.Value => ObjectEquality.AreEqual(value, this.value),
			ValidationState.Evaluation => this.evaluation!(value),
			ValidationState.DefaultValue => throw new NotSupportedException("Cannot validate an argument value in the DefaultValue state."),
			_ => throw new InvalidEnumArgumentException($"Invalid value for validation: {this.validation}")
		};

	/// <summary>
	/// Transforms a default value into an <see cref="Argument{T}"/> instance.
	/// </summary>
	/// <param name="value">The value to transform.</param>
	/// <returns>A <see cref="Argument{T}"/> instance.</returns>
	public Argument<T> Transform(T value) =>
		this.validation == ValidationState.DefaultValue ? new Argument<T>(value) : this;
}