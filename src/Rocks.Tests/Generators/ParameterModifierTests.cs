﻿using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class ParameterModifierTests
{
	[Test]
	public static async Task GenerateCreateWithInParameterAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<IParameterModifier>]

			public interface IParameterModifier
			{
			    void Modify(in string value);   
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IParameterModifierCreateExpectations
				: global::Rocks.Expectations
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.Handler<global::System.Action<string>>
				{
					public global::Rocks.Argument<string> @value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::IParameterModifierCreateExpectations.Handler0> @handlers0 = new();
				
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
				
				private sealed class Mock
					: global::IParameterModifier
				{
					public Mock(global::IParameterModifierCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "void Modify(in string @value)")]
					public void Modify(in string @value)
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
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void Modify(in string @value)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Modify(in string @value)");
						}
					}
					
					private global::IParameterModifierCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::IParameterModifierCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.Adornments<global::IParameterModifierCreateExpectations.Handler0, global::System.Action<string>> Modify(global::Rocks.Argument<string> @value)
					{
						global::System.ArgumentNullException.ThrowIfNull(@value);
						
						var handler = new global::IParameterModifierCreateExpectations.Handler0
						{
							@value = @value,
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					private global::IParameterModifierCreateExpectations Expectations { get; }
				}
				
				internal global::IParameterModifierCreateExpectations.MethodExpectations Methods { get; }
				
				internal IParameterModifierCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::IParameterModifier Instance()
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
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IParameterModifier_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateMakeWithInParameterAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockMake<IParameterModifier>]

			public interface IParameterModifier
			{
			    void Modify(in string value);   
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IParameterModifierMakeExpectations
			{
				internal global::IParameterModifier Instance()
				{
					return new Mock();
				}
				
				private sealed class Mock
					: global::IParameterModifier
				{
					public Mock()
					{
					}
					
					public void Modify(in string @value)
					{
					}
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IParameterModifier_Rock_Make.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateCreateWithOutParameterAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<IParameterModifier>]

			public interface IParameterModifier
			{
			    void Modify(out string value);   
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IParameterModifierCreateExpectations
				: global::Rocks.Expectations
			{
				internal static class Projections
				{
					internal delegate void Callback_193235261019447779478409340058228437220444154875(out string @value);
				}
				
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.Handler<global::IParameterModifierCreateExpectations.Projections.Callback_193235261019447779478409340058228437220444154875>
				{
					public global::Rocks.Argument<string> @value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::IParameterModifierCreateExpectations.Handler0> @handlers0 = new();
				
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
				
				private sealed class Mock
					: global::IParameterModifier
				{
					public Mock(global::IParameterModifierCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "void Modify(out string @value)")]
					public void Modify(out string @value)
					{
						value = default!;
						if (this.Expectations.handlers0.Count > 0)
						{
							var @foundMatch = false;
							
							foreach (var @handler in this.Expectations.handlers0)
							{
								if (@handler.@value.IsValid(@value!))
								{
									@foundMatch = true;
									@handler.CallCount++;
									@handler.Callback?.Invoke(out @value!);
									break;
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void Modify(out string @value)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Modify(out string @value)");
						}
					}
					
					private global::IParameterModifierCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::IParameterModifierCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.Adornments<global::IParameterModifierCreateExpectations.Handler0, global::IParameterModifierCreateExpectations.Projections.Callback_193235261019447779478409340058228437220444154875> Modify(global::Rocks.Argument<string> @value)
					{
						global::System.ArgumentNullException.ThrowIfNull(@value);
						
						var handler = new global::IParameterModifierCreateExpectations.Handler0
						{
							@value = global::Rocks.Arg.Any<string>(),
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					private global::IParameterModifierCreateExpectations Expectations { get; }
				}
				
				internal global::IParameterModifierCreateExpectations.MethodExpectations Methods { get; }
				
				internal IParameterModifierCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::IParameterModifier Instance()
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
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IParameterModifier_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateMakeWithOutParameterAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockMake<IParameterModifier>]

			public interface IParameterModifier
			{
			    void Modify(out string value);   
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IParameterModifierMakeExpectations
			{
				internal global::IParameterModifier Instance()
				{
					return new Mock();
				}
				
				private sealed class Mock
					: global::IParameterModifier
				{
					public Mock()
					{
					}
					
					public void Modify(out string @value)
					{
						value = default!;
					}
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IParameterModifier_Rock_Make.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateCreateWithRefParameterAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<IParameterModifier>]

			public interface IParameterModifier
			{
			    void Modify(ref string value);   
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IParameterModifierCreateExpectations
				: global::Rocks.Expectations
			{
				internal static class Projections
				{
					internal delegate void Callback_117490457623372471697910661720505969856490442481(ref string @value);
				}
				
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.Handler<global::IParameterModifierCreateExpectations.Projections.Callback_117490457623372471697910661720505969856490442481>
				{
					public global::Rocks.Argument<string> @value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::IParameterModifierCreateExpectations.Handler0> @handlers0 = new();
				
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
				
				private sealed class Mock
					: global::IParameterModifier
				{
					public Mock(global::IParameterModifierCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "void Modify(ref string @value)")]
					public void Modify(ref string @value)
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
									@handler.Callback?.Invoke(ref @value!);
									break;
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void Modify(ref string @value)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Modify(ref string @value)");
						}
					}
					
					private global::IParameterModifierCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::IParameterModifierCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.Adornments<global::IParameterModifierCreateExpectations.Handler0, global::IParameterModifierCreateExpectations.Projections.Callback_117490457623372471697910661720505969856490442481> Modify(global::Rocks.Argument<string> @value)
					{
						global::System.ArgumentNullException.ThrowIfNull(@value);
						
						var handler = new global::IParameterModifierCreateExpectations.Handler0
						{
							@value = @value,
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					private global::IParameterModifierCreateExpectations Expectations { get; }
				}
				
				internal global::IParameterModifierCreateExpectations.MethodExpectations Methods { get; }
				
				internal IParameterModifierCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::IParameterModifier Instance()
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
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IParameterModifier_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateMakeWithRefParameterAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockMake<IParameterModifier>]

			public interface IParameterModifier
			{
			    void Modify(ref string value);   
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IParameterModifierMakeExpectations
			{
				internal global::IParameterModifier Instance()
				{
					return new Mock();
				}
				
				private sealed class Mock
					: global::IParameterModifier
				{
					public Mock()
					{
					}
					
					public void Modify(ref string @value)
					{
					}
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IParameterModifier_Rock_Make.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateCreateWithRefReadonlyParameterAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<IParameterModifier>]

			public interface IParameterModifier
			{
			    void Modify(ref readonly string value);   
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IParameterModifierCreateExpectations
				: global::Rocks.Expectations
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.Handler<global::System.Action<string>>
				{
					public global::Rocks.Argument<string> @value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::IParameterModifierCreateExpectations.Handler0> @handlers0 = new();
				
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
				
				private sealed class Mock
					: global::IParameterModifier
				{
					public Mock(global::IParameterModifierCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "void Modify(ref readonly string @value)")]
					public void Modify(ref readonly string @value)
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
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void Modify(ref readonly string @value)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Modify(ref readonly string @value)");
						}
					}
					
					private global::IParameterModifierCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::IParameterModifierCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.Adornments<global::IParameterModifierCreateExpectations.Handler0, global::System.Action<string>> Modify(global::Rocks.Argument<string> @value)
					{
						global::System.ArgumentNullException.ThrowIfNull(@value);
						
						var handler = new global::IParameterModifierCreateExpectations.Handler0
						{
							@value = @value,
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					private global::IParameterModifierCreateExpectations Expectations { get; }
				}
				
				internal global::IParameterModifierCreateExpectations.MethodExpectations Methods { get; }
				
				internal IParameterModifierCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::IParameterModifier Instance()
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
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IParameterModifier_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateMakeWithRefReadonlyParameterAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockMake<IParameterModifier>]

			public interface IParameterModifier
			{
			    void Modify(ref readonly string value);   
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IParameterModifierMakeExpectations
			{
				internal global::IParameterModifier Instance()
				{
					return new Mock();
				}
				
				private sealed class Mock
					: global::IParameterModifier
				{
					public Mock()
					{
					}
					
					public void Modify(ref readonly string @value)
					{
					}
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IParameterModifier_Rock_Make.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateCreateWithMixtureAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<IParameterModifier>]

			public interface IParameterModifier
			{
				void RefArgument(ref int a);
				void RefArgumentsWithGenerics<T1, T2>(T1 a, ref T2 b);
				void OutArgument(out int a);
				void OutArgumentsWithGenerics<T1, T2>(T1 a, out T2 b);
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IParameterModifierCreateExpectations
				: global::Rocks.Expectations
			{
				internal static class Projections
				{
					internal delegate void Callback_640457111802933967433135011802939136029252304196(ref int @a);
					internal delegate void Callback_595359563624402850359397691594068887527805892984<T1, T2>(T1 @a, ref T2 @b);
					internal delegate void Callback_360038979746784102455204459622175388488035293924(out int @a);
					internal delegate void Callback_376795512182245354180779374814988822523603172187<T1, T2>(T1 @a, out T2 @b);
				}
				
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.Handler<global::IParameterModifierCreateExpectations.Projections.Callback_640457111802933967433135011802939136029252304196>
				{
					public global::Rocks.Argument<int> @a { get; set; }
				}
				
				internal sealed class Handler1<T1, T2>
					: global::Rocks.Handler<global::IParameterModifierCreateExpectations.Projections.Callback_595359563624402850359397691594068887527805892984<T1, T2>>
				{
					public global::Rocks.Argument<T1> @a { get; set; }
					public global::Rocks.Argument<T2> @b { get; set; }
				}
				
				internal sealed class Handler2
					: global::Rocks.Handler<global::IParameterModifierCreateExpectations.Projections.Callback_360038979746784102455204459622175388488035293924>
				{
					public global::Rocks.Argument<int> @a { get; set; }
				}
				
				internal sealed class Handler3<T1, T2>
					: global::Rocks.Handler<global::IParameterModifierCreateExpectations.Projections.Callback_376795512182245354180779374814988822523603172187<T1, T2>>
				{
					public global::Rocks.Argument<T1> @a { get; set; }
					public global::Rocks.Argument<T2> @b { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::IParameterModifierCreateExpectations.Handler0> @handlers0 = new();
				private readonly global::System.Collections.Generic.List<global::Rocks.Handler> @handlers1 = new();
				private readonly global::System.Collections.Generic.List<global::IParameterModifierCreateExpectations.Handler2> @handlers2 = new();
				private readonly global::System.Collections.Generic.List<global::Rocks.Handler> @handlers3 = new();
				
				public override void Verify()
				{
					if (this.WasInstanceInvoked)
					{
						var failures = new global::System.Collections.Generic.List<string>();
				
						failures.AddRange(this.Verify(handlers0));
						failures.AddRange(this.Verify(handlers1));
						failures.AddRange(this.Verify(handlers2));
						failures.AddRange(this.Verify(handlers3));
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class Mock
					: global::IParameterModifier
				{
					public Mock(global::IParameterModifierCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "void RefArgument(ref int @a)")]
					public void RefArgument(ref int @a)
					{
						if (this.Expectations.handlers0.Count > 0)
						{
							var @foundMatch = false;
							
							foreach (var @handler in this.Expectations.handlers0)
							{
								if (@handler.@a.IsValid(@a!))
								{
									@foundMatch = true;
									@handler.CallCount++;
									@handler.Callback?.Invoke(ref @a!);
									break;
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void RefArgument(ref int @a)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void RefArgument(ref int @a)");
						}
					}
					
					[global::Rocks.MemberIdentifier(1, "void RefArgumentsWithGenerics<T1, T2>(T1 @a, ref T2 @b)")]
					public void RefArgumentsWithGenerics<T1, T2>(T1 @a, ref T2 @b)
					{
						if (this.Expectations.handlers1.Count > 0)
						{
							var @foundMatch = false;
							
							foreach (var @genericHandler in this.Expectations.handlers1)
							{
								if (@genericHandler is global::IParameterModifierCreateExpectations.Handler1<T1, T2> @handler)
								{
									if (@handler.@a.IsValid(@a!) &&
										@handler.@b.IsValid(@b!))
									{
										@foundMatch = true;
										@handler.CallCount++;
										@handler.Callback?.Invoke(@a!, ref @b!);
										break;
									}
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void RefArgumentsWithGenerics<T1, T2>(T1 @a, ref T2 @b)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void RefArgumentsWithGenerics<T1, T2>(T1 @a, ref T2 @b)");
						}
					}
					
					[global::Rocks.MemberIdentifier(2, "void OutArgument(out int @a)")]
					public void OutArgument(out int @a)
					{
						a = default!;
						if (this.Expectations.handlers2.Count > 0)
						{
							var @foundMatch = false;
							
							foreach (var @handler in this.Expectations.handlers2)
							{
								if (@handler.@a.IsValid(@a!))
								{
									@foundMatch = true;
									@handler.CallCount++;
									@handler.Callback?.Invoke(out @a!);
									break;
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void OutArgument(out int @a)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void OutArgument(out int @a)");
						}
					}
					
					[global::Rocks.MemberIdentifier(3, "void OutArgumentsWithGenerics<T1, T2>(T1 @a, out T2 @b)")]
					public void OutArgumentsWithGenerics<T1, T2>(T1 @a, out T2 @b)
					{
						b = default!;
						if (this.Expectations.handlers3.Count > 0)
						{
							var @foundMatch = false;
							
							foreach (var @genericHandler in this.Expectations.handlers3)
							{
								if (@genericHandler is global::IParameterModifierCreateExpectations.Handler3<T1, T2> @handler)
								{
									if (@handler.@a.IsValid(@a!) &&
										@handler.@b.IsValid(@b!))
									{
										@foundMatch = true;
										@handler.CallCount++;
										@handler.Callback?.Invoke(@a!, out @b!);
										break;
									}
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void OutArgumentsWithGenerics<T1, T2>(T1 @a, out T2 @b)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void OutArgumentsWithGenerics<T1, T2>(T1 @a, out T2 @b)");
						}
					}
					
					private global::IParameterModifierCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::IParameterModifierCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.Adornments<global::IParameterModifierCreateExpectations.Handler0, global::IParameterModifierCreateExpectations.Projections.Callback_640457111802933967433135011802939136029252304196> RefArgument(global::Rocks.Argument<int> @a)
					{
						global::System.ArgumentNullException.ThrowIfNull(@a);
						
						var handler = new global::IParameterModifierCreateExpectations.Handler0
						{
							@a = @a,
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.Adornments<global::IParameterModifierCreateExpectations.Handler1<T1, T2>, global::IParameterModifierCreateExpectations.Projections.Callback_595359563624402850359397691594068887527805892984<T1, T2>> RefArgumentsWithGenerics<T1, T2>(global::Rocks.Argument<T1> @a, global::Rocks.Argument<T2> @b)
					{
						global::System.ArgumentNullException.ThrowIfNull(@a);
						global::System.ArgumentNullException.ThrowIfNull(@b);
						
						var handler = new global::IParameterModifierCreateExpectations.Handler1<T1, T2>
						{
							@a = @a,
							@b = @b,
						};
						
						this.Expectations.handlers1.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.Adornments<global::IParameterModifierCreateExpectations.Handler2, global::IParameterModifierCreateExpectations.Projections.Callback_360038979746784102455204459622175388488035293924> OutArgument(global::Rocks.Argument<int> @a)
					{
						global::System.ArgumentNullException.ThrowIfNull(@a);
						
						var handler = new global::IParameterModifierCreateExpectations.Handler2
						{
							@a = global::Rocks.Arg.Any<int>(),
						};
						
						this.Expectations.handlers2.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.Adornments<global::IParameterModifierCreateExpectations.Handler3<T1, T2>, global::IParameterModifierCreateExpectations.Projections.Callback_376795512182245354180779374814988822523603172187<T1, T2>> OutArgumentsWithGenerics<T1, T2>(global::Rocks.Argument<T1> @a, global::Rocks.Argument<T2> @b)
					{
						global::System.ArgumentNullException.ThrowIfNull(@a);
						global::System.ArgumentNullException.ThrowIfNull(@b);
						
						var handler = new global::IParameterModifierCreateExpectations.Handler3<T1, T2>
						{
							@a = @a,
							@b = global::Rocks.Arg.Any<T2>(),
						};
						
						this.Expectations.handlers3.Add(handler);
						return new(handler);
					}
					
					private global::IParameterModifierCreateExpectations Expectations { get; }
				}
				
				internal global::IParameterModifierCreateExpectations.MethodExpectations Methods { get; }
				
				internal IParameterModifierCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::IParameterModifier Instance()
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
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IParameterModifier_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}
}