﻿using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class AllowNullGeneratorTests
{
	[Test]
	public static async Task GenerateAbstractCreateAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Diagnostics.CodeAnalysis;

			[assembly: RockCreate<MockTests.IAllow>]

			namespace MockTests
			{
				public interface IAllow
				{
					 [AllowNull]
					 string NewLine { get; set; }
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class IAllowCreateExpectations
					: global::Rocks.Expectations
				{
					#pragma warning disable CS8618
					
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Func<string>, string>
					{ }
					
					internal sealed class Handler1
						: global::Rocks.Handler<global::System.Action<string>>
					{
						public global::Rocks.Argument<string> @value { get; set; }
					}
					
					#pragma warning restore CS8618
					
					private global::System.Collections.Generic.List<global::MockTests.IAllowCreateExpectations.Handler0>? @handlers0;
					private global::System.Collections.Generic.List<global::MockTests.IAllowCreateExpectations.Handler1>? @handlers1;
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							if (this.handlers0?.Count > 0) { failures.AddRange(this.Verify(this.handlers0, 0)); }
							if (this.handlers1?.Count > 0) { failures.AddRange(this.Verify(this.handlers1, 1)); }
					
							if (failures.Count > 0)
							{
								throw new global::Rocks.Exceptions.VerificationException(failures);
							}
						}
					}
					
					private sealed class Mock
						: global::MockTests.IAllow
					{
						public Mock(global::MockTests.IAllowCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::System.Diagnostics.CodeAnalysis.AllowNullAttribute]
						[global::Rocks.MemberIdentifier(0, "get_NewLine()")]
						[global::Rocks.MemberIdentifier(1, "set_NewLine(value)")]
						public string NewLine
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
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_NewLine())");
							}
							set
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
												throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_NewLine(value)");
											}
											
											break;
										}
									}
								}
								else
								{
									throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for set_NewLine(value)");
								}
							}
						}
						
						private global::MockTests.IAllowCreateExpectations Expectations { get; }
					}
					internal sealed class PropertyExpectations
					{
						internal sealed class PropertyGetterExpectations
						{
							internal PropertyGetterExpectations(global::MockTests.IAllowCreateExpectations expectations) =>
								this.Expectations = expectations;
							
							internal global::Rocks.Adornments<global::MockTests.IAllowCreateExpectations.Handler0, global::System.Func<string>, string> NewLine()
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
								var handler = new global::MockTests.IAllowCreateExpectations.Handler0();
								this.Expectations.handlers0.Add(handler);
								return new(handler);
							}
							private global::MockTests.IAllowCreateExpectations Expectations { get; }
						}
						
						internal sealed class PropertySetterExpectations
						{
							internal PropertySetterExpectations(global::MockTests.IAllowCreateExpectations expectations) =>
								this.Expectations = expectations;
							
							internal global::Rocks.Adornments<global::MockTests.IAllowCreateExpectations.Handler1, global::System.Action<string>> NewLine(global::Rocks.Argument<string> @value)
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								global::System.ArgumentNullException.ThrowIfNull(@value);
							
								var handler = new global::MockTests.IAllowCreateExpectations.Handler1
								{
									value = @value,
								};
							
								if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(); }
								this.Expectations.handlers1.Add(handler);
								return new(handler);
							}
							private global::MockTests.IAllowCreateExpectations Expectations { get; }
						}
						
						internal PropertyExpectations(global::MockTests.IAllowCreateExpectations expectations) =>
							(this.Getters, this.Setters) = (new(expectations), new(expectations));
						
						internal global::MockTests.IAllowCreateExpectations.PropertyExpectations.PropertyGetterExpectations Getters { get; }
						internal global::MockTests.IAllowCreateExpectations.PropertyExpectations.PropertySetterExpectations Setters { get; }
					}
					
					internal global::MockTests.IAllowCreateExpectations.PropertyExpectations Properties { get; }
					
					internal IAllowCreateExpectations() =>
						(this.Properties) = (new(this));
					
					internal global::MockTests.IAllow Instance()
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
			[(typeof(RockAttributeGenerator), "MockTests.IAllow_Rock_Create.g.cs", generatedCode)],
			[]);
	}

	[Test]
	public static async Task GenerateAbstractMakeAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Diagnostics.CodeAnalysis;

			[assembly: RockMake<MockTests.IAllow>]

			namespace MockTests
			{
				public interface IAllow
				{
					 [AllowNull]
					 string NewLine { get; set; }
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
				internal sealed class IAllowMakeExpectations
				{
					internal global::MockTests.IAllow Instance()
					{
						return new Mock();
					}
					
					private sealed class Mock
						: global::MockTests.IAllow
					{
						public Mock()
						{
						}
						
						[global::System.Diagnostics.CodeAnalysis.AllowNullAttribute]
						public string NewLine
						{
							get => default!;
							set { }
						}
					}
				}
			}
			
			#pragma warning restore CS8775
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			[(typeof(RockAttributeGenerator), "MockTests.IAllow_Rock_Make.g.cs", generatedCode)],
			[]);
	}

	[Test]
	public static async Task GenerateNonAbstractCreateAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Diagnostics.CodeAnalysis;

			[assembly: RockCreate<MockTests.Allow>]

			namespace MockTests
			{
				public class Allow
				{
					 [AllowNull]
					 public virtual string NewLine { get; set; }
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class AllowCreateExpectations
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
						: global::Rocks.Handler<global::System.Func<string>, string>
					{ }
					
					internal sealed class Handler4
						: global::Rocks.Handler<global::System.Action<string>>
					{
						public global::Rocks.Argument<string> @value { get; set; }
					}
					
					#pragma warning restore CS8618
					
					private global::System.Collections.Generic.List<global::MockTests.AllowCreateExpectations.Handler0>? @handlers0;
					private global::System.Collections.Generic.List<global::MockTests.AllowCreateExpectations.Handler1>? @handlers1;
					private global::System.Collections.Generic.List<global::MockTests.AllowCreateExpectations.Handler2>? @handlers2;
					private global::System.Collections.Generic.List<global::MockTests.AllowCreateExpectations.Handler3>? @handlers3;
					private global::System.Collections.Generic.List<global::MockTests.AllowCreateExpectations.Handler4>? @handlers4;
					
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
					
							if (failures.Count > 0)
							{
								throw new global::Rocks.Exceptions.VerificationException(failures);
							}
						}
					}
					
					private sealed class Mock
						: global::MockTests.Allow
					{
						public Mock(global::MockTests.AllowCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
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
						
						[global::System.Diagnostics.CodeAnalysis.AllowNullAttribute]
						[global::Rocks.MemberIdentifier(3, "get_NewLine()")]
						[global::Rocks.MemberIdentifier(4, "set_NewLine(value)")]
						public override string NewLine
						{
							get
							{
								if (this.Expectations.handlers3?.Count > 0)
								{
									var @handler = this.Expectations.handlers3[0];
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback() : @handler.ReturnValue;
									return @result!;
								}
								else
								{
									return base.NewLine;
								}
							}
							set
							{
								if (this.Expectations.handlers4?.Count > 0)
								{
									var @foundMatch = false;
									foreach (var @handler in this.Expectations.handlers4)
									{
										if (@handler.value.IsValid(value!))
										{
											@handler.CallCount++;
											@foundMatch = true;
											@handler.Callback?.Invoke(value!);
											
											if (!@foundMatch)
											{
												throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_NewLine(value)");
											}
											
											break;
										}
									}
								}
								else
								{
									base.NewLine = value!;
								}
							}
						}
						
						private global::MockTests.AllowCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.AllowCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.AllowCreateExpectations.Handler0, global::System.Func<object?, bool>, bool> Equals(global::Rocks.Argument<object?> @obj)
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							global::System.ArgumentNullException.ThrowIfNull(@obj);
							
							var @handler = new global::MockTests.AllowCreateExpectations.Handler0
							{
								@obj = @obj,
							};
							
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
							this.Expectations.handlers0.Add(@handler);
							return new(@handler);
						}
						
						internal new global::Rocks.Adornments<global::MockTests.AllowCreateExpectations.Handler1, global::System.Func<int>, int> GetHashCode()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(); }
							var handler = new global::MockTests.AllowCreateExpectations.Handler1();
							this.Expectations.handlers1.Add(handler);
							return new(handler);
						}
						
						internal new global::Rocks.Adornments<global::MockTests.AllowCreateExpectations.Handler2, global::System.Func<string?>, string?> ToString()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							if (this.Expectations.handlers2 is null ) { this.Expectations.handlers2 = new(); }
							var handler = new global::MockTests.AllowCreateExpectations.Handler2();
							this.Expectations.handlers2.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.AllowCreateExpectations Expectations { get; }
					}
					
					internal sealed class PropertyExpectations
					{
						internal sealed class PropertyGetterExpectations
						{
							internal PropertyGetterExpectations(global::MockTests.AllowCreateExpectations expectations) =>
								this.Expectations = expectations;
							
							internal global::Rocks.Adornments<global::MockTests.AllowCreateExpectations.Handler3, global::System.Func<string>, string> NewLine()
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								if (this.Expectations.handlers3 is null ) { this.Expectations.handlers3 = new(); }
								var handler = new global::MockTests.AllowCreateExpectations.Handler3();
								this.Expectations.handlers3.Add(handler);
								return new(handler);
							}
							private global::MockTests.AllowCreateExpectations Expectations { get; }
						}
						
						internal sealed class PropertySetterExpectations
						{
							internal PropertySetterExpectations(global::MockTests.AllowCreateExpectations expectations) =>
								this.Expectations = expectations;
							
							internal global::Rocks.Adornments<global::MockTests.AllowCreateExpectations.Handler4, global::System.Action<string>> NewLine(global::Rocks.Argument<string> @value)
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								global::System.ArgumentNullException.ThrowIfNull(@value);
							
								var handler = new global::MockTests.AllowCreateExpectations.Handler4
								{
									value = @value,
								};
							
								if (this.Expectations.handlers4 is null ) { this.Expectations.handlers4 = new(); }
								this.Expectations.handlers4.Add(handler);
								return new(handler);
							}
							private global::MockTests.AllowCreateExpectations Expectations { get; }
						}
						
						internal PropertyExpectations(global::MockTests.AllowCreateExpectations expectations) =>
							(this.Getters, this.Setters) = (new(expectations), new(expectations));
						
						internal global::MockTests.AllowCreateExpectations.PropertyExpectations.PropertyGetterExpectations Getters { get; }
						internal global::MockTests.AllowCreateExpectations.PropertyExpectations.PropertySetterExpectations Setters { get; }
					}
					
					internal global::MockTests.AllowCreateExpectations.MethodExpectations Methods { get; }
					internal global::MockTests.AllowCreateExpectations.PropertyExpectations Properties { get; }
					
					internal AllowCreateExpectations() =>
						(this.Methods, this.Properties) = (new(this), new(this));
					
					internal global::MockTests.Allow Instance()
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
			[(typeof(RockAttributeGenerator), "MockTests.Allow_Rock_Create.g.cs", generatedCode)],
			[]);
	}

	[Test]
	public static async Task GenerateNonAbstractMakeAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Diagnostics.CodeAnalysis;

			[assembly: RockMake<MockTests.Allow>]

			namespace MockTests
			{
				public class Allow
				{
					 [AllowNull]
					 public virtual string NewLine { get; set; }
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
				internal sealed class AllowMakeExpectations
				{
					internal global::MockTests.Allow Instance()
					{
						return new Mock();
					}
					
					private sealed class Mock
						: global::MockTests.Allow
					{
						public Mock()
						{
						}
						
						public override bool Equals(object? @obj)
						{
							return default!;
						}
						public override int GetHashCode()
						{
							return default!;
						}
						public override string? ToString()
						{
							return default!;
						}
						[global::System.Diagnostics.CodeAnalysis.AllowNullAttribute]
						public override string NewLine
						{
							get => default!;
							set { }
						}
					}
				}
			}
			
			#pragma warning restore CS8775
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			[(typeof(RockAttributeGenerator), "MockTests.Allow_Rock_Make.g.cs", generatedCode)],
			[]);
	}
}