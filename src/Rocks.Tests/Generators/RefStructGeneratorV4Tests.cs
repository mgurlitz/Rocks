﻿using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class RefStructGeneratorV4Tests
{
	[Test]
	public static async Task GenerateWithSpanOfTAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<IHaveSpans>]

			public interface IHaveSpans
			{
				Span<int> Foo(Span<int> values);
				Span<byte> Values { get; set; }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using ProjectionsForIHaveSpans;
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			namespace ProjectionsForIHaveSpans
			{
				internal delegate global::System.Span<int> FooCallback_66561015379568062927102038977019508240052860641(global::System.Span<int> @values);
				internal delegate global::System.Span<int> FooReturnValue_66561015379568062927102038977019508240052860641();
				internal delegate global::System.Span<byte> get_ValuesCallback_582583672052025768205427892801117290935185139605();
				internal delegate global::System.Span<byte> get_ValuesReturnValue_582583672052025768205427892801117290935185139605();
				internal delegate void set_ValuesCallback_319151028473084578244445387582248500102792854657(global::System.Span<byte> @value);
				internal delegate bool ArgEvaluationForSpanOfint(global::System.Span<int> @value);
				
				internal sealed class ArgForSpanOfint
					: global::Rocks.Argument
				{
					private readonly global::ProjectionsForIHaveSpans.ArgEvaluationForSpanOfint? evaluation;
					private readonly global::Rocks.ValidationState validation;
					
					internal ArgForSpanOfint() => this.validation = global::Rocks.ValidationState.None;
					
					internal ArgForSpanOfint(global::ProjectionsForIHaveSpans.ArgEvaluationForSpanOfint @evaluation)
					{
						this.evaluation = @evaluation;
						this.validation = global::Rocks.ValidationState.Evaluation;
					}
					
					public bool IsValid(global::System.Span<int> @value) =>
						this.validation switch
						{
							global::Rocks.ValidationState.None => true,
							global::Rocks.ValidationState.Evaluation => this.evaluation!(@value),
							_ => throw new global::System.NotSupportedException("Invalid validation state."),
						};
				}
				internal delegate bool ArgEvaluationForSpanOfbyte(global::System.Span<byte> @value);
				
				internal sealed class ArgForSpanOfbyte
					: global::Rocks.Argument
				{
					private readonly global::ProjectionsForIHaveSpans.ArgEvaluationForSpanOfbyte? evaluation;
					private readonly global::Rocks.ValidationState validation;
					
					internal ArgForSpanOfbyte() => this.validation = global::Rocks.ValidationState.None;
					
					internal ArgForSpanOfbyte(global::ProjectionsForIHaveSpans.ArgEvaluationForSpanOfbyte @evaluation)
					{
						this.evaluation = @evaluation;
						this.validation = global::Rocks.ValidationState.Evaluation;
					}
					
					public bool IsValid(global::System.Span<byte> @value) =>
						this.validation switch
						{
							global::Rocks.ValidationState.None => true,
							global::Rocks.ValidationState.Evaluation => this.evaluation!(@value),
							_ => throw new global::System.NotSupportedException("Invalid validation state."),
						};
				}
			}
			
			internal sealed class IHaveSpansCreateExpectations
				: global::Rocks.Expectations.ExpectationsV4
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.HandlerV4<global::ProjectionsForIHaveSpans.FooCallback_66561015379568062927102038977019508240052860641, global::ProjectionsForIHaveSpans.FooReturnValue_66561015379568062927102038977019508240052860641>
				{
					public global::Rocks.Argument<global::System.Span<int>> @values { get; set; }
				}
				
				internal sealed class Handler1
					: global::Rocks.HandlerV4<global::ProjectionsForIHaveSpans.get_ValuesCallback_582583672052025768205427892801117290935185139605, global::ProjectionsForIHaveSpans.get_ValuesReturnValue_582583672052025768205427892801117290935185139605>
				{ }
				
				internal sealed class Handler2
					: global::Rocks.HandlerV4<global::ProjectionsForIHaveSpans.set_ValuesCallback_319151028473084578244445387582248500102792854657>
				{
					public global::Rocks.Argument<global::System.Span<byte>> @value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::IHaveSpansCreateExpectations.Handler0> @handlers0 = new();
				private readonly global::System.Collections.Generic.List<global::IHaveSpansCreateExpectations.Handler1> @handlers1 = new();
				private readonly global::System.Collections.Generic.List<global::IHaveSpansCreateExpectations.Handler2> @handlers2 = new();
				
				public override void Verify()
				{
					if (this.WasInstanceInvoked)
					{
						var failures = new global::System.Collections.Generic.List<string>();
				
						failures.AddRange(this.Verify(handlers0));
						failures.AddRange(this.Verify(handlers1));
						failures.AddRange(this.Verify(handlers2));
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class RockIHaveSpans
					: global::IHaveSpans
				{
					public RockIHaveSpans(global::IHaveSpansCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "global::System.Span<int> Foo(global::System.Span<int> @values)")]
					public global::System.Span<int> Foo(global::System.Span<int> @values)
					{
						if (this.Expectations.handlers0.Count > 0)
						{
							foreach (var @handler in this.Expectations.handlers0)
							{
								if (@handler.@values.IsValid(@values!))
								{
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback(@values!) : @handler.ReturnValue;
									return @result!;
								}
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers match for global::System.Span<int> Foo(global::System.Span<int> @values)");
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::System.Span<int> Foo(global::System.Span<int> @values)");
					}
					
					[global::Rocks.MemberIdentifier(1, "get_Values()")]
					[global::Rocks.MemberIdentifier(2, "set_Values(value)")]
					public global::System.Span<byte> Values
					{
						get
						{
							if (this.Expectations.handlers1.Count > 0)
							{
								var @handler = this.Expectations.handlers1[0];
								@handler.CallCount++;
								var @result = @handler.Callback?.Invoke() ?? @handler.ReturnValue;
								return @result!;
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_Values())");
						}
						set
						{
							if (this.Expectations.handlers2.Count > 0)
							{
								var @foundMatch = false;
								foreach (var @handler in this.Expectations.handlers2)
								{
									if (@handler.value.IsValid(value!))
									{
										@handler.CallCount++;
										@foundMatch = true;
										@handler.Callback?.Invoke(value!);
										
										if (!@foundMatch)
										{
											throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_Values(value)");
										}
										
										break;
									}
								}
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for set_Values(value)");
							}
						}
					}
					
					private global::IHaveSpansCreateExpectations Expectations { get; }
				}
				
				internal sealed class IHaveSpansMethodExpectations
				{
					internal IHaveSpansMethodExpectations(global::IHaveSpansCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::IHaveSpansCreateExpectations.Handler0, global::ProjectionsForIHaveSpans.FooCallback_66561015379568062927102038977019508240052860641, global::ProjectionsForIHaveSpans.FooReturnValue_66561015379568062927102038977019508240052860641> Foo(global::ProjectionsForIHaveSpans.ArgForSpanOfint @values)
					{
						global::System.ArgumentNullException.ThrowIfNull(@values);
						
						var handler = new global::IHaveSpansCreateExpectations.Handler0
						{
							@values = @values,
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					private global::IHaveSpansCreateExpectations Expectations { get; }
				}
				
				internal sealed class IHaveSpansPropertyExpectations
				{
					internal sealed class IHaveSpansPropertyGetterExpectations
					{
						internal IHaveSpansPropertyGetterExpectations(global::IHaveSpansCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::IHaveSpansCreateExpectations.Handler1, global::ProjectionsForIHaveSpans.get_ValuesCallback_582583672052025768205427892801117290935185139605, global::ProjectionsForIHaveSpans.get_ValuesReturnValue_582583672052025768205427892801117290935185139605> Values()
						{
							var handler = new global::IHaveSpansCreateExpectations.Handler1();
							this.Expectations.handlers1.Add(handler);
							return new(handler);
						}
						private global::IHaveSpansCreateExpectations Expectations { get; }
					}
					
					internal sealed class IHaveSpansPropertySetterExpectations
					{
						internal IHaveSpansPropertySetterExpectations(global::IHaveSpansCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::IHaveSpansCreateExpectations.Handler2, global::ProjectionsForIHaveSpans.set_ValuesCallback_319151028473084578244445387582248500102792854657> Values(global::Rocks.Argument<global::ProjectionsForIHaveSpans.ArgForSpanOfbyte> @value)
						{
							var handler = new global::IHaveSpansCreateExpectations.Handler2
							{
								value = @value,
							};
						
							this.Expectations.handlers2.Add(handler);
							return new(handler);
						}
						private global::IHaveSpansCreateExpectations Expectations { get; }
					}
					
					internal IHaveSpansPropertyExpectations(global::IHaveSpansCreateExpectations expectations) =>
						(this.Getters, this.Setters) = (new(expectations), new(expectations));
					
					internal global::IHaveSpansCreateExpectations.IHaveSpansPropertyExpectations.IHaveSpansPropertyGetterExpectations Getters { get; }
					internal global::IHaveSpansCreateExpectations.IHaveSpansPropertyExpectations.IHaveSpansPropertySetterExpectations Setters { get; }
				}
				
				internal global::IHaveSpansCreateExpectations.IHaveSpansMethodExpectations Methods { get; }
				internal global::IHaveSpansCreateExpectations.IHaveSpansPropertyExpectations Properties { get; }
				
				internal IHaveSpansCreateExpectations() =>
					(this.Methods, this.Properties) = (new(this), new(this));
				
				internal global::IHaveSpans Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockIHaveSpans(this);
						this.MockType = @mock.GetType();
						return @mock;
					}
					else
					{
						throw new global::Rocks.Exceptions.NewMockInstanceException("Can only create a new mock once.");
					}
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IHaveSpans_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateWithCustomRefStructAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<IHaveCustomRefStruct>]

			public ref struct Custom
			{
			    public int Number { get; set; }
			}
			
			public interface IHaveCustomRefStruct
			{
				Custom Foo(Custom values);
				Custom Values { get; set; }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using ProjectionsForIHaveCustomRefStruct;
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			namespace ProjectionsForIHaveCustomRefStruct
			{
				internal delegate global::Custom FooCallback_247090787197721297604732917092203102821567031853(global::Custom @values);
				internal delegate global::Custom FooReturnValue_247090787197721297604732917092203102821567031853();
				internal delegate global::Custom get_ValuesCallback_243744026731760932226333131017956768037587011670();
				internal delegate global::Custom get_ValuesReturnValue_243744026731760932226333131017956768037587011670();
				internal delegate void set_ValuesCallback_628925452417898181443764820763717280972249757505(global::Custom @value);
				internal delegate bool ArgEvaluationForCustom(global::Custom @value);
				
				internal sealed class ArgForCustom
					: global::Rocks.Argument
				{
					private readonly global::ProjectionsForIHaveCustomRefStruct.ArgEvaluationForCustom? evaluation;
					private readonly global::Rocks.ValidationState validation;
					
					internal ArgForCustom() => this.validation = global::Rocks.ValidationState.None;
					
					internal ArgForCustom(global::ProjectionsForIHaveCustomRefStruct.ArgEvaluationForCustom @evaluation)
					{
						this.evaluation = @evaluation;
						this.validation = global::Rocks.ValidationState.Evaluation;
					}
					
					public bool IsValid(global::Custom @value) =>
						this.validation switch
						{
							global::Rocks.ValidationState.None => true,
							global::Rocks.ValidationState.Evaluation => this.evaluation!(@value),
							_ => throw new global::System.NotSupportedException("Invalid validation state."),
						};
				}
			}
			
			internal sealed class IHaveCustomRefStructCreateExpectations
				: global::Rocks.Expectations.ExpectationsV4
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.HandlerV4<global::ProjectionsForIHaveCustomRefStruct.FooCallback_247090787197721297604732917092203102821567031853, global::ProjectionsForIHaveCustomRefStruct.FooReturnValue_247090787197721297604732917092203102821567031853>
				{
					public global::Rocks.Argument<global::Custom> @values { get; set; }
				}
				
				internal sealed class Handler1
					: global::Rocks.HandlerV4<global::ProjectionsForIHaveCustomRefStruct.get_ValuesCallback_243744026731760932226333131017956768037587011670, global::ProjectionsForIHaveCustomRefStruct.get_ValuesReturnValue_243744026731760932226333131017956768037587011670>
				{ }
				
				internal sealed class Handler2
					: global::Rocks.HandlerV4<global::ProjectionsForIHaveCustomRefStruct.set_ValuesCallback_628925452417898181443764820763717280972249757505>
				{
					public global::Rocks.Argument<global::Custom> @value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::IHaveCustomRefStructCreateExpectations.Handler0> @handlers0 = new();
				private readonly global::System.Collections.Generic.List<global::IHaveCustomRefStructCreateExpectations.Handler1> @handlers1 = new();
				private readonly global::System.Collections.Generic.List<global::IHaveCustomRefStructCreateExpectations.Handler2> @handlers2 = new();
				
				public override void Verify()
				{
					if (this.WasInstanceInvoked)
					{
						var failures = new global::System.Collections.Generic.List<string>();
				
						failures.AddRange(this.Verify(handlers0));
						failures.AddRange(this.Verify(handlers1));
						failures.AddRange(this.Verify(handlers2));
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class RockIHaveCustomRefStruct
					: global::IHaveCustomRefStruct
				{
					public RockIHaveCustomRefStruct(global::IHaveCustomRefStructCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "global::Custom Foo(global::Custom @values)")]
					public global::Custom Foo(global::Custom @values)
					{
						if (this.Expectations.handlers0.Count > 0)
						{
							foreach (var @handler in this.Expectations.handlers0)
							{
								if (@handler.@values.IsValid(@values!))
								{
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback(@values!) : @handler.ReturnValue;
									return @result!;
								}
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers match for global::Custom Foo(global::Custom @values)");
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::Custom Foo(global::Custom @values)");
					}
					
					[global::Rocks.MemberIdentifier(1, "get_Values()")]
					[global::Rocks.MemberIdentifier(2, "set_Values(value)")]
					public global::Custom Values
					{
						get
						{
							if (this.Expectations.handlers1.Count > 0)
							{
								var @handler = this.Expectations.handlers1[0];
								@handler.CallCount++;
								var @result = @handler.Callback?.Invoke() ?? @handler.ReturnValue;
								return @result!;
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_Values())");
						}
						set
						{
							if (this.Expectations.handlers2.Count > 0)
							{
								var @foundMatch = false;
								foreach (var @handler in this.Expectations.handlers2)
								{
									if (@handler.value.IsValid(value!))
									{
										@handler.CallCount++;
										@foundMatch = true;
										@handler.Callback?.Invoke(value!);
										
										if (!@foundMatch)
										{
											throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_Values(value)");
										}
										
										break;
									}
								}
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for set_Values(value)");
							}
						}
					}
					
					private global::IHaveCustomRefStructCreateExpectations Expectations { get; }
				}
				
				internal sealed class IHaveCustomRefStructMethodExpectations
				{
					internal IHaveCustomRefStructMethodExpectations(global::IHaveCustomRefStructCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::IHaveCustomRefStructCreateExpectations.Handler0, global::ProjectionsForIHaveCustomRefStruct.FooCallback_247090787197721297604732917092203102821567031853, global::ProjectionsForIHaveCustomRefStruct.FooReturnValue_247090787197721297604732917092203102821567031853> Foo(global::ProjectionsForIHaveCustomRefStruct.ArgForCustom @values)
					{
						global::System.ArgumentNullException.ThrowIfNull(@values);
						
						var handler = new global::IHaveCustomRefStructCreateExpectations.Handler0
						{
							@values = @values,
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					private global::IHaveCustomRefStructCreateExpectations Expectations { get; }
				}
				
				internal sealed class IHaveCustomRefStructPropertyExpectations
				{
					internal sealed class IHaveCustomRefStructPropertyGetterExpectations
					{
						internal IHaveCustomRefStructPropertyGetterExpectations(global::IHaveCustomRefStructCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::IHaveCustomRefStructCreateExpectations.Handler1, global::ProjectionsForIHaveCustomRefStruct.get_ValuesCallback_243744026731760932226333131017956768037587011670, global::ProjectionsForIHaveCustomRefStruct.get_ValuesReturnValue_243744026731760932226333131017956768037587011670> Values()
						{
							var handler = new global::IHaveCustomRefStructCreateExpectations.Handler1();
							this.Expectations.handlers1.Add(handler);
							return new(handler);
						}
						private global::IHaveCustomRefStructCreateExpectations Expectations { get; }
					}
					
					internal sealed class IHaveCustomRefStructPropertySetterExpectations
					{
						internal IHaveCustomRefStructPropertySetterExpectations(global::IHaveCustomRefStructCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::IHaveCustomRefStructCreateExpectations.Handler2, global::ProjectionsForIHaveCustomRefStruct.set_ValuesCallback_628925452417898181443764820763717280972249757505> Values(global::Rocks.Argument<global::ProjectionsForIHaveCustomRefStruct.ArgForCustom> @value)
						{
							var handler = new global::IHaveCustomRefStructCreateExpectations.Handler2
							{
								value = @value,
							};
						
							this.Expectations.handlers2.Add(handler);
							return new(handler);
						}
						private global::IHaveCustomRefStructCreateExpectations Expectations { get; }
					}
					
					internal IHaveCustomRefStructPropertyExpectations(global::IHaveCustomRefStructCreateExpectations expectations) =>
						(this.Getters, this.Setters) = (new(expectations), new(expectations));
					
					internal global::IHaveCustomRefStructCreateExpectations.IHaveCustomRefStructPropertyExpectations.IHaveCustomRefStructPropertyGetterExpectations Getters { get; }
					internal global::IHaveCustomRefStructCreateExpectations.IHaveCustomRefStructPropertyExpectations.IHaveCustomRefStructPropertySetterExpectations Setters { get; }
				}
				
				internal global::IHaveCustomRefStructCreateExpectations.IHaveCustomRefStructMethodExpectations Methods { get; }
				internal global::IHaveCustomRefStructCreateExpectations.IHaveCustomRefStructPropertyExpectations Properties { get; }
				
				internal IHaveCustomRefStructCreateExpectations() =>
					(this.Methods, this.Properties) = (new(this), new(this));
				
				internal global::IHaveCustomRefStruct Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockIHaveCustomRefStruct(this);
						this.MockType = @mock.GetType();
						return @mock;
					}
					else
					{
						throw new global::Rocks.Exceptions.NewMockInstanceException("Can only create a new mock once.");
					}
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IHaveCustomRefStruct_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}
}