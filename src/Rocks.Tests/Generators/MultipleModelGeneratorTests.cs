﻿using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class MultipleModelGeneratorTests
{
	// This test, if it fails, may be an indication
	// that something changed with the models such that
	// equality broke.
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
			
			using Rocks.Extensions;
			
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
					private global::Rocks.Handlers<global::MockTests.ITargetCreateExpectations.Handler0>? @handlers0;
					#pragma warning restore CS8618
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							if (this.handlers0 is not null) { failures.AddRange(this.Verify(this.handlers0, 0)); }
					
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
						
						[global::Rocks.MemberIdentifier(0)]
						public string Retrieve(int @value)
						{
							if (this.Expectations.handlers0 is not null)
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
								
								throw new global::Rocks.Exceptions.ExpectationException($"No handlers match for {this.GetType().GetMemberDescription(0)}");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException($"No handlers were found for {this.GetType().GetMemberDescription(0)}");
						}
						
						private global::MockTests.ITargetCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.ITargetCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::MockTests.ITargetCreateExpectations.Adornments.AdornmentsForHandler0 Retrieve(global::Rocks.Argument<int> @value)
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							global::System.ArgumentNullException.ThrowIfNull(@value);
							
							var @handler = new global::MockTests.ITargetCreateExpectations.Handler0
							{
								@value = @value,
							};
							
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(@handler); }
							else { this.Expectations.handlers0.Add(@handler); }
							return new(@handler);
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
					
					internal static class Adornments
					{
						public interface IAdornmentsForITarget<TAdornments>
							: global::Rocks.IAdornments<TAdornments>
							where TAdornments : IAdornmentsForITarget<TAdornments>
						{ }
						
						public sealed class AdornmentsForHandler0
							: global::Rocks.Adornments<AdornmentsForHandler0, global::MockTests.ITargetCreateExpectations.Handler0, global::System.Func<int, string>, string>, IAdornmentsForITarget<AdornmentsForHandler0>
						{ 
							public AdornmentsForHandler0(global::MockTests.ITargetCreateExpectations.Handler0 handler)
								: base(handler) { }				
						}
					}
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			[(typeof(RockAttributeGenerator), "MockTests.ITarget_Rock_Create.g.cs", generatedCode)],
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
			
			#pragma warning disable CS8775
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
			
			#pragma warning restore CS8775
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			[(typeof(RockAttributeGenerator), "MockTests.ITarget_Rock_Make.g.cs", generatedCode)],
			[]);
	}
}