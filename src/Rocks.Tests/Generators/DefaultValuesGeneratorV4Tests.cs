﻿using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class DefaultValuesGeneratorV4Tests
{
	[Test]
	public static async Task CreateWhenExplicitImplementationHasDefaultValuesAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Threading.Tasks;

			[assembly: RockCreate<MockTests.IRequest<object>>]

			namespace MockTests
			{
				public struct SomeStruct { }

				public interface IRequest<T>
					where T : class
				{
					Task<T> Send(object values, SomeStruct someStruct = default);
					Task Send(T message, SomeStruct someStruct = default);
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
				internal sealed class IRequestOfobjectCreateExpectations
					: global::Rocks.Expectations.ExpectationsV4
				{
					#pragma warning disable CS8618
					
					internal sealed class Handler0
						: global::Rocks.HandlerV4<global::System.Func<object, global::MockTests.SomeStruct, global::System.Threading.Tasks.Task<object>>, global::System.Threading.Tasks.Task<object>>
					{
						public global::Rocks.Argument<object> values { get; set; }
						public global::Rocks.Argument<global::MockTests.SomeStruct> someStruct { get; set; }
					}
					
					internal sealed class Handler1
						: global::Rocks.HandlerV4<global::System.Func<object, global::MockTests.SomeStruct, global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task>
					{
						public global::Rocks.Argument<object> message { get; set; }
						public global::Rocks.Argument<global::MockTests.SomeStruct> someStruct { get; set; }
					}
					
					#pragma warning restore CS8618
					
					private readonly global::System.Collections.Generic.List<global::MockTests.IRequestOfobjectCreateExpectations.Handler0> @handlers0 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.IRequestOfobjectCreateExpectations.Handler1> @handlers1 = new();
					
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
					
					private sealed class RockIRequestOfobject
						: global::MockTests.IRequest<object>
					{
						public RockIRequestOfobject(global::MockTests.IRequestOfobjectCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::Rocks.MemberIdentifier(0, "global::System.Threading.Tasks.Task<object> Send(object @values, global::MockTests.SomeStruct @someStruct)")]
						public global::System.Threading.Tasks.Task<object> Send(object @values, global::MockTests.SomeStruct @someStruct = default)
						{
							if (this.Expectations.handlers0.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers0)
								{
									if (@handler.values.IsValid(@values!) &&
										@handler.someStruct.IsValid(@someStruct!))
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback(@values!, @someStruct!) : @handler.ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for global::System.Threading.Tasks.Task<object> Send(object @values, global::MockTests.SomeStruct @someStruct = default)");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::System.Threading.Tasks.Task<object> Send(object @values, global::MockTests.SomeStruct @someStruct = default)");
						}
						
						[global::Rocks.MemberIdentifier(1, "global::System.Threading.Tasks.Task global::MockTests.IRequest<object>.Send(object @message, global::MockTests.SomeStruct @someStruct)")]
						global::System.Threading.Tasks.Task global::MockTests.IRequest<object>.Send(object @message, global::MockTests.SomeStruct @someStruct)
						{
							if (this.Expectations.handlers1.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers1)
								{
									if (@handler.message.IsValid(@message!) &&
										@handler.someStruct.IsValid(@someStruct!))
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback(@message!, @someStruct!) : @handler.ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for global::System.Threading.Tasks.Task global::MockTests.IRequest<object>.Send(object @message, global::MockTests.SomeStruct @someStruct)");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::System.Threading.Tasks.Task global::MockTests.IRequest<object>.Send(object @message, global::MockTests.SomeStruct @someStruct)");
						}
						
						private global::MockTests.IRequestOfobjectCreateExpectations Expectations { get; }
					}
					
					internal sealed class IRequestOfobjectMethodExpectations
					{
						internal IRequestOfobjectMethodExpectations(global::MockTests.IRequestOfobjectCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::MockTests.IRequestOfobjectCreateExpectations.Handler0, global::System.Func<object, global::MockTests.SomeStruct, global::System.Threading.Tasks.Task<object>>, global::System.Threading.Tasks.Task<object>> Send(global::Rocks.Argument<object> @values, global::Rocks.Argument<global::MockTests.SomeStruct> @someStruct)
						{
							global::System.ArgumentNullException.ThrowIfNull(@values);
							global::System.ArgumentNullException.ThrowIfNull(@someStruct);
							
							var handler = new global::MockTests.IRequestOfobjectCreateExpectations.Handler0
							{
								values = @values,
								someStruct = @someStruct.Transform(default),
							};
							
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						internal global::Rocks.AdornmentsV4<global::MockTests.IRequestOfobjectCreateExpectations.Handler0, global::System.Func<object, global::MockTests.SomeStruct, global::System.Threading.Tasks.Task<object>>, global::System.Threading.Tasks.Task<object>> Send(global::Rocks.Argument<object> @values, global::MockTests.SomeStruct @someStruct = default) =>
							this.Send(@values, global::Rocks.Arg.Is(@someStruct));
						
						private global::MockTests.IRequestOfobjectCreateExpectations Expectations { get; }
					}
					internal sealed class IRequestOfobjectExplicitMethodExpectationsForIRequestOfobject
					{
						internal IRequestOfobjectExplicitMethodExpectationsForIRequestOfobject(global::MockTests.IRequestOfobjectCreateExpectations expectations) =>
							this.Expectations = expectations;
					
						internal global::Rocks.AdornmentsV4<global::MockTests.IRequestOfobjectCreateExpectations.Handler1, global::System.Func<object, global::MockTests.SomeStruct, global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task> Send(global::Rocks.Argument<object> @message, global::Rocks.Argument<global::MockTests.SomeStruct> @someStruct)
						{
							global::System.ArgumentNullException.ThrowIfNull(@message);
							global::System.ArgumentNullException.ThrowIfNull(@someStruct);
							
							var handler = new global::MockTests.IRequestOfobjectCreateExpectations.Handler1
							{
								message = @message,
								someStruct = @someStruct,
							};
							
							this.Expectations.handlers1.Add(handler);
							return new(handler);
						}
						internal global::Rocks.AdornmentsV4<global::MockTests.IRequestOfobjectCreateExpectations.Handler1, global::System.Func<object, global::MockTests.SomeStruct, global::System.Threading.Tasks.Task>, global::System.Threading.Tasks.Task> Send(global::Rocks.Argument<object> @message, global::MockTests.SomeStruct @someStruct = default) =>
							this.Send(@message, global::Rocks.Arg.Is(@someStruct));
						
						private global::MockTests.IRequestOfobjectCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.IRequestOfobjectCreateExpectations.IRequestOfobjectMethodExpectations Methods { get; }
					internal global::MockTests.IRequestOfobjectCreateExpectations.IRequestOfobjectExplicitMethodExpectationsForIRequestOfobject ExplicitMethodsForIRequestOfobject { get; }
					
					internal IRequestOfobjectCreateExpectations() =>
						(this.Methods, this.ExplicitMethodsForIRequestOfobject) = (new(this), new(this));
					
					internal global::MockTests.IRequest<object> Instance()
					{
						if (!this.WasInstanceInvoked)
						{
							this.WasInstanceInvoked = true;
							var @mock = new RockIRequestOfobject(this);
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
			new[] { (typeof(RockAttributeGenerator), "MockTests.IRequestobject_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task CreateWhenGenericParameterHasOptionalDefaultValueAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			
			[assembly: RockCreate<IGenericDefault>]

			public interface IGenericDefault
			{
				void Setup<T>(T initialValue = default(T));
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal sealed class IGenericDefaultCreateExpectations
				: global::Rocks.Expectations.ExpectationsV4
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0<T>
					: global::Rocks.HandlerV4<global::System.Action<T>>
				{
					public global::Rocks.Argument<T> initialValue { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::Rocks.HandlerV4> @handlers0 = new();
				
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
				
				private sealed class RockIGenericDefault
					: global::IGenericDefault
				{
					public RockIGenericDefault(global::IGenericDefaultCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "void Setup<T>(T @initialValue)")]
					public void Setup<T>(T @initialValue = default!)
					{
						if (this.Expectations.handlers0.Count > 0)
						{
							var @foundMatch = false;
							
							foreach (var @genericHandler in this.Expectations.handlers0)
							{
								if (@genericHandler is global::IGenericDefaultCreateExpectations.Handler0<T> @handler)
								{
									if (@handler.initialValue.IsValid(@initialValue!))
									{
										@foundMatch = true;
										@handler.CallCount++;
										@handler.Callback?.Invoke(@initialValue!);
										break;
									}
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void Setup<T>(T @initialValue = default!)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Setup<T>(T @initialValue = default!)");
						}
					}
					
					private global::IGenericDefaultCreateExpectations Expectations { get; }
				}
				
				internal sealed class IGenericDefaultMethodExpectations
				{
					internal IGenericDefaultMethodExpectations(global::IGenericDefaultCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::IGenericDefaultCreateExpectations.Handler0<T>, global::System.Action<T>> Setup<T>(global::Rocks.Argument<T> @initialValue)
					{
						global::System.ArgumentNullException.ThrowIfNull(@initialValue);
						
						var handler = new global::IGenericDefaultCreateExpectations.Handler0<T>
						{
							initialValue = @initialValue.Transform(default!),
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					internal global::Rocks.AdornmentsV4<global::IGenericDefaultCreateExpectations.Handler0<T>, global::System.Action<T>> Setup<T>(T @initialValue = default!) =>
						this.Setup<T>(global::Rocks.Arg.Is(@initialValue));
					
					private global::IGenericDefaultCreateExpectations Expectations { get; }
				}
				
				internal global::IGenericDefaultCreateExpectations.IGenericDefaultMethodExpectations Methods { get; }
				
				internal IGenericDefaultCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::IGenericDefault Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockIGenericDefault(this);
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
			new[] { (typeof(RockAttributeGenerator), "IGenericDefault_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task MakeWhenGenericParameterHasOptionalDefaultValueAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			
			[assembly: RockMake<IGenericDefault>]

			public interface IGenericDefault
			{
				void Setup<T>(T initialValue = default(T));
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IGenericDefaultMakeExpectations
			{
				internal global::IGenericDefault Instance()
				{
					return new RockIGenericDefault();
				}
				
				private sealed class RockIGenericDefault
					: global::IGenericDefault
				{
					public RockIGenericDefault()
					{
					}
					
					public void Setup<T>(T @initialValue = default!)
					{
					}
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IGenericDefault_Rock_Make.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task CreateWithPositiveInfinityAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<IUseInfinity>]

			public interface IUseInfinity
			{
				void Use(double value = double.PositiveInfinity);
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal sealed class IUseInfinityCreateExpectations
				: global::Rocks.Expectations.ExpectationsV4
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.HandlerV4<global::System.Action<double>>
				{
					public global::Rocks.Argument<double> value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::IUseInfinityCreateExpectations.Handler0> @handlers0 = new();
				
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
				
				private sealed class RockIUseInfinity
					: global::IUseInfinity
				{
					public RockIUseInfinity(global::IUseInfinityCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "void Use(double @value)")]
					public void Use(double @value = double.PositiveInfinity)
					{
						if (this.Expectations.handlers0.Count > 0)
						{
							var @foundMatch = false;
							
							foreach (var @handler in this.Expectations.handlers0)
							{
								if (@handler.value.IsValid(@value!))
								{
									@foundMatch = true;
									@handler.CallCount++;
									@handler.Callback?.Invoke(@value!);
									break;
								}
							}
							
							if (!@foundMatch)
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for void Use(double @value = double.PositiveInfinity)");
							}
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Use(double @value = double.PositiveInfinity)");
						}
					}
					
					private global::IUseInfinityCreateExpectations Expectations { get; }
				}
				
				internal sealed class IUseInfinityMethodExpectations
				{
					internal IUseInfinityMethodExpectations(global::IUseInfinityCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::IUseInfinityCreateExpectations.Handler0, global::System.Action<double>> Use(global::Rocks.Argument<double> @value)
					{
						global::System.ArgumentNullException.ThrowIfNull(@value);
						
						var handler = new global::IUseInfinityCreateExpectations.Handler0
						{
							value = @value.Transform(double.PositiveInfinity),
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					internal global::Rocks.AdornmentsV4<global::IUseInfinityCreateExpectations.Handler0, global::System.Action<double>> Use(double @value = double.PositiveInfinity) =>
						this.Use(global::Rocks.Arg.Is(@value));
					
					private global::IUseInfinityCreateExpectations Expectations { get; }
				}
				
				internal global::IUseInfinityCreateExpectations.IUseInfinityMethodExpectations Methods { get; }
				
				internal IUseInfinityCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::IUseInfinity Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockIUseInfinity(this);
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
			new[] { (typeof(RockAttributeGenerator), "IUseInfinity_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task MakeWithPositiveInfinityAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockMake<IUseInfinity>]

			public interface IUseInfinity
			{
			  void Use(double value = double.PositiveInfinity);
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IUseInfinityMakeExpectations
			{
				internal global::IUseInfinity Instance()
				{
					return new RockIUseInfinity();
				}
				
				private sealed class RockIUseInfinity
					: global::IUseInfinity
				{
					public RockIUseInfinity()
					{
					}
					
					public void Use(double @value = double.PositiveInfinity)
					{
					}
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IUseInfinity_Rock_Make.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}
}