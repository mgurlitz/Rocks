﻿using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class MultipleModelGeneratorTests
{
	[Test]
	public static async Task GenerateWithMultipleCreatesAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<MockTests.ITarget>]
			[assembly: RockCreate<MockTests.ITarget>]
			
			namespace MockTests
			{
				public interface ITarget
				{
					string Retrieve(int value);
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class ITargetCreateExpectations
					: global::Rocks.Expectations
				{
					#pragma warning disable CS8618
					
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Func<int, string>, string>
					{
						public global::Rocks.Argument<int> @value { get; set; }
					}
					
					#pragma warning restore CS8618
					
					private global::System.Collections.Generic.List<global::MockTests.ITargetCreateExpectations.Handler0>? @handlers0;
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							if (this.handlers0?.Count > 0) { failures.AddRange(this.Verify(this.handlers0, 0)); }
					
							if (failures.Count > 0)
							{
								throw new global::Rocks.Exceptions.VerificationException(failures);
							}
						}
					}
					
					private sealed class Mock
						: global::MockTests.ITarget
					{
						public Mock(global::MockTests.ITargetCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::Rocks.MemberIdentifier(0, "string Retrieve(int @value)")]
						public string Retrieve(int @value)
						{
							if (this.Expectations.handlers0?.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers0)
								{
									if (@handler.@value.IsValid(@value!))
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback(@value!) : @handler.ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for string Retrieve(int @value)");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for string Retrieve(int @value)");
						}
						
						private global::MockTests.ITargetCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.ITargetCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.ITargetCreateExpectations.Handler0, global::System.Func<int, string>, string> Retrieve(global::Rocks.Argument<int> @value)
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							global::System.ArgumentNullException.ThrowIfNull(@value);
							
							var handler = new global::MockTests.ITargetCreateExpectations.Handler0
							{
								@value = @value,
							};
							
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.ITargetCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.ITargetCreateExpectations.MethodExpectations Methods { get; }
					
					internal ITargetCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal global::MockTests.ITarget Instance()
					{
						if (!this.WasInstanceInvoked)
						{
							this.WasInstanceInvoked = true;
							var @mock = new Mock(this);
							this.MockType = @mock.GetType();
							return @mock;
						}
						else
						{
							throw new global::Rocks.Exceptions.NewMockInstanceException("Can only create a new mock once.");
						}
					}
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.ITarget_Rock_Create.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task GenerateWithMultipleMakeAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockMake<MockTests.ITarget>]
			[assembly: RockMake<MockTests.ITarget>]
			
			namespace MockTests
			{
				public interface ITarget
				{
					string Retrieve(int value);
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class ITargetMakeExpectations
				{
					internal global::MockTests.ITarget Instance()
					{
						return new Mock();
					}
					
					private sealed class Mock
						: global::MockTests.ITarget
					{
						public Mock()
						{
						}
						
						public string Retrieve(int @value)
						{
							return default!;
						}
					}
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.ITarget_Rock_Make.g.cs", generatedCode) },
			[]);
	}
}