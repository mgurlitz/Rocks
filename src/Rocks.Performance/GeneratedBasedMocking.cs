﻿// <auto-generated/>
// Cast-free

// Rock.Create<ISimple> returns Expectations<ISimple>
// I don't think there's any way to do something to "fool"
// Rocks into creating an arbitrary type, unless I rely on
// Activator.CreateInstance(), which feels really squirrley.
//
// HOWEVER, if do that FAWNN:
// [assembly: RockCreate<ISimple>]
//
// Then we'd find it something like this:
// context.SyntaxProvider.ForAttributeWithMetadataName("Rocks.RockCreateAttribute`1", ...);
// (https://www.thinktecture.com/en/net-core/roslyn-source-generators-high-level-api-forattributewithmetadataname/)
// (https://learn.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.syntaxvalueprovider.forattributewithmetadataname)
//
// Then a user would do this:
// var expectations = new ISimpleExpectations();
// Because you have to declare the attribute first, then 
// the custom expectations classes will be created.
//
// Really, "Rock.Create()" is arbitrary and minimal,
// though it would be a slight change (8.0.0 version).
// BUT, this may improve things a lot, because:
// * I can put the mock in the custom expectations object along with .Instance()
// so the exepctation properties will also be "private", and only visible to the mock.

#nullable enable

using Rocks;
using Rocks.Exceptions;
using Rocks.Extensions;

/*
Eventually I'll want an IExpectations with MockType and WasInstanceInvoked properties
along with a Verify() method...maybe. It may turn out that I don't need the interface at all.
*/
internal sealed class ISimpleCreateExpectations
	: GeneratedExpectations
{
	// Create as many handlers as needed for methods, properties and indexers
	// The name of the alias is "handler{memberIdentifier}"
	// It's a concatenation of:
	// * arguments
	// * callback
	// * call count
	// * expected call count
	// * return value (if not void)
	internal sealed class Handler0
		: GeneratedHandler<global::System.Func<int, global::System.Guid, string>, string>
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public global::Rocks.Argument<int> Options { get; set; }
		public global::Rocks.Argument<global::System.Guid> Id { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	}

	// Create as many handler lists for all the handler types.
	private readonly List<Handler0> @handlers0 = new();

	// Create all the method, property, and indexer properties for 
	// setting expectations.
	internal ISimpleMethodExpectations Methods { get; }

	internal ISimpleCreateExpectations() =>
		(this.Methods) = (new(this));

	internal global::ISimple Instance()
	{
		if (!this.WasInstanceInvoked)
		{
			this.WasInstanceInvoked = true;
			var @mock = new RockISimple(this);
			this.MockType = @mock.GetType();
			return @mock;
		}
		else
		{
			throw new global::Rocks.Exceptions.NewMockInstanceException("Can only create a new mock once.");
		}
	}

	public override void Verify()
	{
		if (this.WasInstanceInvoked)
		{
			var failures = new List<string>();

			failures.AddRange(this.Verify(handlers0));

			if (failures.Count > 0)
			{
				throw new VerificationException(failures);
			}
		}
	}

	private sealed class RockISimple
		 : global::ISimple
	{
		private readonly global::System.Collections.Generic.List<Handler0> handlers0;

		public RockISimple(global::ISimpleCreateExpectations @expectations)
		{
			this.handlers0 = @expectations.@handlers0;
		}

		[global::Rocks.MemberIdentifier(0, "string DoStuff(int @options, global::System.Guid @id)")]
		public string DoStuff(int @options, global::System.Guid @id)
		{
			for (var i = 0; i < @handlers0.Count; i++)
			{
				var @handler = @handlers0[i];

				if (@handler.Options.IsValid(@options!) &&
					@handler.Id.IsValid(@id!))
				{
					@handler.CallCount++;
					var @result = @handler.Callback is not null ?
						 @handler.Callback(@options!, @id!) :
						 @handler.ReturnValue;
					return @result!;
				}
			}

			throw new global::Rocks.Exceptions.ExpectationException(
				 "No handlers match for string DoStuff(int @options, global::System.Guid @id)");
		}
	}

	// I may be able to get rid of all the expectation
	// subtypes - not needed anymore
	internal sealed class ISimpleMethodExpectations
	{
		private readonly ISimpleCreateExpectations expectations;

		internal ISimpleMethodExpectations(ISimpleCreateExpectations expectations) =>
			this.expectations = expectations;

		internal GeneratedMethodAdornments<Handler0, global::System.Func<int, global::System.Guid, string>, string> DoStuff(
			global::Rocks.Argument<int> @options, global::Rocks.Argument<global::System.Guid> @id)
		{
			global::System.ArgumentNullException.ThrowIfNull(@options);
			global::System.ArgumentNullException.ThrowIfNull(@id);

			var handler = new Handler0
			{
				Options = @options,
				Id = @id,
				Callback = null,
				CallCount = 0,
				ExpectedCallCount = 1,
				ReturnValue = null
			};

			this.expectations.handlers0.Add(handler);

			return new GeneratedMethodAdornments<Handler0, global::System.Func<int, global::System.Guid, string>, string>(handler);
		}
	}
}

// This is what would need to be added or changed
// in Rocks.
namespace Rocks
{
	public abstract class GeneratedExpectations
	{
		public abstract void Verify();

		protected List<string> Verify<THandler>(List<THandler> handlers)
			where THandler : GeneratedHandler =>
			handlers.Where(_ => _.ExpectedCallCount != _.CallCount)
				.Select(_ =>
				{
					var member = this.MockType!.GetMemberDescription(0);
					return $"Mock type: {this.MockType!.FullName}, member: {member}, messsage: The expected call count is incorrect. Expected: {_.ExpectedCallCount}, received: {_.CallCount}.";
				}).ToList();

		protected Type? MockType { get; set; }

		protected bool WasInstanceInvoked { get; set; }
	}

	public sealed class GeneratedMethodAdornments<THandler, TCallback, TReturn>
		where THandler : GeneratedHandler<TCallback, TReturn>
		where TCallback : Delegate
	{
		private readonly THandler handler;

		public GeneratedMethodAdornments(THandler handler) =>
			this.handler = handler;

		public GeneratedMethodAdornments<THandler, TCallback, TReturn> CallCount(uint expectedCallCount)
		{
			this.handler.ExpectedCallCount = expectedCallCount;
			return this;
		}

		public GeneratedMethodAdornments<THandler, TCallback, TReturn> Callback(TCallback callback)
		{
			this.handler.Callback = callback;
			return this;
		}

		public GeneratedMethodAdornments<THandler, TCallback, TReturn> Returns(TReturn returnValue)
		{
			this.handler.ReturnValue = returnValue;
			return this;
		}
	}

	public abstract class GeneratedHandler
	{
		public uint CallCount { get; set; }
		public uint ExpectedCallCount { get; set; }
	}

	public abstract class GeneratedHandler<TCallback, TReturn>
		: GeneratedHandler
		where TCallback : Delegate
	{
		public TCallback? Callback { get; set; }
		public TReturn? ReturnValue { get; set; }
	}
}