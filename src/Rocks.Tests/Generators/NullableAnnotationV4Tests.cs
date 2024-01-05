﻿using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class NullableAnnotationV4Tests
{
	[Test]
	public static async Task GenerateWhenNullableIsInTypeAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<IType<int?>>]

			#nullable enable

			public interface IType<T>
			{
				void Foo(T value);
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal sealed class ITypeOfNullableOfintCreateExpectations
				: global::Rocks.Expectations.ExpectationsV4
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.HandlerV4<global::System.Action<int?>>
				{
					public global::Rocks.Argument<int?> @value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::ITypeOfNullableOfintCreateExpectations.Handler0> @handlers0 = new();
				
				public override void Verify()
				{
					if (this.WasInstanceInvoked)
					{
						var failures = new global::System.Collections.Generic.List<string>();
				
						failures.AddRange(this.Verify(handlers0));
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class RockITypeOfNullableOfint
					: global::IType<int?>
				{
					public RockITypeOfNullableOfint(global::ITypeOfNullableOfintCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "void Foo(int? @value)")]
					public void Foo(int? @value)
					{
						if (this.Expectations.handlers0.Count > 0)
						{
							var @foundMatch = false;
							
							foreach (var @handler in this.Expectations.handlers0)
							{
								if (@handler.@value.IsValid(@value!))
								{
									@foundMatch = true;
									@handler.CallCount++;
									@handler.Callback?.Invoke(@value!);
									break;
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void Foo(int? @value)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Foo(int? @value)");
						}
					}
					
					private global::ITypeOfNullableOfintCreateExpectations Expectations { get; }
				}
				
				internal sealed class ITypeOfNullableOfintMethodExpectations
				{
					internal ITypeOfNullableOfintMethodExpectations(global::ITypeOfNullableOfintCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::ITypeOfNullableOfintCreateExpectations.Handler0, global::System.Action<int?>> Foo(global::Rocks.Argument<int?> @value)
					{
						global::System.ArgumentNullException.ThrowIfNull(@value);
						
						var handler = new global::ITypeOfNullableOfintCreateExpectations.Handler0
						{
							@value = @value,
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					private global::ITypeOfNullableOfintCreateExpectations Expectations { get; }
				}
				
				internal global::ITypeOfNullableOfintCreateExpectations.ITypeOfNullableOfintMethodExpectations Methods { get; }
				
				internal ITypeOfNullableOfintCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::IType<int?> Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockITypeOfNullableOfint(this);
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
			new[] { (typeof(RockAttributeGenerator), "ITypeint_null__Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateCreateWithConstructorWhenParameterWithNullDefaultIsNotAnnotatedAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<NeedNullable>]

			public class NeedNullable
			{
				public NeedNullable(object initializationData = null) { }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal sealed class NeedNullableCreateExpectations
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
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::NeedNullableCreateExpectations.Handler0> @handlers0 = new();
				private readonly global::System.Collections.Generic.List<global::NeedNullableCreateExpectations.Handler1> @handlers1 = new();
				private readonly global::System.Collections.Generic.List<global::NeedNullableCreateExpectations.Handler2> @handlers2 = new();
				
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
				
				private sealed class RockNeedNullable
					: global::NeedNullable
				{
					public RockNeedNullable(global::NeedNullableCreateExpectations @expectations, object? @initializationData)
						: base(@initializationData!)
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
					
					private global::NeedNullableCreateExpectations Expectations { get; }
				}
				
				internal sealed class NeedNullableMethodExpectations
				{
					internal NeedNullableMethodExpectations(global::NeedNullableCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::NeedNullableCreateExpectations.Handler0, global::System.Func<object?, bool>, bool> Equals(global::Rocks.Argument<object?> @obj)
					{
						global::System.ArgumentNullException.ThrowIfNull(@obj);
						
						var handler = new global::NeedNullableCreateExpectations.Handler0
						{
							@obj = @obj,
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					internal new global::Rocks.AdornmentsV4<global::NeedNullableCreateExpectations.Handler1, global::System.Func<int>, int> GetHashCode()
					{
						var handler = new global::NeedNullableCreateExpectations.Handler1();
						this.Expectations.handlers1.Add(handler);
						return new(handler);
					}
					
					internal new global::Rocks.AdornmentsV4<global::NeedNullableCreateExpectations.Handler2, global::System.Func<string?>, string?> ToString()
					{
						var handler = new global::NeedNullableCreateExpectations.Handler2();
						this.Expectations.handlers2.Add(handler);
						return new(handler);
					}
					
					private global::NeedNullableCreateExpectations Expectations { get; }
				}
				
				internal global::NeedNullableCreateExpectations.NeedNullableMethodExpectations Methods { get; }
				
				internal NeedNullableCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::NeedNullable Instance(object? @initializationData)
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockNeedNullable(this, @initializationData!);
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
			new[] { (typeof(RockAttributeGenerator), "NeedNullable_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateMakeWithConstructorWhenParameterWithNullDefaultIsNotAnnotatedAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockMake<NeedNullable>]

			public class NeedNullable
			{
				public NeedNullable(object initializationData = null) { }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class NeedNullableMakeExpectations
			{
				internal global::NeedNullable Instance(object? @initializationData)
				{
					return new RockNeedNullable(@initializationData!);
				}
				
				private sealed class RockNeedNullable
					: global::NeedNullable
				{
					public RockNeedNullable(object? @initializationData)
						: base(@initializationData!)
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
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "NeedNullable_Rock_Make.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateCreateWithMethodsWhenParameterWithNullDefaultIsNotAnnotatedAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<NeedNullable>]

			public class NeedNullable
			{
			    public virtual int IntReturn(object initializationData = null) => 0;
			    public virtual void VoidReturn(object initializationData = null) { }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal sealed class NeedNullableCreateExpectations
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
				
				internal sealed class Handler3
					: global::Rocks.HandlerV4<global::System.Func<object?, int>, int>
				{
					public global::Rocks.Argument<object?> @initializationData { get; set; }
				}
				
				internal sealed class Handler4
					: global::Rocks.HandlerV4<global::System.Action<object?>>
				{
					public global::Rocks.Argument<object?> @initializationData { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::NeedNullableCreateExpectations.Handler0> @handlers0 = new();
				private readonly global::System.Collections.Generic.List<global::NeedNullableCreateExpectations.Handler1> @handlers1 = new();
				private readonly global::System.Collections.Generic.List<global::NeedNullableCreateExpectations.Handler2> @handlers2 = new();
				private readonly global::System.Collections.Generic.List<global::NeedNullableCreateExpectations.Handler3> @handlers3 = new();
				private readonly global::System.Collections.Generic.List<global::NeedNullableCreateExpectations.Handler4> @handlers4 = new();
				
				public override void Verify()
				{
					if (this.WasInstanceInvoked)
					{
						var failures = new global::System.Collections.Generic.List<string>();
				
						failures.AddRange(this.Verify(handlers0));
						failures.AddRange(this.Verify(handlers1));
						failures.AddRange(this.Verify(handlers2));
						failures.AddRange(this.Verify(handlers3));
						failures.AddRange(this.Verify(handlers4));
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class RockNeedNullable
					: global::NeedNullable
				{
					public RockNeedNullable(global::NeedNullableCreateExpectations @expectations)
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
					
					[global::Rocks.MemberIdentifier(3, "int IntReturn(object? @initializationData)")]
					public override int IntReturn(object? @initializationData = null)
					{
						if (this.Expectations.handlers3.Count > 0)
						{
							foreach (var @handler in this.Expectations.handlers3)
							{
								if (@handler.@initializationData.IsValid(@initializationData!))
								{
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback(@initializationData!) : @handler.ReturnValue;
									return @result!;
								}
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers match for int IntReturn(object? @initializationData = null)");
						}
						else
						{
							return base.IntReturn(initializationData: @initializationData!);
						}
					}
					
					[global::Rocks.MemberIdentifier(4, "void VoidReturn(object? @initializationData)")]
					public override void VoidReturn(object? @initializationData = null)
					{
						if (this.Expectations.handlers4.Count > 0)
						{
							var @foundMatch = false;
							
							foreach (var @handler in this.Expectations.handlers4)
							{
								if (@handler.@initializationData.IsValid(@initializationData!))
								{
									@foundMatch = true;
									@handler.CallCount++;
									@handler.Callback?.Invoke(@initializationData!);
									break;
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void VoidReturn(object? @initializationData = null)");
							}
						}
						else
						{
							base.VoidReturn(initializationData: @initializationData!);
						}
					}
					
					private global::NeedNullableCreateExpectations Expectations { get; }
				}
				
				internal sealed class NeedNullableMethodExpectations
				{
					internal NeedNullableMethodExpectations(global::NeedNullableCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::NeedNullableCreateExpectations.Handler0, global::System.Func<object?, bool>, bool> Equals(global::Rocks.Argument<object?> @obj)
					{
						global::System.ArgumentNullException.ThrowIfNull(@obj);
						
						var handler = new global::NeedNullableCreateExpectations.Handler0
						{
							@obj = @obj,
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					internal new global::Rocks.AdornmentsV4<global::NeedNullableCreateExpectations.Handler1, global::System.Func<int>, int> GetHashCode()
					{
						var handler = new global::NeedNullableCreateExpectations.Handler1();
						this.Expectations.handlers1.Add(handler);
						return new(handler);
					}
					
					internal new global::Rocks.AdornmentsV4<global::NeedNullableCreateExpectations.Handler2, global::System.Func<string?>, string?> ToString()
					{
						var handler = new global::NeedNullableCreateExpectations.Handler2();
						this.Expectations.handlers2.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.AdornmentsV4<global::NeedNullableCreateExpectations.Handler3, global::System.Func<object?, int>, int> IntReturn(global::Rocks.Argument<object?> @initializationData)
					{
						global::System.ArgumentNullException.ThrowIfNull(@initializationData);
						
						var handler = new global::NeedNullableCreateExpectations.Handler3
						{
							@initializationData = @initializationData.Transform(null),
						};
						
						this.Expectations.handlers3.Add(handler);
						return new(handler);
					}
					internal global::Rocks.AdornmentsV4<global::NeedNullableCreateExpectations.Handler3, global::System.Func<object?, int>, int> IntReturn(object? @initializationData = null) =>
						this.IntReturn(global::Rocks.Arg.Is(@initializationData));
					
					internal global::Rocks.AdornmentsV4<global::NeedNullableCreateExpectations.Handler4, global::System.Action<object?>> VoidReturn(global::Rocks.Argument<object?> @initializationData)
					{
						global::System.ArgumentNullException.ThrowIfNull(@initializationData);
						
						var handler = new global::NeedNullableCreateExpectations.Handler4
						{
							@initializationData = @initializationData.Transform(null),
						};
						
						this.Expectations.handlers4.Add(handler);
						return new(handler);
					}
					internal global::Rocks.AdornmentsV4<global::NeedNullableCreateExpectations.Handler4, global::System.Action<object?>> VoidReturn(object? @initializationData = null) =>
						this.VoidReturn(global::Rocks.Arg.Is(@initializationData));
					
					private global::NeedNullableCreateExpectations Expectations { get; }
				}
				
				internal global::NeedNullableCreateExpectations.NeedNullableMethodExpectations Methods { get; }
				
				internal NeedNullableCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::NeedNullable Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockNeedNullable(this);
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
			new[] { (typeof(RockAttributeGenerator), "NeedNullable_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateMakeWithMethodsWhenParameterWithNullDefaultIsNotAnnotatedAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockMake<NeedNullable>]

			public class NeedNullable
			{
			    public virtual int IntReturn(object initializationData = null) => 0;
			    public virtual void VoidReturn(object initializationData = null) { }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class NeedNullableMakeExpectations
			{
				internal global::NeedNullable Instance()
				{
					return new RockNeedNullable();
				}
				
				private sealed class RockNeedNullable
					: global::NeedNullable
				{
					public RockNeedNullable()
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
					public override int IntReturn(object? @initializationData = null)
					{
						return default!;
					}
					public override void VoidReturn(object? @initializationData = null)
					{
					}
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "NeedNullable_Rock_Make.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}
}