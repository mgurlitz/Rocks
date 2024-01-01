﻿using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class V4GeneratorTests
{
	[Test]
	public static async Task GenerateCreateWithInterfaceAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<ITest>()]

			public sealed class Holder { }

			public interface ITest
			{
				void NoArgumentsNoReturn();
				void ArgumentsNoReturn(Holder holder, string value);

				int NoArgumentsReturn();
				int ArgumentsReturn(Holder holder, string value);
			
				Guid Data { get; set; }

				Holder this[long index] { get; set; }

				event EventHandler Test;
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal sealed class ITestCreateExpectations
				: global::Rocks.Expectations.ExpectationsV4
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.HandlerV4<global::System.Action>
				{ }
				
				internal sealed class Handler1
					: global::Rocks.HandlerV4<global::System.Action<global::Holder, string>>
				{
					public global::Rocks.Argument<global::Holder> @holder { get; set; }
					public global::Rocks.Argument<string> @value { get; set; }
				}
				
				internal sealed class Handler2
					: global::Rocks.HandlerV4<global::System.Func<int>, int>
				{ }
				
				internal sealed class Handler3
					: global::Rocks.HandlerV4<global::System.Func<global::Holder, string, int>, int>
				{
					public global::Rocks.Argument<global::Holder> @holder { get; set; }
					public global::Rocks.Argument<string> @value { get; set; }
				}
				
				internal sealed class Handler4
					: global::Rocks.HandlerV4<global::System.Func<global::System.Guid>, global::System.Guid>
				{ }
				
				internal sealed class Handler5
					: global::Rocks.HandlerV4<global::System.Action<global::System.Guid>>
				{
					public global::Rocks.Argument<global::System.Guid> @value { get; set; }
				}
				
				internal sealed class Handler6
					: global::Rocks.HandlerV4<global::System.Func<long, global::Holder>, global::Holder>
				{
					public global::Rocks.Argument<long> @index { get; set; }
				}
				
				internal sealed class Handler7
					: global::Rocks.HandlerV4<global::System.Action<long, global::Holder>>
				{
					public global::Rocks.Argument<long> @index { get; set; }
					public global::Rocks.Argument<global::Holder> @value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::ITestCreateExpectations.Handler0> @handlers0 = new();
				private readonly global::System.Collections.Generic.List<global::ITestCreateExpectations.Handler1> @handlers1 = new();
				private readonly global::System.Collections.Generic.List<global::ITestCreateExpectations.Handler2> @handlers2 = new();
				private readonly global::System.Collections.Generic.List<global::ITestCreateExpectations.Handler3> @handlers3 = new();
				private readonly global::System.Collections.Generic.List<global::ITestCreateExpectations.Handler4> @handlers4 = new();
				private readonly global::System.Collections.Generic.List<global::ITestCreateExpectations.Handler5> @handlers5 = new();
				private readonly global::System.Collections.Generic.List<global::ITestCreateExpectations.Handler6> @handlers6 = new();
				private readonly global::System.Collections.Generic.List<global::ITestCreateExpectations.Handler7> @handlers7 = new();
				
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
						failures.AddRange(this.Verify(handlers5));
						failures.AddRange(this.Verify(handlers6));
						failures.AddRange(this.Verify(handlers7));
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class RockITest
					: global::ITest, global::Rocks.IRaiseEvents
				{
					public RockITest(global::ITestCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "void NoArgumentsNoReturn()")]
					public void NoArgumentsNoReturn()
					{
						if (this.Expectations.handlers0.Count > 0)
						{
							var @handler = this.Expectations.handlers0[0];
							@handler.CallCount++;
							@handler.Callback?.Invoke();
							@handler.RaiseEvents(this);
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void NoArgumentsNoReturn()");
						}
					}
					
					[global::Rocks.MemberIdentifier(1, "void ArgumentsNoReturn(global::Holder @holder, string @value)")]
					public void ArgumentsNoReturn(global::Holder @holder, string @value)
					{
						if (this.Expectations.handlers1.Count > 0)
						{
							var @foundMatch = false;
							
							foreach (var @handler in this.Expectations.handlers1)
							{
								if (@handler.@holder.IsValid(@holder!) &&
									@handler.@value.IsValid(@value!))
								{
									@foundMatch = true;
									@handler.CallCount++;
									@handler.Callback?.Invoke(@holder!, @value!);
									@handler.RaiseEvents(this);
									break;
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void ArgumentsNoReturn(global::Holder @holder, string @value)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void ArgumentsNoReturn(global::Holder @holder, string @value)");
						}
					}
					
					[global::Rocks.MemberIdentifier(2, "int NoArgumentsReturn()")]
					public int NoArgumentsReturn()
					{
						if (this.Expectations.handlers2.Count > 0)
						{
							var @handler = this.Expectations.handlers2[0];
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							@handler.RaiseEvents(this);
							return @result!;
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for int NoArgumentsReturn()");
					}
					
					[global::Rocks.MemberIdentifier(3, "int ArgumentsReturn(global::Holder @holder, string @value)")]
					public int ArgumentsReturn(global::Holder @holder, string @value)
					{
						if (this.Expectations.handlers3.Count > 0)
						{
							foreach (var @handler in this.Expectations.handlers3)
							{
								if (@handler.@holder.IsValid(@holder!) &&
									@handler.@value.IsValid(@value!))
								{
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback(@holder!, @value!) : @handler.ReturnValue;
									@handler.RaiseEvents(this);
									return @result!;
								}
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers match for int ArgumentsReturn(global::Holder @holder, string @value)");
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for int ArgumentsReturn(global::Holder @holder, string @value)");
					}
					
					[global::Rocks.MemberIdentifier(4, "get_Data()")]
					[global::Rocks.MemberIdentifier(5, "set_Data(value)")]
					public global::System.Guid Data
					{
						get
						{
							if (this.Expectations.handlers4.Count > 0)
							{
								var @handler = this.Expectations.handlers4[0];
								@handler.CallCount++;
								var @result = @handler.Callback?.Invoke() ?? @handler.ReturnValue;
								@handler.RaiseEvents(this);
								return @result!;
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_Data())");
						}
						set
						{
							if (this.Expectations.handlers5.Count > 0)
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
											throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_Data(value)");
										}
										
										@handler.RaiseEvents(this);
										break;
									}
								}
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for set_Data(value)");
							}
						}
					}
					
					[global::Rocks.MemberIdentifier(6, "this[long @index]")]
					[global::Rocks.MemberIdentifier(7, "this[long @index]")]
					public global::Holder this[long @index]
					{
						get
						{
							if (this.Expectations.handlers6.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers6)
								{
									if (@handler.@index.IsValid(@index!))
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback(@index!) : @handler.ReturnValue;
										@handler.RaiseEvents(this);
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for this[long @index]");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for this[long @index])");
						}
						set
						{
							if (this.Expectations.handlers7.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers7)
								{
									if (@handler.@index.IsValid(@index!) &&
										@handler.@value.IsValid(@value!))
									{
										@handler.CallCount++;
										@handler.Callback?.Invoke(@index!, @value!);
										@handler.RaiseEvents(this);
										return;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for this[long @index]");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for this[long @index])");
						}
					}
					
					#pragma warning disable CS0067
					public event global::System.EventHandler? Test;
					#pragma warning restore CS0067
					
					void global::Rocks.IRaiseEvents.Raise(string @fieldName, object @args)
					{
						var @thisType = this.GetType();
						var @eventDelegate = (global::System.MulticastDelegate)thisType.GetField(@fieldName, 
							global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic)!.GetValue(this)!;
						
						if (@eventDelegate is not null)
						{
							foreach (var @handler in @eventDelegate.GetInvocationList())
							{
								@handler.Method.Invoke(@handler.Target, new object[]{this, @args});
							}
						}
					}
					
					private global::ITestCreateExpectations Expectations { get; }
				}
				
				internal sealed class ITestMethodExpectations
				{
					internal ITestMethodExpectations(global::ITestCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::ITestCreateExpectations.Handler0, global::System.Action> NoArgumentsNoReturn()
					{
						var handler = new global::ITestCreateExpectations.Handler0();
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.AdornmentsV4<global::ITestCreateExpectations.Handler1, global::System.Action<global::Holder, string>> ArgumentsNoReturn(global::Rocks.Argument<global::Holder> @holder, global::Rocks.Argument<string> @value)
					{
						global::System.ArgumentNullException.ThrowIfNull(@holder);
						global::System.ArgumentNullException.ThrowIfNull(@value);
						
						var handler = new global::ITestCreateExpectations.Handler1
						{
							@holder = @holder,
							@value = @value,
						};
						
						this.Expectations.handlers1.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.AdornmentsV4<global::ITestCreateExpectations.Handler2, global::System.Func<int>, int> NoArgumentsReturn()
					{
						var handler = new global::ITestCreateExpectations.Handler2();
						this.Expectations.handlers2.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.AdornmentsV4<global::ITestCreateExpectations.Handler3, global::System.Func<global::Holder, string, int>, int> ArgumentsReturn(global::Rocks.Argument<global::Holder> @holder, global::Rocks.Argument<string> @value)
					{
						global::System.ArgumentNullException.ThrowIfNull(@holder);
						global::System.ArgumentNullException.ThrowIfNull(@value);
						
						var handler = new global::ITestCreateExpectations.Handler3
						{
							@holder = @holder,
							@value = @value,
						};
						
						this.Expectations.handlers3.Add(handler);
						return new(handler);
					}
					
					private global::ITestCreateExpectations Expectations { get; }
				}
				
				internal sealed class ITestPropertyExpectations
				{
					internal sealed class ITestPropertyGetterExpectations
					{
						internal ITestPropertyGetterExpectations(global::ITestCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::ITestCreateExpectations.Handler4, global::System.Func<global::System.Guid>, global::System.Guid> Data()
						{
							var handler = new global::ITestCreateExpectations.Handler4();
							this.Expectations.handlers4.Add(handler);
							return new(handler);
						}
						private global::ITestCreateExpectations Expectations { get; }
					}
					
					internal sealed class ITestPropertySetterExpectations
					{
						internal ITestPropertySetterExpectations(global::ITestCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::ITestCreateExpectations.Handler5, global::System.Action<global::System.Guid>> Data(global::Rocks.Argument<global::System.Guid> @value)
						{
							var handler = new global::ITestCreateExpectations.Handler5
							{
								value = @value,
							};
						
							this.Expectations.handlers5.Add(handler);
							return new(handler);
						}
						private global::ITestCreateExpectations Expectations { get; }
					}
					
					internal ITestPropertyExpectations(global::ITestCreateExpectations expectations) =>
						(this.Getters, this.Setters) = (new(expectations), new(expectations));
					
					internal global::ITestCreateExpectations.ITestPropertyExpectations.ITestPropertyGetterExpectations Getters { get; }
					internal global::ITestCreateExpectations.ITestPropertyExpectations.ITestPropertySetterExpectations Setters { get; }
				}
				internal sealed class ITestIndexerExpectations
				{
					internal sealed class ITestIndexerGetterExpectations
					{
						internal ITestIndexerGetterExpectations(global::ITestCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::ITestCreateExpectations.Handler6, global::System.Func<long, global::Holder>, global::Holder> This(global::Rocks.Argument<long> @index)
						{
							global::System.ArgumentNullException.ThrowIfNull(@index);
							
							var handler = new global::ITestCreateExpectations.Handler6
							{
								@index = @index,
							};
							
							this.Expectations.handlers6.Add(handler);
							return new(handler);
						}
						private global::ITestCreateExpectations Expectations { get; }
					}
					
					internal sealed class ITestIndexerSetterExpectations
					{
						internal ITestIndexerSetterExpectations(global::ITestCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::ITestCreateExpectations.Handler7, global::System.Action<long, global::Holder>> This(global::Rocks.Argument<global::Holder> @value, global::Rocks.Argument<long> @index)
						{
							global::System.ArgumentNullException.ThrowIfNull(@index);
							global::System.ArgumentNullException.ThrowIfNull(@value);
							
							var handler = new global::ITestCreateExpectations.Handler7
							{
								@index = @index,
								@value = @value,
							};
							
							this.Expectations.handlers7.Add(handler);
							return new(handler);
						}
						private global::ITestCreateExpectations Expectations { get; }
					}
					
					internal ITestIndexerExpectations(global::ITestCreateExpectations expectations) =>
						(this.Getters, this.Setters) = (new(expectations), new(expectations));
					
					internal global::ITestCreateExpectations.ITestIndexerExpectations.ITestIndexerGetterExpectations Getters { get; }
					internal global::ITestCreateExpectations.ITestIndexerExpectations.ITestIndexerSetterExpectations Setters { get; }
				}
				
				internal global::ITestCreateExpectations.ITestMethodExpectations Methods { get; }
				internal global::ITestCreateExpectations.ITestPropertyExpectations Properties { get; }
				internal global::ITestCreateExpectations.ITestIndexerExpectations Indexers { get; }
				
				internal ITestCreateExpectations() =>
					(this.Methods, this.Properties, this.Indexers) = (new(this), new(this), new(this));
				
				internal global::ITest Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockITest(this);
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
			new[] { (typeof(RockAttributeGenerator), "ITest_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateMakeWithInterfaceAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockMake<ITest>()]

			public sealed class Holder { }

			public interface ITest
			{
				void NoArgumentsNoReturn();
				void ArgumentsNoReturn(Holder holder, string value);

				int NoArgumentsReturn();
				int ArgumentsReturn(Holder holder, string value);
			
				Guid Data { get; set; }

				Holder this[long index] { get; set; }

				event EventHandler Test;
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class ITestMakeExpectations
			{
				internal global::ITest Instance()
				{
					return new RockITest();
				}
				
				private sealed class RockITest
					: global::ITest
				{
					public RockITest()
					{
					}
					
					public void NoArgumentsNoReturn()
					{
					}
					public void ArgumentsNoReturn(global::Holder @holder, string @value)
					{
					}
					public int NoArgumentsReturn()
					{
						return default!;
					}
					public int ArgumentsReturn(global::Holder @holder, string @value)
					{
						return default!;
					}
					public global::System.Guid Data
					{
						get => default!;
						set { }
					}
					public global::Holder this[long @index]
					{
						get => default!;
						set { }
					}
					
					#pragma warning disable CS0067
					public event global::System.EventHandler? Test;
					#pragma warning restore CS0067
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "ITest_Rock_Make.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}
}