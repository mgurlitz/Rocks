﻿using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class EventGeneratorTests
{
	[Test]
	public static async Task GenerateWhenArgsTypeDoesNotDeriveFromEventArgsAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			
			[assembly: RockCreate<MockTests.IHaveEvents>]

			namespace MockTests
			{
				public class ServerMaintenanceEvent { }

				public interface IHaveEvents
				{
					void A();
					event EventHandler<ServerMaintenanceEvent> ServerMaintenanceEvent;
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class IHaveEventsCreateExpectations
					: global::Rocks.Expectations
				{
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Action>
					{ }
					
					private readonly global::System.Collections.Generic.List<global::MockTests.IHaveEventsCreateExpectations.Handler0> @handlers0 = new();
					
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
						: global::MockTests.IHaveEvents, global::Rocks.IRaiseEvents
					{
						public Mock(global::MockTests.IHaveEventsCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::Rocks.MemberIdentifier(0, "void A()")]
						public void A()
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
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void A()");
							}
						}
						
						#pragma warning disable CS0067
						public event global::System.EventHandler<global::MockTests.ServerMaintenanceEvent>? ServerMaintenanceEvent;
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
						
						private global::MockTests.IHaveEventsCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.IHaveEventsCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.IHaveEventsCreateExpectations.Handler0, global::System.Action> A()
						{
							var handler = new global::MockTests.IHaveEventsCreateExpectations.Handler0();
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.IHaveEventsCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.IHaveEventsCreateExpectations.MethodExpectations Methods { get; }
					
					internal IHaveEventsCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal global::MockTests.IHaveEvents Instance()
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
			new[] { (typeof(RockAttributeGenerator), "MockTests.IHaveEvents_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<MockTests.IHaveEvents>]

			namespace MockTests
			{
				public interface IHaveEvents
				{
					void A();
					event EventHandler C;
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class IHaveEventsCreateExpectations
					: global::Rocks.Expectations
				{
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Action>
					{ }
					
					private readonly global::System.Collections.Generic.List<global::MockTests.IHaveEventsCreateExpectations.Handler0> @handlers0 = new();
					
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
						: global::MockTests.IHaveEvents, global::Rocks.IRaiseEvents
					{
						public Mock(global::MockTests.IHaveEventsCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::Rocks.MemberIdentifier(0, "void A()")]
						public void A()
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
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void A()");
							}
						}
						
						#pragma warning disable CS0067
						public event global::System.EventHandler? C;
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
						
						private global::MockTests.IHaveEventsCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.IHaveEventsCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.IHaveEventsCreateExpectations.Handler0, global::System.Action> A()
						{
							var handler = new global::MockTests.IHaveEventsCreateExpectations.Handler0();
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.IHaveEventsCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.IHaveEventsCreateExpectations.MethodExpectations Methods { get; }
					
					internal IHaveEventsCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal global::MockTests.IHaveEvents Instance()
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
			new[] { (typeof(RockAttributeGenerator), "MockTests.IHaveEvents_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateWithExplicitMembersAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<MockTests.IExplicitInterfaceImplementation>]

			namespace MockTests
			{
				public interface IExplicitInterfaceImplementationOne
				{
					void A();
					event EventHandler C;
				}

				public interface IExplicitInterfaceImplementationTwo
				{
					void A();
					event EventHandler C;
				}

				public interface IExplicitInterfaceImplementation
					: IExplicitInterfaceImplementationOne, IExplicitInterfaceImplementationTwo
				{ }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class IExplicitInterfaceImplementationCreateExpectations
					: global::Rocks.Expectations
				{
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Action>
					{ }
					
					internal sealed class Handler1
						: global::Rocks.Handler<global::System.Action>
					{ }
					
					private readonly global::System.Collections.Generic.List<global::MockTests.IExplicitInterfaceImplementationCreateExpectations.Handler0> @handlers0 = new();
					private readonly global::System.Collections.Generic.List<global::MockTests.IExplicitInterfaceImplementationCreateExpectations.Handler1> @handlers1 = new();
					
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
						: global::MockTests.IExplicitInterfaceImplementation, global::Rocks.IRaiseEvents
					{
						public Mock(global::MockTests.IExplicitInterfaceImplementationCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::Rocks.MemberIdentifier(0, "void global::MockTests.IExplicitInterfaceImplementationOne.A()")]
						void global::MockTests.IExplicitInterfaceImplementationOne.A()
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
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void global::MockTests.IExplicitInterfaceImplementationOne.A()");
							}
						}
						
						[global::Rocks.MemberIdentifier(1, "void global::MockTests.IExplicitInterfaceImplementationTwo.A()")]
						void global::MockTests.IExplicitInterfaceImplementationTwo.A()
						{
							if (this.Expectations.handlers1.Count > 0)
							{
								var @handler = this.Expectations.handlers1[0];
								@handler.CallCount++;
								@handler.Callback?.Invoke();
								@handler.RaiseEvents(this);
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void global::MockTests.IExplicitInterfaceImplementationTwo.A()");
							}
						}
						
						#pragma warning disable CS0067
						private global::System.EventHandler? IExplicitInterfaceImplementationOne_C;
						event global::System.EventHandler? global::MockTests.IExplicitInterfaceImplementationOne.C
						{
							add => this.IExplicitInterfaceImplementationOne_C += value;
							remove => this.IExplicitInterfaceImplementationOne_C -= value;
						}
						private global::System.EventHandler? IExplicitInterfaceImplementationTwo_C;
						event global::System.EventHandler? global::MockTests.IExplicitInterfaceImplementationTwo.C
						{
							add => this.IExplicitInterfaceImplementationTwo_C += value;
							remove => this.IExplicitInterfaceImplementationTwo_C -= value;
						}
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
						
						private global::MockTests.IExplicitInterfaceImplementationCreateExpectations Expectations { get; }
					}
					
					internal sealed class ExplicitMethodExpectationsForIExplicitInterfaceImplementationOne
					{
						internal ExplicitMethodExpectationsForIExplicitInterfaceImplementationOne(global::MockTests.IExplicitInterfaceImplementationCreateExpectations expectations) =>
							this.Expectations = expectations;
					
						internal global::Rocks.Adornments<global::MockTests.IExplicitInterfaceImplementationCreateExpectations.Handler0, global::System.Action> A()
						{
							var handler = new global::MockTests.IExplicitInterfaceImplementationCreateExpectations.Handler0();
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.IExplicitInterfaceImplementationCreateExpectations Expectations { get; }
					}
					internal sealed class ExplicitMethodExpectationsForIExplicitInterfaceImplementationTwo
					{
						internal ExplicitMethodExpectationsForIExplicitInterfaceImplementationTwo(global::MockTests.IExplicitInterfaceImplementationCreateExpectations expectations) =>
							this.Expectations = expectations;
					
						internal global::Rocks.Adornments<global::MockTests.IExplicitInterfaceImplementationCreateExpectations.Handler1, global::System.Action> A()
						{
							var handler = new global::MockTests.IExplicitInterfaceImplementationCreateExpectations.Handler1();
							this.Expectations.handlers1.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.IExplicitInterfaceImplementationCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.IExplicitInterfaceImplementationCreateExpectations.ExplicitMethodExpectationsForIExplicitInterfaceImplementationOne ExplicitMethodsForIExplicitInterfaceImplementationOne { get; }
					internal global::MockTests.IExplicitInterfaceImplementationCreateExpectations.ExplicitMethodExpectationsForIExplicitInterfaceImplementationTwo ExplicitMethodsForIExplicitInterfaceImplementationTwo { get; }
					
					internal IExplicitInterfaceImplementationCreateExpectations() =>
						(this.ExplicitMethodsForIExplicitInterfaceImplementationOne, this.ExplicitMethodsForIExplicitInterfaceImplementationTwo) = (new(this), new(this));
					
					internal global::MockTests.IExplicitInterfaceImplementation Instance()
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
			new[] { (typeof(RockAttributeGenerator), "MockTests.IExplicitInterfaceImplementation_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}
}