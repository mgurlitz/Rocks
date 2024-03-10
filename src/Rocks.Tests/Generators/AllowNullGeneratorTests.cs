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
			
			using Rocks.Extensions;
			
			namespace MockTests
			{
				internal sealed class IAllowCreateExpectations
					: global::Rocks.Expectations
				{
					#pragma warning disable CS8618
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Func<string>, string>
					{ }
					private global::Rocks.Handlers<global::MockTests.IAllowCreateExpectations.Handler0>? @handlers0;
					internal sealed class Handler1
						: global::Rocks.Handler<global::System.Action<string>>
					{
						public global::Rocks.Argument<string> @value { get; set; }
					}
					private global::Rocks.Handlers<global::MockTests.IAllowCreateExpectations.Handler1>? @handlers1;
					#pragma warning restore CS8618
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							if (this.handlers0 is not null) { failures.AddRange(this.Verify(this.handlers0, 0)); }
							if (this.handlers1 is not null) { failures.AddRange(this.Verify(this.handlers1, 1)); }
					
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
						[global::Rocks.MemberIdentifier(0, global::Rocks.PropertyAccessor.Get)]
						[global::Rocks.MemberIdentifier(1, global::Rocks.PropertyAccessor.Set)]
						public string NewLine
						{
							get
							{
								if (this.Expectations.handlers0 is not null)
								{
									var @handler = this.Expectations.handlers0.First;
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback() : @handler.ReturnValue;
									return @result!;
								}
								
								throw new global::Rocks.Exceptions.ExpectationException($"No handlers were found for {this.GetType().GetMemberDescription(0)})");
							}
							set
							{
								if (this.Expectations.handlers1 is not null)
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
												throw new global::Rocks.Exceptions.ExpectationException($"No handlers match for {this.GetType().GetMemberDescription(1)}");
											}
											
											break;
										}
									}
								}
								else
								{
									throw new global::Rocks.Exceptions.ExpectationException($"No handlers were found for {this.GetType().GetMemberDescription(1)}");
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
							
							internal global::MockTests.IAllowCreateExpectations.Adornments.AdornmentsForHandler0 NewLine()
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								var handler = new global::MockTests.IAllowCreateExpectations.Handler0();
								if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(handler); }
								else { this.Expectations.handlers0.Add(handler); }
								return new(handler);
							}
							private global::MockTests.IAllowCreateExpectations Expectations { get; }
						}
						
						internal sealed class PropertySetterExpectations
						{
							internal PropertySetterExpectations(global::MockTests.IAllowCreateExpectations expectations) =>
								this.Expectations = expectations;
							
							internal global::MockTests.IAllowCreateExpectations.Adornments.AdornmentsForHandler1 NewLine(global::Rocks.Argument<string> @value)
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								global::System.ArgumentNullException.ThrowIfNull(@value);
							
								var handler = new global::MockTests.IAllowCreateExpectations.Handler1
								{
									value = @value,
								};
							
								if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(handler); }
								else { this.Expectations.handlers1.Add(handler); }
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
					
					internal static class Adornments
					{
						public interface IAdornmentsForIAllow<TAdornments>
							: global::Rocks.IAdornments<TAdornments>
							where TAdornments : IAdornmentsForIAllow<TAdornments>
						{ }
						
						public sealed class AdornmentsForHandler0
							: global::Rocks.Adornments<AdornmentsForHandler0, global::MockTests.IAllowCreateExpectations.Handler0, global::System.Func<string>, string>, IAdornmentsForIAllow<AdornmentsForHandler0>
						{ 
							public AdornmentsForHandler0(global::MockTests.IAllowCreateExpectations.Handler0 handler)
								: base(handler) { }				
						}
						public sealed class AdornmentsForHandler1
							: global::Rocks.Adornments<AdornmentsForHandler1, global::MockTests.IAllowCreateExpectations.Handler1, global::System.Action<string>>, IAdornmentsForIAllow<AdornmentsForHandler1>
						{ 
							public AdornmentsForHandler1(global::MockTests.IAllowCreateExpectations.Handler1 handler)
								: base(handler) { }				
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
			
			using Rocks.Extensions;
			
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
					private global::Rocks.Handlers<global::MockTests.AllowCreateExpectations.Handler0>? @handlers0;
					internal sealed class Handler1
						: global::Rocks.Handler<global::System.Func<int>, int>
					{ }
					private global::Rocks.Handlers<global::MockTests.AllowCreateExpectations.Handler1>? @handlers1;
					internal sealed class Handler2
						: global::Rocks.Handler<global::System.Func<string?>, string?>
					{ }
					private global::Rocks.Handlers<global::MockTests.AllowCreateExpectations.Handler2>? @handlers2;
					internal sealed class Handler3
						: global::Rocks.Handler<global::System.Func<string>, string>
					{ }
					private global::Rocks.Handlers<global::MockTests.AllowCreateExpectations.Handler3>? @handlers3;
					internal sealed class Handler4
						: global::Rocks.Handler<global::System.Action<string>>
					{
						public global::Rocks.Argument<string> @value { get; set; }
					}
					private global::Rocks.Handlers<global::MockTests.AllowCreateExpectations.Handler4>? @handlers4;
					#pragma warning restore CS8618
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							if (this.handlers0 is not null) { failures.AddRange(this.Verify(this.handlers0, 0)); }
							if (this.handlers1 is not null) { failures.AddRange(this.Verify(this.handlers1, 1)); }
							if (this.handlers2 is not null) { failures.AddRange(this.Verify(this.handlers2, 2)); }
							if (this.handlers3 is not null) { failures.AddRange(this.Verify(this.handlers3, 3)); }
							if (this.handlers4 is not null) { failures.AddRange(this.Verify(this.handlers4, 4)); }
					
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
						
						[global::Rocks.MemberIdentifier(0)]
						public override bool Equals(object? @obj)
						{
							if (this.Expectations.handlers0 is not null)
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
								
								throw new global::Rocks.Exceptions.ExpectationException($"No handlers match for {this.GetType().GetMemberDescription(0)}");
							}
							else
							{
								return base.Equals(obj: @obj!);
							}
						}
						
						[global::Rocks.MemberIdentifier(1)]
						public override int GetHashCode()
						{
							if (this.Expectations.handlers1 is not null)
							{
								var @handler = this.Expectations.handlers1.First;
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
						
						[global::Rocks.MemberIdentifier(2)]
						public override string? ToString()
						{
							if (this.Expectations.handlers2 is not null)
							{
								var @handler = this.Expectations.handlers2.First;
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
						[global::Rocks.MemberIdentifier(3, global::Rocks.PropertyAccessor.Get)]
						[global::Rocks.MemberIdentifier(4, global::Rocks.PropertyAccessor.Set)]
						public override string NewLine
						{
							get
							{
								if (this.Expectations.handlers3 is not null)
								{
									var @handler = this.Expectations.handlers3.First;
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
								if (this.Expectations.handlers4 is not null)
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
												throw new global::Rocks.Exceptions.ExpectationException($"No handlers match for {this.GetType().GetMemberDescription(4)}");
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
						
						internal global::MockTests.AllowCreateExpectations.Adornments.AdornmentsForHandler0 Equals(global::Rocks.Argument<object?> @obj)
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							global::System.ArgumentNullException.ThrowIfNull(@obj);
							
							var @handler = new global::MockTests.AllowCreateExpectations.Handler0
							{
								@obj = @obj,
							};
							
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(@handler); }
							else { this.Expectations.handlers0.Add(@handler); }
							return new(@handler);
						}
						
						internal new global::MockTests.AllowCreateExpectations.Adornments.AdornmentsForHandler1 GetHashCode()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							var handler = new global::MockTests.AllowCreateExpectations.Handler1();
							if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(handler); }
							else { this.Expectations.handlers1.Add(handler); }
							return new(handler);
						}
						
						internal new global::MockTests.AllowCreateExpectations.Adornments.AdornmentsForHandler2 ToString()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							var handler = new global::MockTests.AllowCreateExpectations.Handler2();
							if (this.Expectations.handlers2 is null ) { this.Expectations.handlers2 = new(handler); }
							else { this.Expectations.handlers2.Add(handler); }
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
							
							internal global::MockTests.AllowCreateExpectations.Adornments.AdornmentsForHandler3 NewLine()
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								var handler = new global::MockTests.AllowCreateExpectations.Handler3();
								if (this.Expectations.handlers3 is null ) { this.Expectations.handlers3 = new(handler); }
								else { this.Expectations.handlers3.Add(handler); }
								return new(handler);
							}
							private global::MockTests.AllowCreateExpectations Expectations { get; }
						}
						
						internal sealed class PropertySetterExpectations
						{
							internal PropertySetterExpectations(global::MockTests.AllowCreateExpectations expectations) =>
								this.Expectations = expectations;
							
							internal global::MockTests.AllowCreateExpectations.Adornments.AdornmentsForHandler4 NewLine(global::Rocks.Argument<string> @value)
							{
								global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
								global::System.ArgumentNullException.ThrowIfNull(@value);
							
								var handler = new global::MockTests.AllowCreateExpectations.Handler4
								{
									value = @value,
								};
							
								if (this.Expectations.handlers4 is null ) { this.Expectations.handlers4 = new(handler); }
								else { this.Expectations.handlers4.Add(handler); }
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
					
					internal static class Adornments
					{
						public interface IAdornmentsForAllow<TAdornments>
							: global::Rocks.IAdornments<TAdornments>
							where TAdornments : IAdornmentsForAllow<TAdornments>
						{ }
						
						public sealed class AdornmentsForHandler0
							: global::Rocks.Adornments<AdornmentsForHandler0, global::MockTests.AllowCreateExpectations.Handler0, global::System.Func<object?, bool>, bool>, IAdornmentsForAllow<AdornmentsForHandler0>
						{ 
							public AdornmentsForHandler0(global::MockTests.AllowCreateExpectations.Handler0 handler)
								: base(handler) { }				
						}
						public sealed class AdornmentsForHandler1
							: global::Rocks.Adornments<AdornmentsForHandler1, global::MockTests.AllowCreateExpectations.Handler1, global::System.Func<int>, int>, IAdornmentsForAllow<AdornmentsForHandler1>
						{ 
							public AdornmentsForHandler1(global::MockTests.AllowCreateExpectations.Handler1 handler)
								: base(handler) { }				
						}
						public sealed class AdornmentsForHandler2
							: global::Rocks.Adornments<AdornmentsForHandler2, global::MockTests.AllowCreateExpectations.Handler2, global::System.Func<string?>, string?>, IAdornmentsForAllow<AdornmentsForHandler2>
						{ 
							public AdornmentsForHandler2(global::MockTests.AllowCreateExpectations.Handler2 handler)
								: base(handler) { }				
						}
						public sealed class AdornmentsForHandler3
							: global::Rocks.Adornments<AdornmentsForHandler3, global::MockTests.AllowCreateExpectations.Handler3, global::System.Func<string>, string>, IAdornmentsForAllow<AdornmentsForHandler3>
						{ 
							public AdornmentsForHandler3(global::MockTests.AllowCreateExpectations.Handler3 handler)
								: base(handler) { }				
						}
						public sealed class AdornmentsForHandler4
							: global::Rocks.Adornments<AdornmentsForHandler4, global::MockTests.AllowCreateExpectations.Handler4, global::System.Action<string>>, IAdornmentsForAllow<AdornmentsForHandler4>
						{ 
							public AdornmentsForHandler4(global::MockTests.AllowCreateExpectations.Handler4 handler)
								: base(handler) { }				
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