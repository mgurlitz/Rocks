﻿using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class InterfaceGeneratorTests
{
	[Test]
	public static async Task GenerateWithStaticMemberAsync()
	{
		var code =
			"""
			using Rocks;
			
			public interface IRequest
			{
				public static string ToString(IRequest request) => "";
				public static string ToMethodCallString(IRequest request) => "";
				void AddInvokeMethodOptions(int options);
			}
			
			public static class Test
			{
				public static void Go() => Rock.Create<IRequest>();
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal static class CreateExpectationsOfIRequestExtensions
			{
				internal static global::Rocks.Expectations.MethodExpectations<global::IRequest> Methods(this global::Rocks.Expectations.Expectations<global::IRequest> @self) =>
					new(@self);
				
				internal static global::IRequest Instance(this global::Rocks.Expectations.Expectations<global::IRequest> @self)
				{
					if (!@self.WasInstanceInvoked)
					{
						@self.WasInstanceInvoked = true;
						var @mock = new RockIRequest(@self);
						@self.MockType = @mock.GetType();
						return @mock;
					}
					else
					{
						throw new global::Rocks.Exceptions.NewMockInstanceException("Can only create a new mock once.");
					}
				}
				
				private sealed class RockIRequest
					: global::IRequest
				{
					private readonly global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.List<global::Rocks.HandlerInformation>> handlers;
					
					public RockIRequest(global::Rocks.Expectations.Expectations<global::IRequest> @expectations)
					{
						this.handlers = @expectations.Handlers;
					}
					
					[global::Rocks.MemberIdentifier(0, "void AddInvokeMethodOptions(int @options)")]
					public void AddInvokeMethodOptions(int @options)
					{
						if (this.handlers.TryGetValue(0, out var @methodHandlers))
						{
							var @foundMatch = false;
							
							foreach (var @methodHandler in @methodHandlers)
							{
								if (((global::Rocks.Argument<int>)@methodHandler.Expectations[0]).IsValid(@options!))
								{
									@foundMatch = true;
									
									@methodHandler.IncrementCallCount();
									if (@methodHandler.Method is not null)
									{
										((global::System.Action<int>)@methodHandler.Method)(@options!);
									}
									break;
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void AddInvokeMethodOptions(int @options)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void AddInvokeMethodOptions(int @options)");
						}
					}
					
				}
			}
			
			internal static class MethodExpectationsOfIRequestExtensions
			{
				internal static global::Rocks.MethodAdornments<global::IRequest, global::System.Action<int>> AddInvokeMethodOptions(this global::Rocks.Expectations.MethodExpectations<global::IRequest> @self, global::Rocks.Argument<int> @options)
				{
					global::System.ArgumentNullException.ThrowIfNull(@options);
					return new global::Rocks.MethodAdornments<global::IRequest, global::System.Action<int>>(@self.Add(0, new global::System.Collections.Generic.List<global::Rocks.Argument>(1) { @options }));
				}
			}
			
			""";

		await TestAssistants.RunAsync<RockCreateGenerator>(code,
			new[] { (typeof(RockCreateGenerator), "IRequest_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateWithMethodAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			namespace MockTests
			{
				public interface ITarget
				{
					string Retrieve(int value);
				}

				public static class Test
				{
					public static void Generate()
					{
						var rock = Rock.Create<ITarget>();
					}
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;

			namespace MockTests
			{
				internal static class CreateExpectationsOfITargetExtensions
				{
					internal static global::Rocks.Expectations.MethodExpectations<global::MockTests.ITarget> Methods(this global::Rocks.Expectations.Expectations<global::MockTests.ITarget> @self) =>
						new(@self);
					
					internal static global::MockTests.ITarget Instance(this global::Rocks.Expectations.Expectations<global::MockTests.ITarget> @self)
					{
						if (!@self.WasInstanceInvoked)
						{
							@self.WasInstanceInvoked = true;
							var @mock = new RockITarget(@self);
							@self.MockType = @mock.GetType();
							return @mock;
						}
						else
						{
							throw new global::Rocks.Exceptions.NewMockInstanceException("Can only create a new mock once.");
						}
					}
					
					private sealed class RockITarget
						: global::MockTests.ITarget
					{
						private readonly global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.List<global::Rocks.HandlerInformation>> handlers;
						
						public RockITarget(global::Rocks.Expectations.Expectations<global::MockTests.ITarget> @expectations)
						{
							this.handlers = @expectations.Handlers;
						}
						
						[global::Rocks.MemberIdentifier(0, "string Retrieve(int @value)")]
						public string Retrieve(int @value)
						{
							if (this.handlers.TryGetValue(0, out var @methodHandlers))
							{
								foreach (var @methodHandler in @methodHandlers)
								{
									if (((global::Rocks.Argument<int>)@methodHandler.Expectations[0]).IsValid(@value!))
									{
										@methodHandler.IncrementCallCount();
										var @result = @methodHandler.Method is not null ?
											((global::System.Func<int, string>)@methodHandler.Method)(@value!) :
											((global::Rocks.HandlerInformation<string>)@methodHandler).ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for string Retrieve(int @value)");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for string Retrieve(int @value)");
						}
						
					}
				}
				
				internal static class MethodExpectationsOfITargetExtensions
				{
					internal static global::Rocks.MethodAdornments<global::MockTests.ITarget, global::System.Func<int, string>, string> Retrieve(this global::Rocks.Expectations.MethodExpectations<global::MockTests.ITarget> @self, global::Rocks.Argument<int> @value)
					{
						global::System.ArgumentNullException.ThrowIfNull(@value);
						return new global::Rocks.MethodAdornments<global::MockTests.ITarget, global::System.Func<int, string>, string>(@self.Add<string>(0, new global::System.Collections.Generic.List<global::Rocks.Argument>(1) { @value }));
					}
				}
			}
			
			""";

		await TestAssistants.RunAsync<RockCreateGenerator>(code,
			new[] { (typeof(RockCreateGenerator), "MockTests.ITarget_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}
}