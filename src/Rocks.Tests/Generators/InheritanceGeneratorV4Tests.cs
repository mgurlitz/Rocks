﻿using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class InheritanceGeneratorV4Tests
{
	[Test]
	public static async Task GenerateWhenMethodIsIntroducedAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<MockTests.JsBinaryOperator>]

			namespace MockTests
			{
				public struct ScriptScopeContext { }

				public abstract class JsToken
				{
					public abstract object Evaluate(ScriptScopeContext scope);
				}

				public abstract class JsOperator 
					: JsToken
				{
					public override object Evaluate(ScriptScopeContext scope) => this;
				}

				public abstract class JsBinaryOperator 
					: JsOperator
				{
					public abstract object Evaluate(object target);
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
				internal sealed class JsBinaryOperatorCreateExpectations
					: global::Rocks.Expectations.ExpectationsV4
				{
					#pragma warning disable CS8618
					
					internal sealed class Handler0
						: global::Rocks.HandlerV4<global::System.Func<object?, bool>, bool>
					{
						public global::Rocks.Argument<object?> @obj { get; set; }
					}
					
					internal sealed class Handler1
						: global::Rocks.HandlerV4<global::System.Func<int>, int>
					{ }
					
					internal sealed class Handler2
						: global::Rocks.HandlerV4<global::System.Func<string?>, string?>
					{ }
					
					internal sealed class Handler4
						: global::Rocks.HandlerV4<global::System.Func<global::MockTests.ScriptScopeContext, object>, object>
					{
						public global::Rocks.Argument<global::MockTests.ScriptScopeContext> @scope { get; set; }
					}
					
					internal sealed class Handler5
						: global::Rocks.HandlerV4<global::System.Func<object, object>, object>
					{
						public global::Rocks.Argument<object> @target { get; set; }
					}
					
					#pragma warning restore CS8618
					
					private readonly global::System.Collections.Generic.List<global::MockTests.JsBinaryOperatorCreateExpectations.Handler0> @handlers0 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.JsBinaryOperatorCreateExpectations.Handler1> @handlers1 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.JsBinaryOperatorCreateExpectations.Handler2> @handlers2 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.JsBinaryOperatorCreateExpectations.Handler4> @handlers4 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.JsBinaryOperatorCreateExpectations.Handler5> @handlers5 = new();
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							failures.AddRange(this.Verify(handlers0));
							failures.AddRange(this.Verify(handlers1));
							failures.AddRange(this.Verify(handlers2));
							failures.AddRange(this.Verify(handlers4));
							failures.AddRange(this.Verify(handlers5));
					
							if (failures.Count > 0)
							{
								throw new global::Rocks.Exceptions.VerificationException(failures);
							}
						}
					}
					
					private sealed class RockJsBinaryOperator
						: global::MockTests.JsBinaryOperator
					{
						public RockJsBinaryOperator(global::MockTests.JsBinaryOperatorCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::Rocks.MemberIdentifier(0, "bool Equals(object? @obj)")]
						public override bool Equals(object? @obj)
						{
							if (this.Expectations.handlers0.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers0)
								{
									if (@handler.@obj.IsValid(@obj!))
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback(@obj!) : @handler.ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for bool Equals(object? @obj)");
							}
							else
							{
								return base.Equals(obj: @obj!);
							}
						}
						
						[global::Rocks.MemberIdentifier(1, "int GetHashCode()")]
						public override int GetHashCode()
						{
							if (this.Expectations.handlers1.Count > 0)
							{
								var @handler = this.Expectations.handlers1[0];
								@handler.CallCount++;
								var @result = @handler.Callback is not null ?
									@handler.Callback() : @handler.ReturnValue;
								return @result!;
							}
							else
							{
								return base.GetHashCode();
							}
						}
						
						[global::Rocks.MemberIdentifier(2, "string? ToString()")]
						public override string? ToString()
						{
							if (this.Expectations.handlers2.Count > 0)
							{
								var @handler = this.Expectations.handlers2[0];
								@handler.CallCount++;
								var @result = @handler.Callback is not null ?
									@handler.Callback() : @handler.ReturnValue;
								return @result!;
							}
							else
							{
								return base.ToString();
							}
						}
						
						[global::Rocks.MemberIdentifier(4, "object Evaluate(global::MockTests.ScriptScopeContext @scope)")]
						public override object Evaluate(global::MockTests.ScriptScopeContext @scope)
						{
							if (this.Expectations.handlers4.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers4)
								{
									if (@handler.@scope.IsValid(@scope!))
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback(@scope!) : @handler.ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for object Evaluate(global::MockTests.ScriptScopeContext @scope)");
							}
							else
							{
								return base.Evaluate(scope: @scope!);
							}
						}
						
						[global::Rocks.MemberIdentifier(5, "object Evaluate(object @target)")]
						public override object Evaluate(object @target)
						{
							if (this.Expectations.handlers5.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers5)
								{
									if (@handler.@target.IsValid(@target!))
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback(@target!) : @handler.ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for object Evaluate(object @target)");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for object Evaluate(object @target)");
						}
						
						private global::MockTests.JsBinaryOperatorCreateExpectations Expectations { get; }
					}
					
					internal sealed class JsBinaryOperatorMethodExpectations
					{
						internal JsBinaryOperatorMethodExpectations(global::MockTests.JsBinaryOperatorCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::MockTests.JsBinaryOperatorCreateExpectations.Handler0, global::System.Func<object?, bool>, bool> Equals(global::Rocks.Argument<object?> @obj)
						{
							global::System.ArgumentNullException.ThrowIfNull(@obj);
							
							var handler = new global::MockTests.JsBinaryOperatorCreateExpectations.Handler0
							{
								@obj = @obj,
							};
							
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						internal new global::Rocks.AdornmentsV4<global::MockTests.JsBinaryOperatorCreateExpectations.Handler1, global::System.Func<int>, int> GetHashCode()
						{
							var handler = new global::MockTests.JsBinaryOperatorCreateExpectations.Handler1();
							this.Expectations.handlers1.Add(handler);
							return new(handler);
						}
						
						internal new global::Rocks.AdornmentsV4<global::MockTests.JsBinaryOperatorCreateExpectations.Handler2, global::System.Func<string?>, string?> ToString()
						{
							var handler = new global::MockTests.JsBinaryOperatorCreateExpectations.Handler2();
							this.Expectations.handlers2.Add(handler);
							return new(handler);
						}
						
						internal global::Rocks.AdornmentsV4<global::MockTests.JsBinaryOperatorCreateExpectations.Handler4, global::System.Func<global::MockTests.ScriptScopeContext, object>, object> Evaluate(global::Rocks.Argument<global::MockTests.ScriptScopeContext> @scope)
						{
							global::System.ArgumentNullException.ThrowIfNull(@scope);
							
							var handler = new global::MockTests.JsBinaryOperatorCreateExpectations.Handler4
							{
								@scope = @scope,
							};
							
							this.Expectations.handlers4.Add(handler);
							return new(handler);
						}
						
						internal global::Rocks.AdornmentsV4<global::MockTests.JsBinaryOperatorCreateExpectations.Handler5, global::System.Func<object, object>, object> Evaluate(global::Rocks.Argument<object> @target)
						{
							global::System.ArgumentNullException.ThrowIfNull(@target);
							
							var handler = new global::MockTests.JsBinaryOperatorCreateExpectations.Handler5
							{
								@target = @target,
							};
							
							this.Expectations.handlers5.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.JsBinaryOperatorCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.JsBinaryOperatorCreateExpectations.JsBinaryOperatorMethodExpectations Methods { get; }
					
					internal JsBinaryOperatorCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal global::MockTests.JsBinaryOperator Instance()
					{
						if (!this.WasInstanceInvoked)
						{
							this.WasInstanceInvoked = true;
							var @mock = new RockJsBinaryOperator(this);
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

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.JsBinaryOperator_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}
}