﻿using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class PropertyInitCreateGeneratorTests
{
	[Test]
	public static async Task GenerateWithInitAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<MockTests.ITest>]

			#nullable enable

			namespace MockTests
			{
				public interface ITest
				{
					int NonNullableValueType { get; init; }
					int? NullableValueType { get; init; }
					string NonNullableReferenceType { get; init; }
					string? NullableReferenceType { get; init; }
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class ITestCreateExpectations
					: global::Rocks.Expectations
				{
					#pragma warning disable CS8618
					
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Func<int>, int>
					{ }
					
					internal sealed class Handler1
						: global::Rocks.Handler<global::System.Action<int>>
					{
						public global::Rocks.Argument<int> @value { get; set; }
					}
					
					internal sealed class Handler2
						: global::Rocks.Handler<global::System.Func<int?>, int?>
					{ }
					
					internal sealed class Handler3
						: global::Rocks.Handler<global::System.Action<int?>>
					{
						public global::Rocks.Argument<int?> @value { get; set; }
					}
					
					internal sealed class Handler4
						: global::Rocks.Handler<global::System.Func<string>, string>
					{ }
					
					internal sealed class Handler5
						: global::Rocks.Handler<global::System.Action<string>>
					{
						public global::Rocks.Argument<string> @value { get; set; }
					}
					
					internal sealed class Handler6
						: global::Rocks.Handler<global::System.Func<string?>, string?>
					{ }
					
					internal sealed class Handler7
						: global::Rocks.Handler<global::System.Action<string?>>
					{
						public global::Rocks.Argument<string?> @value { get; set; }
					}
					
					#pragma warning restore CS8618
					
					private global::System.Collections.Generic.List<global::MockTests.ITestCreateExpectations.Handler0>? @handlers0;
					private global::System.Collections.Generic.List<global::MockTests.ITestCreateExpectations.Handler1>? @handlers1;
					private global::System.Collections.Generic.List<global::MockTests.ITestCreateExpectations.Handler2>? @handlers2;
					private global::System.Collections.Generic.List<global::MockTests.ITestCreateExpectations.Handler3>? @handlers3;
					private global::System.Collections.Generic.List<global::MockTests.ITestCreateExpectations.Handler4>? @handlers4;
					private global::System.Collections.Generic.List<global::MockTests.ITestCreateExpectations.Handler5>? @handlers5;
					private global::System.Collections.Generic.List<global::MockTests.ITestCreateExpectations.Handler6>? @handlers6;
					private global::System.Collections.Generic.List<global::MockTests.ITestCreateExpectations.Handler7>? @handlers7;
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							if (this.handlers0?.Count > 0) { failures.AddRange(this.Verify(this.handlers0, 0)); }
							if (this.handlers1?.Count > 0) { failures.AddRange(this.Verify(this.handlers1, 1)); }
							if (this.handlers2?.Count > 0) { failures.AddRange(this.Verify(this.handlers2, 2)); }
							if (this.handlers3?.Count > 0) { failures.AddRange(this.Verify(this.handlers3, 3)); }
							if (this.handlers4?.Count > 0) { failures.AddRange(this.Verify(this.handlers4, 4)); }
							if (this.handlers5?.Count > 0) { failures.AddRange(this.Verify(this.handlers5, 5)); }
							if (this.handlers6?.Count > 0) { failures.AddRange(this.Verify(this.handlers6, 6)); }
							if (this.handlers7?.Count > 0) { failures.AddRange(this.Verify(this.handlers7, 7)); }
					
							if (failures.Count > 0)
							{
								throw new global::Rocks.Exceptions.VerificationException(failures);
							}
						}
					}
					
					private sealed class Mock
						: global::MockTests.ITest
					{
						public Mock(global::MockTests.ITestCreateExpectations @expectations, ConstructorProperties? @constructorProperties)
						{
							this.Expectations = @expectations;
							if (@constructorProperties is not null)
							{
								this.NonNullableValueType = @constructorProperties.NonNullableValueType;
								this.NullableValueType = @constructorProperties.NullableValueType;
								this.NonNullableReferenceType = @constructorProperties.NonNullableReferenceType!;
								this.NullableReferenceType = @constructorProperties.NullableReferenceType;
							}
						}
						
						[global::Rocks.MemberIdentifier(0, "get_NonNullableValueType()")]
						[global::Rocks.MemberIdentifier(1, "set_NonNullableValueType(value)")]
						public int NonNullableValueType
						{
							get
							{
								if (this.Expectations.handlers0?.Count > 0)
								{
									var @handler = this.Expectations.handlers0[0];
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback() : @handler.ReturnValue;
									return @result!;
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_NonNullableValueType())");
							}
							init
							{
								if (this.Expectations.handlers1?.Count > 0)
								{
									var @foundMatch = false;
									foreach (var @handler in this.Expectations.handlers1)
									{
										if (@handler.value.IsValid(value!))
										{
											@handler.CallCount++;
											@foundMatch = true;
											@handler.Callback?.Invoke(value!);
											
											if (!@foundMatch)
											{
												throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_NonNullableValueType(value)");
											}
											
											break;
										}
									}
								}
								else
								{
									throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for set_NonNullableValueType(value)");
								}
							}
						}
						[global::Rocks.MemberIdentifier(2, "get_NullableValueType()")]
						[global::Rocks.MemberIdentifier(3, "set_NullableValueType(value)")]
						public int? NullableValueType
						{
							get
							{
								if (this.Expectations.handlers2?.Count > 0)
								{
									var @handler = this.Expectations.handlers2[0];
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback() : @handler.ReturnValue;
									return @result!;
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_NullableValueType())");
							}
							init
							{
								if (this.Expectations.handlers3?.Count > 0)
								{
									var @foundMatch = false;
									foreach (var @handler in this.Expectations.handlers3)
									{
										if (@handler.value.IsValid(value!))
										{
											@handler.CallCount++;
											@foundMatch = true;
											@handler.Callback?.Invoke(value!);
											
											if (!@foundMatch)
											{
												throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_NullableValueType(value)");
											}
											
											break;
										}
									}
								}
								else
								{
									throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for set_NullableValueType(value)");
								}
							}
						}
						[global::Rocks.MemberIdentifier(4, "get_NonNullableReferenceType()")]
						[global::Rocks.MemberIdentifier(5, "set_NonNullableReferenceType(value)")]
						public string NonNullableReferenceType
						{
							get
							{
								if (this.Expectations.handlers4?.Count > 0)
								{
									var @handler = this.Expectations.handlers4[0];
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback() : @handler.ReturnValue;
									return @result!;
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_NonNullableReferenceType())");
							}
							init
							{
								if (this.Expectations.handlers5?.Count > 0)
								{
									var @foundMatch = false;
									foreach (var @handler in this.Expectations.handlers5)
									{
										if (@handler.value.IsValid(value!))
										{
											@handler.CallCount++;
											@foundMatch = true;
											@handler.Callback?.Invoke(value!);
											
											if (!@foundMatch)
											{
												throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_NonNullableReferenceType(value)");
											}
											
											break;
										}
									}
								}
								else
								{
									throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for set_NonNullableReferenceType(value)");
								}
							}
						}
						[global::Rocks.MemberIdentifier(6, "get_NullableReferenceType()")]
						[global::Rocks.MemberIdentifier(7, "set_NullableReferenceType(value)")]
						public string? NullableReferenceType
						{
							get
							{
								if (this.Expectations.handlers6?.Count > 0)
								{
									var @handler = this.Expectations.handlers6[0];
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback() : @handler.ReturnValue;
									return @result!;
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_NullableReferenceType())");
							}
							init
							{
								if (this.Expectations.handlers7?.Count > 0)
								{
									var @foundMatch = false;
									foreach (var @handler in this.Expectations.handlers7)
									{
										if (@handler.value.IsValid(value!))
										{
											@handler.CallCount++;
											@foundMatch = true;
											@handler.Callback?.Invoke(value!);
											
											if (!@foundMatch)
											{
												throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_NullableReferenceType(value)");
											}
											
											break;
										}
									}
								}
								else
								{
									throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for set_NullableReferenceType(value)");
								}
							}
						}
						
						private global::MockTests.ITestCreateExpectations Expectations { get; }
					}
					internal sealed class PropertyExpectations
					{
						internal sealed class PropertyGetterExpectations
						{
							internal PropertyGetterExpectations(global::MockTests.ITestCreateExpectations expectations) =>
								this.Expectations = expectations;
							
							internal global::Rocks.Adornments<global::MockTests.ITestCreateExpectations.Handler0, global::System.Func<int>, int> NonNullableValueType()
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
								var handler = new global::MockTests.ITestCreateExpectations.Handler0();
								this.Expectations.handlers0.Add(handler);
								return new(handler);
							}
							internal global::Rocks.Adornments<global::MockTests.ITestCreateExpectations.Handler2, global::System.Func<int?>, int?> NullableValueType()
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								if (this.Expectations.handlers2 is null ) { this.Expectations.handlers2 = new(); }
								var handler = new global::MockTests.ITestCreateExpectations.Handler2();
								this.Expectations.handlers2.Add(handler);
								return new(handler);
							}
							internal global::Rocks.Adornments<global::MockTests.ITestCreateExpectations.Handler4, global::System.Func<string>, string> NonNullableReferenceType()
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								if (this.Expectations.handlers4 is null ) { this.Expectations.handlers4 = new(); }
								var handler = new global::MockTests.ITestCreateExpectations.Handler4();
								this.Expectations.handlers4.Add(handler);
								return new(handler);
							}
							internal global::Rocks.Adornments<global::MockTests.ITestCreateExpectations.Handler6, global::System.Func<string?>, string?> NullableReferenceType()
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								if (this.Expectations.handlers6 is null ) { this.Expectations.handlers6 = new(); }
								var handler = new global::MockTests.ITestCreateExpectations.Handler6();
								this.Expectations.handlers6.Add(handler);
								return new(handler);
							}
							private global::MockTests.ITestCreateExpectations Expectations { get; }
						}
						
						internal sealed class PropertyInitializerExpectations
						{
							internal PropertyInitializerExpectations(global::MockTests.ITestCreateExpectations expectations) =>
								this.Expectations = expectations;
							
							internal global::Rocks.Adornments<global::MockTests.ITestCreateExpectations.Handler1, global::System.Action<int>> NonNullableValueType(global::Rocks.Argument<int> @value)
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								global::System.ArgumentNullException.ThrowIfNull(@value);
							
								var handler = new global::MockTests.ITestCreateExpectations.Handler1
								{
									value = @value,
								};
							
								if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(); }
								this.Expectations.handlers1.Add(handler);
								return new(handler);
							}
							internal global::Rocks.Adornments<global::MockTests.ITestCreateExpectations.Handler3, global::System.Action<int?>> NullableValueType(global::Rocks.Argument<int?> @value)
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								global::System.ArgumentNullException.ThrowIfNull(@value);
							
								var handler = new global::MockTests.ITestCreateExpectations.Handler3
								{
									value = @value,
								};
							
								if (this.Expectations.handlers3 is null ) { this.Expectations.handlers3 = new(); }
								this.Expectations.handlers3.Add(handler);
								return new(handler);
							}
							internal global::Rocks.Adornments<global::MockTests.ITestCreateExpectations.Handler5, global::System.Action<string>> NonNullableReferenceType(global::Rocks.Argument<string> @value)
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								global::System.ArgumentNullException.ThrowIfNull(@value);
							
								var handler = new global::MockTests.ITestCreateExpectations.Handler5
								{
									value = @value,
								};
							
								if (this.Expectations.handlers5 is null ) { this.Expectations.handlers5 = new(); }
								this.Expectations.handlers5.Add(handler);
								return new(handler);
							}
							internal global::Rocks.Adornments<global::MockTests.ITestCreateExpectations.Handler7, global::System.Action<string?>> NullableReferenceType(global::Rocks.Argument<string?> @value)
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								global::System.ArgumentNullException.ThrowIfNull(@value);
							
								var handler = new global::MockTests.ITestCreateExpectations.Handler7
								{
									value = @value,
								};
							
								if (this.Expectations.handlers7 is null ) { this.Expectations.handlers7 = new(); }
								this.Expectations.handlers7.Add(handler);
								return new(handler);
							}
							private global::MockTests.ITestCreateExpectations Expectations { get; }
						}
						
						internal PropertyExpectations(global::MockTests.ITestCreateExpectations expectations) =>
							(this.Getters, this.Initializers) = (new(expectations), new(expectations));
						
						internal global::MockTests.ITestCreateExpectations.PropertyExpectations.PropertyGetterExpectations Getters { get; }
						internal global::MockTests.ITestCreateExpectations.PropertyExpectations.PropertyInitializerExpectations Initializers { get; }
					}
					
					internal global::MockTests.ITestCreateExpectations.PropertyExpectations Properties { get; }
					
					internal ITestCreateExpectations() =>
						(this.Properties) = (new(this));
					
					internal sealed class ConstructorProperties
					{
						internal int NonNullableValueType { get; init; }
						internal int? NullableValueType { get; init; }
						internal string? NonNullableReferenceType { get; init; }
						internal string? NullableReferenceType { get; init; }
					}
					
					internal global::MockTests.ITest Instance(global::MockTests.ITestCreateExpectations.ConstructorProperties? @constructorProperties)
					{
						if (!this.WasInstanceInvoked)
						{
							this.WasInstanceInvoked = true;
							var @mock = new Mock(this, @constructorProperties);
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
			new[] { (typeof(RockAttributeGenerator), "MockTests.ITest_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateWithRequiredAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<MockTests.Test>]

			#nullable enable

			namespace MockTests
			{
				public class Test
				{
					public virtual void Foo() { }
					public required string? Data { get; set; }
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class TestCreateExpectations
					: global::Rocks.Expectations
				{
					#pragma warning disable CS8618
					
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Func<object?, bool>, bool>
					{
						public global::Rocks.Argument<object?> @obj { get; set; }
					}
					
					internal sealed class Handler1
						: global::Rocks.Handler<global::System.Func<int>, int>
					{ }
					
					internal sealed class Handler2
						: global::Rocks.Handler<global::System.Func<string?>, string?>
					{ }
					
					internal sealed class Handler3
						: global::Rocks.Handler<global::System.Action>
					{ }
					
					#pragma warning restore CS8618
					
					private global::System.Collections.Generic.List<global::MockTests.TestCreateExpectations.Handler0>? @handlers0;
					private global::System.Collections.Generic.List<global::MockTests.TestCreateExpectations.Handler1>? @handlers1;
					private global::System.Collections.Generic.List<global::MockTests.TestCreateExpectations.Handler2>? @handlers2;
					private global::System.Collections.Generic.List<global::MockTests.TestCreateExpectations.Handler3>? @handlers3;
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							if (this.handlers0?.Count > 0) { failures.AddRange(this.Verify(this.handlers0, 0)); }
							if (this.handlers1?.Count > 0) { failures.AddRange(this.Verify(this.handlers1, 1)); }
							if (this.handlers2?.Count > 0) { failures.AddRange(this.Verify(this.handlers2, 2)); }
							if (this.handlers3?.Count > 0) { failures.AddRange(this.Verify(this.handlers3, 3)); }
					
							if (failures.Count > 0)
							{
								throw new global::Rocks.Exceptions.VerificationException(failures);
							}
						}
					}
					
					private sealed class Mock
						: global::MockTests.Test
					{
						[global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
						public Mock(global::MockTests.TestCreateExpectations @expectations, ConstructorProperties @constructorProperties)
						{
							this.Expectations = @expectations;
							this.Data = @constructorProperties.Data;
						}
						
						[global::Rocks.MemberIdentifier(0, "bool Equals(object? @obj)")]
						public override bool Equals(object? @obj)
						{
							if (this.Expectations.handlers0?.Count > 0)
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
							if (this.Expectations.handlers1?.Count > 0)
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
							if (this.Expectations.handlers2?.Count > 0)
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
						
						[global::Rocks.MemberIdentifier(3, "void Foo()")]
						public override void Foo()
						{
							if (this.Expectations.handlers3?.Count > 0)
							{
								var @handler = this.Expectations.handlers3[0];
								@handler.CallCount++;
								@handler.Callback?.Invoke();
							}
							else
							{
								base.Foo();
							}
						}
						
						private global::MockTests.TestCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.TestCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.TestCreateExpectations.Handler0, global::System.Func<object?, bool>, bool> Equals(global::Rocks.Argument<object?> @obj)
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							global::System.ArgumentNullException.ThrowIfNull(@obj);
							
							var handler = new global::MockTests.TestCreateExpectations.Handler0
							{
								@obj = @obj,
							};
							
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						internal new global::Rocks.Adornments<global::MockTests.TestCreateExpectations.Handler1, global::System.Func<int>, int> GetHashCode()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(); }
							var handler = new global::MockTests.TestCreateExpectations.Handler1();
							this.Expectations.handlers1.Add(handler);
							return new(handler);
						}
						
						internal new global::Rocks.Adornments<global::MockTests.TestCreateExpectations.Handler2, global::System.Func<string?>, string?> ToString()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							if (this.Expectations.handlers2 is null ) { this.Expectations.handlers2 = new(); }
							var handler = new global::MockTests.TestCreateExpectations.Handler2();
							this.Expectations.handlers2.Add(handler);
							return new(handler);
						}
						
						internal global::Rocks.Adornments<global::MockTests.TestCreateExpectations.Handler3, global::System.Action> Foo()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							if (this.Expectations.handlers3 is null ) { this.Expectations.handlers3 = new(); }
							var handler = new global::MockTests.TestCreateExpectations.Handler3();
							this.Expectations.handlers3.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.TestCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.TestCreateExpectations.MethodExpectations Methods { get; }
					
					internal TestCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal sealed class ConstructorProperties
					{
						internal required string? Data { get; init; }
					}
					
					internal global::MockTests.Test Instance(global::MockTests.TestCreateExpectations.ConstructorProperties @constructorProperties)
					{
						if (@constructorProperties is null)
						{
							throw new global::System.ArgumentNullException(nameof(@constructorProperties));
						}
						if (!this.WasInstanceInvoked)
						{
							this.WasInstanceInvoked = true;
							var @mock = new Mock(this, @constructorProperties);
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
			new[] { (typeof(RockAttributeGenerator), "MockTests.Test_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}
}