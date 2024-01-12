﻿using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using Rocks.Diagnostics;

namespace Rocks.Tests.Generators;

public static class ObsoleteGeneratorTests
{
	[Test]
	public static async Task CreateWhenTargetHasLongObsoleteMessageAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<MockTests.IContainer>]

			#nullable enable

			namespace MockTests
			{
				[Obsolete("This relay is obsolete and will be removed in future versions. The reason is that it causes recursion overflow for \"many\" requests if you forget to add IEnumerable<T> customization.\nPlease use the following code snippet instead:\nfixture.Customizations.Add(  new FilteringSpecimenBuilder(    new FixedBuilder(      SEQUENCE_TO_RETURN),    new EqualRequestSpecification(      new MultipleRequest(        new SeededRequest(          typeof(T),          default(T))))));\n\nIf you need that often, please create an extension method inside your project.")]
				public interface IContainer
				{
					void Contain();
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class IContainerCreateExpectations
					: global::Rocks.Expectations
				{
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Action>
					{ }
					
					private readonly global::System.Collections.Generic.List<global::MockTests.IContainerCreateExpectations.Handler0> @handlers0 = new();
					
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
					
					[type: global::System.ObsoleteAttribute("This relay is obsolete and will be removed in future versions. The reason is that it causes recursion overflow for \"many\" requests if you forget to add IEnumerable<T> customization.\nPlease use the following code snippet instead:\nfixture.Customizations.Add(  new FilteringSpecimenBuilder(    new FixedBuilder(      SEQUENCE_TO_RETURN),    new EqualRequestSpecification(      new MultipleRequest(        new SeededRequest(          typeof(T),          default(T))))));\n\nIf you need that often, please create an extension method inside your project.")]
					private sealed class Mock
						: global::MockTests.IContainer
					{
						public Mock(global::MockTests.IContainerCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::Rocks.MemberIdentifier(0, "void Contain()")]
						public void Contain()
						{
							if (this.Expectations.handlers0.Count > 0)
							{
								var @handler = this.Expectations.handlers0[0];
								@handler.CallCount++;
								@handler.Callback?.Invoke();
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Contain()");
							}
						}
						
						private global::MockTests.IContainerCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.IContainerCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.IContainerCreateExpectations.Handler0, global::System.Action> Contain()
						{
							var handler = new global::MockTests.IContainerCreateExpectations.Handler0();
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.IContainerCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.IContainerCreateExpectations.MethodExpectations Methods { get; }
					
					internal IContainerCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal global::MockTests.IContainer Instance()
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

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.IContainer_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task CreateWhenTargetHasObsoleteConstructorInErrorButHasOtherUseableConstructorsAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<MockTests.Container>]

			#nullable enable

			namespace MockTests
			{
				public abstract class Container
				{
					[Obsolete("Old", true)]
					public Container() { }

					public Container(string value) { }
			
					public abstract void Contain();
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class ContainerCreateExpectations
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
					
					private readonly global::System.Collections.Generic.List<global::MockTests.ContainerCreateExpectations.Handler0> @handlers0 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.ContainerCreateExpectations.Handler1> @handlers1 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.ContainerCreateExpectations.Handler2> @handlers2 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.ContainerCreateExpectations.Handler3> @handlers3 = new();
					
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
						: global::MockTests.Container
					{
						public Mock(global::MockTests.ContainerCreateExpectations @expectations, string @value)
							: base(@value)
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
						
						[global::Rocks.MemberIdentifier(3, "void Contain()")]
						public override void Contain()
						{
							if (this.Expectations.handlers3.Count > 0)
							{
								var @handler = this.Expectations.handlers3[0];
								@handler.CallCount++;
								@handler.Callback?.Invoke();
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Contain()");
							}
						}
						
						private global::MockTests.ContainerCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.ContainerCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.ContainerCreateExpectations.Handler0, global::System.Func<object?, bool>, bool> Equals(global::Rocks.Argument<object?> @obj)
						{
							global::System.ArgumentNullException.ThrowIfNull(@obj);
							
							var handler = new global::MockTests.ContainerCreateExpectations.Handler0
							{
								@obj = @obj,
							};
							
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						internal new global::Rocks.Adornments<global::MockTests.ContainerCreateExpectations.Handler1, global::System.Func<int>, int> GetHashCode()
						{
							var handler = new global::MockTests.ContainerCreateExpectations.Handler1();
							this.Expectations.handlers1.Add(handler);
							return new(handler);
						}
						
						internal new global::Rocks.Adornments<global::MockTests.ContainerCreateExpectations.Handler2, global::System.Func<string?>, string?> ToString()
						{
							var handler = new global::MockTests.ContainerCreateExpectations.Handler2();
							this.Expectations.handlers2.Add(handler);
							return new(handler);
						}
						
						internal global::Rocks.Adornments<global::MockTests.ContainerCreateExpectations.Handler3, global::System.Action> Contain()
						{
							var handler = new global::MockTests.ContainerCreateExpectations.Handler3();
							this.Expectations.handlers3.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.ContainerCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.ContainerCreateExpectations.MethodExpectations Methods { get; }
					
					internal ContainerCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal global::MockTests.Container Instance(string @value)
					{
						if (!this.WasInstanceInvoked)
						{
							this.WasInstanceInvoked = true;
							var @mock = new Mock(this, @value);
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
			new[] { (typeof(RockAttributeGenerator), "MockTests.Container_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateWhenATargetTypeIsObsoleteAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			
			[assembly: RockCreate<MockTests.IAmObsolete>]

			#nullable enable

			namespace MockTests
			{
				[Obsolete("Do not use this type", true)]
				public interface IAmObsolete
				{
					void Execute();
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			Enumerable.Empty<(Type, string, string)>(),
			new[]
			{
				new DiagnosticResult("ROCK2", DiagnosticSeverity.Error)
					.WithSpan(4, 12, 4, 45),
				new DiagnosticResult("CS0619", DiagnosticSeverity.Error)
					.WithSpan(4, 23, 4, 44)
			},
			generalDiagnosticOption: ReportDiagnostic.Error,
			disabledDiagnostics: ["CS1591"]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateWhenAMethodAndItsPartsAreObsoleteAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Collections;
			using System.Collections.Generic;
			using System.Linq;
									
			[assembly: RockCreate<MockTests.IAmAlsoObsolete>]

			#nullable enable

			namespace MockTests
			{
				[Obsolete("Do not use this type", true)]
				public interface IAmObsolete
				{
					void Execute();
				}

				public interface IAmAlsoObsolete
				{
					[Obsolete("Do not use this method", true)]
					void Use(IAmObsolete old);
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			Enumerable.Empty<(Type, string, string)>(),
			new[]
			{
				new DiagnosticResult("ROCK9", DiagnosticSeverity.Error)
					.WithSpan(7, 12, 7, 49)
			},
			generalDiagnosticOption: ReportDiagnostic.Error,
			disabledDiagnostics: ["CS1591"]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateWhenAPropertyAndItsTypeAreObsoleteAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Collections;
			using System.Collections.Generic;
			using System.Linq;
			
			[assembly: RockCreate<MockTests.IAmAlsoObsolete>]

			#nullable enable

			namespace MockTests
			{
				[Obsolete("Do not use this type", true)]
				public interface IAmObsolete
				{
					void Execute();
				}

				public interface IAmAlsoObsolete
				{
					[Obsolete("Do not use this method", true)]
					IAmObsolete Use { get; }
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			Enumerable.Empty<(Type, string, string)>(),
			new[]
			{
				new DiagnosticResult("ROCK9", DiagnosticSeverity.Error)
					.WithSpan(7, 12, 7, 49)
			},
			generalDiagnosticOption: ReportDiagnostic.Error,
			disabledDiagnostics: ["CS1591"]).ConfigureAwait(false);
	}

	[Test]
	public static async Task CreateWhenGenericContainsObsoleteTypeAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Collections;
			using System.Collections.Generic;
			using System.Linq;
			
			[assembly: RockCreate<MockTests.JobStorage>]

			#nullable enable

			namespace MockTests
			{
				[Obsolete("Do not use this", true)]
				public interface IServerComponent
				{
					void Execute();
				}

				public abstract class JobStorage
				{
					public virtual IEnumerable<IServerComponent> GetComponents() =>
						Enumerable.Empty<IServerComponent>();
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			Enumerable.Empty<(Type, string, string)>(),
			new[] 
			{
				new DiagnosticResult("CS0619", DiagnosticSeverity.Error)
					.WithSpan(21, 30, 21, 46).WithArguments("MockTests.IServerComponent", "Do not use this"),
				new DiagnosticResult(MemberUsesObsoleteTypeDiagnostic.Id, DiagnosticSeverity.Error)
					.WithSpan(7, 12, 7, 44),
				new DiagnosticResult("CS0619", DiagnosticSeverity.Error)
					.WithSpan(22, 21, 22, 37).WithArguments("MockTests.IServerComponent", "Do not use this"),
			},
			generalDiagnosticOption: ReportDiagnostic.Error,
			disabledDiagnostics: ["CS1591"]).ConfigureAwait(false);
	}

	[Test]
	public static async Task CreateWhenTargetHasObsoleteMembersAsWarningsAndBuildIsErrorAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<MockTests.IPixelShader>]

			#nullable enable

			namespace MockTests
			{
				public interface IPixelShader
				{
					[Obsolete("This method is not intended to be used directly by user code")]
					uint GetPixelOptions();

					[Obsolete("This property is not intended to be used directly by user code")]
					uint Values { get; }

					[Obsolete("This event is not intended to be used directly by user code")]
					event EventHandler ShadingOccurred;
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class IPixelShaderCreateExpectations
					: global::Rocks.Expectations
				{
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Func<uint>, uint>
					{ }
					
					internal sealed class Handler1
						: global::Rocks.Handler<global::System.Func<uint>, uint>
					{ }
					
					private readonly global::System.Collections.Generic.List<global::MockTests.IPixelShaderCreateExpectations.Handler0> @handlers0 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.IPixelShaderCreateExpectations.Handler1> @handlers1 = new();
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							failures.AddRange(this.Verify(handlers0));
							failures.AddRange(this.Verify(handlers1));
					
							if (failures.Count > 0)
							{
								throw new global::Rocks.Exceptions.VerificationException(failures);
							}
						}
					}
					
					private sealed class Mock
						: global::MockTests.IPixelShader, global::Rocks.IRaiseEvents
					{
						public Mock(global::MockTests.IPixelShaderCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::System.ObsoleteAttribute("This method is not intended to be used directly by user code")]
						[global::Rocks.MemberIdentifier(0, "uint GetPixelOptions()")]
						public uint GetPixelOptions()
						{
							if (this.Expectations.handlers0.Count > 0)
							{
								var @handler = this.Expectations.handlers0[0];
								@handler.CallCount++;
								var @result = @handler.Callback is not null ?
									@handler.Callback() : @handler.ReturnValue;
								@handler.RaiseEvents(this);
								return @result!;
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for uint GetPixelOptions()");
						}
						
						[global::System.ObsoleteAttribute("This property is not intended to be used directly by user code")]
						[global::Rocks.MemberIdentifier(1, "get_Values()")]
						public uint Values
						{
							get
							{
								if (this.Expectations.handlers1.Count > 0)
								{
									var @handler = this.Expectations.handlers1[0];
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback() : @handler.ReturnValue;
									@handler.RaiseEvents(this);
									return @result!;
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_Values())");
							}
						}
						
						#pragma warning disable CS0067
						[global::System.ObsoleteAttribute("This event is not intended to be used directly by user code")]
						public event global::System.EventHandler? ShadingOccurred;
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
						
						private global::MockTests.IPixelShaderCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.IPixelShaderCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler0, global::System.Func<uint>, uint> GetPixelOptions()
						{
							var handler = new global::MockTests.IPixelShaderCreateExpectations.Handler0();
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.IPixelShaderCreateExpectations Expectations { get; }
					}
					
					internal sealed class PropertyExpectations
					{
						internal sealed class PropertyGetterExpectations
						{
							internal PropertyGetterExpectations(global::MockTests.IPixelShaderCreateExpectations expectations) =>
								this.Expectations = expectations;
							
							internal global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler1, global::System.Func<uint>, uint> Values()
							{
								var handler = new global::MockTests.IPixelShaderCreateExpectations.Handler1();
								this.Expectations.handlers1.Add(handler);
								return new(handler);
							}
							private global::MockTests.IPixelShaderCreateExpectations Expectations { get; }
						}
						
						
						internal PropertyExpectations(global::MockTests.IPixelShaderCreateExpectations expectations) =>
							(this.Getters) = (new(expectations));
						
						internal global::MockTests.IPixelShaderCreateExpectations.PropertyExpectations.PropertyGetterExpectations Getters { get; }
					}
					
					internal global::MockTests.IPixelShaderCreateExpectations.MethodExpectations Methods { get; }
					internal global::MockTests.IPixelShaderCreateExpectations.PropertyExpectations Properties { get; }
					
					internal IPixelShaderCreateExpectations() =>
						(this.Methods, this.Properties) = (new(this), new(this));
					
					internal global::MockTests.IPixelShader Instance()
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
				
				internal static class IPixelShaderAdornmentsEventExtensions
				{
					internal static global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler0, global::System.Func<uint>, uint> RaiseShadingOccurred(this global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler0, global::System.Func<uint>, uint> self, global::System.EventArgs args) => 
						self.AddRaiseEvent(new("ShadingOccurred", args));
					internal static global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler1, global::System.Func<uint>, uint> RaiseShadingOccurred(this global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler1, global::System.Func<uint>, uint> self, global::System.EventArgs args) => 
						self.AddRaiseEvent(new("ShadingOccurred", args));
				}
			}
			
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.IPixelShader_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task CreateWhenTargetHasObsoleteMembersAsWarningsAndBuildIsDefaultAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			
			[assembly: RockCreate<MockTests.IPixelShader>]

			#nullable enable
			
			namespace MockTests
			{
				public interface IPixelShader
				{
					[Obsolete("This method is not intended to be used directly by user code")]
					uint GetPixelOptions();
			
					[Obsolete("This property is not intended to be used directly by user code")]
					uint Values { get; }
			
					[Obsolete("This event is not intended to be used directly by user code")]
					event EventHandler ShadingOccurred;
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class IPixelShaderCreateExpectations
					: global::Rocks.Expectations
				{
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Func<uint>, uint>
					{ }
					
					internal sealed class Handler1
						: global::Rocks.Handler<global::System.Func<uint>, uint>
					{ }
					
					private readonly global::System.Collections.Generic.List<global::MockTests.IPixelShaderCreateExpectations.Handler0> @handlers0 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.IPixelShaderCreateExpectations.Handler1> @handlers1 = new();
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							failures.AddRange(this.Verify(handlers0));
							failures.AddRange(this.Verify(handlers1));
					
							if (failures.Count > 0)
							{
								throw new global::Rocks.Exceptions.VerificationException(failures);
							}
						}
					}
					
					private sealed class Mock
						: global::MockTests.IPixelShader, global::Rocks.IRaiseEvents
					{
						public Mock(global::MockTests.IPixelShaderCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::System.ObsoleteAttribute("This method is not intended to be used directly by user code")]
						[global::Rocks.MemberIdentifier(0, "uint GetPixelOptions()")]
						public uint GetPixelOptions()
						{
							if (this.Expectations.handlers0.Count > 0)
							{
								var @handler = this.Expectations.handlers0[0];
								@handler.CallCount++;
								var @result = @handler.Callback is not null ?
									@handler.Callback() : @handler.ReturnValue;
								@handler.RaiseEvents(this);
								return @result!;
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for uint GetPixelOptions()");
						}
						
						[global::System.ObsoleteAttribute("This property is not intended to be used directly by user code")]
						[global::Rocks.MemberIdentifier(1, "get_Values()")]
						public uint Values
						{
							get
							{
								if (this.Expectations.handlers1.Count > 0)
								{
									var @handler = this.Expectations.handlers1[0];
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback() : @handler.ReturnValue;
									@handler.RaiseEvents(this);
									return @result!;
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_Values())");
							}
						}
						
						#pragma warning disable CS0067
						[global::System.ObsoleteAttribute("This event is not intended to be used directly by user code")]
						public event global::System.EventHandler? ShadingOccurred;
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
						
						private global::MockTests.IPixelShaderCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.IPixelShaderCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler0, global::System.Func<uint>, uint> GetPixelOptions()
						{
							var handler = new global::MockTests.IPixelShaderCreateExpectations.Handler0();
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.IPixelShaderCreateExpectations Expectations { get; }
					}
					
					internal sealed class PropertyExpectations
					{
						internal sealed class PropertyGetterExpectations
						{
							internal PropertyGetterExpectations(global::MockTests.IPixelShaderCreateExpectations expectations) =>
								this.Expectations = expectations;
							
							internal global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler1, global::System.Func<uint>, uint> Values()
							{
								var handler = new global::MockTests.IPixelShaderCreateExpectations.Handler1();
								this.Expectations.handlers1.Add(handler);
								return new(handler);
							}
							private global::MockTests.IPixelShaderCreateExpectations Expectations { get; }
						}
						
						
						internal PropertyExpectations(global::MockTests.IPixelShaderCreateExpectations expectations) =>
							(this.Getters) = (new(expectations));
						
						internal global::MockTests.IPixelShaderCreateExpectations.PropertyExpectations.PropertyGetterExpectations Getters { get; }
					}
					
					internal global::MockTests.IPixelShaderCreateExpectations.MethodExpectations Methods { get; }
					internal global::MockTests.IPixelShaderCreateExpectations.PropertyExpectations Properties { get; }
					
					internal IPixelShaderCreateExpectations() =>
						(this.Methods, this.Properties) = (new(this), new(this));
					
					internal global::MockTests.IPixelShader Instance()
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
				
				internal static class IPixelShaderAdornmentsEventExtensions
				{
					internal static global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler0, global::System.Func<uint>, uint> RaiseShadingOccurred(this global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler0, global::System.Func<uint>, uint> self, global::System.EventArgs args) => 
						self.AddRaiseEvent(new("ShadingOccurred", args));
					internal static global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler1, global::System.Func<uint>, uint> RaiseShadingOccurred(this global::Rocks.Adornments<global::MockTests.IPixelShaderCreateExpectations.Handler1, global::System.Func<uint>, uint> self, global::System.EventArgs args) => 
						self.AddRaiseEvent(new("ShadingOccurred", args));
				}
			}
			
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.IPixelShader_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}
}