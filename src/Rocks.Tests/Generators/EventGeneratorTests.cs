﻿using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class EventGeneratorTests
{
	[Test]
	public static async Task GenerateWithOpenGenericInMethodAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<IOpenGenericAndEvent>]
			
			public interface IOpenGenericAndEvent
			{
				TService Get<TService>();
				event EventHandler MyEvent;
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IOpenGenericAndEventCreateExpectations
				: global::Rocks.Expectations
			{
				internal sealed class Handler0<TService>
					: global::Rocks.Handler<global::System.Func<TService>, TService>
				{ }
				private global::Rocks.Handlers<global::Rocks.Handler>? @handlers0;
				
				public override void Verify()
				{
					if (this.WasInstanceInvoked)
					{
						var failures = new global::System.Collections.Generic.List<string>();
				
						if (this.handlers0 is not null) { failures.AddRange(this.Verify(this.handlers0, 0)); }
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class Mock
					: global::IOpenGenericAndEvent, global::Rocks.IRaiseEvents
				{
					public Mock(global::IOpenGenericAndEventCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "TService Get<TService>()")]
					public TService Get<TService>()
					{
						if (this.Expectations.handlers0 is not null)
						{
							foreach (var @genericHandler in this.Expectations.handlers0)
							{
								if (@genericHandler is global::IOpenGenericAndEventCreateExpectations.Handler0<TService> @handler)
								{
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback() : @handler.ReturnValue;
										@handler.RaiseEvents(this);
										return @result!;
									}
								}
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers match for TService Get<TService>()");
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for TService Get<TService>()");
					}
					
					#pragma warning disable CS0067
					public event global::System.EventHandler? MyEvent;
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
					
					private global::IOpenGenericAndEventCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::IOpenGenericAndEventCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::IOpenGenericAndEventCreateExpectations.Adornments.AdornmentsForHandler0<TService> Get<TService>()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						var handler = new global::IOpenGenericAndEventCreateExpectations.Handler0<TService>();
						if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(handler); }
						else { this.Expectations.handlers0.Add(handler); }
						return new(handler);
					}
					
					private global::IOpenGenericAndEventCreateExpectations Expectations { get; }
				}
				
				internal global::IOpenGenericAndEventCreateExpectations.MethodExpectations Methods { get; }
				
				internal IOpenGenericAndEventCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::IOpenGenericAndEvent Instance()
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
					public interface IAdornmentsForIOpenGenericAndEvent<TAdornments>
						: global::Rocks.IAdornments<TAdornments>
						where TAdornments : IAdornmentsForIOpenGenericAndEvent<TAdornments>
					{ }
					
					public sealed class AdornmentsForHandler0<TService>
						: global::Rocks.Adornments<AdornmentsForHandler0<TService>, global::IOpenGenericAndEventCreateExpectations.Handler0<TService>, global::System.Func<TService>, TService>, IAdornmentsForIOpenGenericAndEvent<AdornmentsForHandler0<TService>>
					{ 
						public AdornmentsForHandler0(global::IOpenGenericAndEventCreateExpectations.Handler0<TService> handler)
							: base(handler) { }				
					}
				}
			}
			
			internal static class IOpenGenericAndEventAdornmentsEventExtensions
			{
				internal static TAdornments RaiseMyEvent<TAdornments>(this TAdornments self, global::System.EventArgs args) where TAdornments : global::IOpenGenericAndEventCreateExpectations.Adornments.IAdornmentsForIOpenGenericAndEvent<TAdornments> => 
					self.AddRaiseEvent(new("MyEvent", args));
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			[(typeof(RockAttributeGenerator), "IOpenGenericAndEvent_Rock_Create.g.cs", generatedCode)],
			[]);
	}

	[Test]
	public static async Task GenerateWithAbstractClassAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<AbstractClassMethodReturnWithEvents>]
			
			public abstract class AbstractClassMethodReturnWithEvents
			{
				public abstract int NoParameters();
				public abstract event EventHandler MyEvent;
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class AbstractClassMethodReturnWithEventsCreateExpectations
				: global::Rocks.Expectations
			{
				#pragma warning disable CS8618
				internal sealed class Handler0
					: global::Rocks.Handler<global::System.Func<object?, bool>, bool>
				{
					public global::Rocks.Argument<object?> @obj { get; set; }
				}
				private global::Rocks.Handlers<global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler0>? @handlers0;
				internal sealed class Handler1
					: global::Rocks.Handler<global::System.Func<int>, int>
				{ }
				private global::Rocks.Handlers<global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler1>? @handlers1;
				internal sealed class Handler2
					: global::Rocks.Handler<global::System.Func<string?>, string?>
				{ }
				private global::Rocks.Handlers<global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler2>? @handlers2;
				internal sealed class Handler3
					: global::Rocks.Handler<global::System.Func<int>, int>
				{ }
				private global::Rocks.Handlers<global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler3>? @handlers3;
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
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class Mock
					: global::AbstractClassMethodReturnWithEvents, global::Rocks.IRaiseEvents
				{
					public Mock(global::AbstractClassMethodReturnWithEventsCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "bool Equals(object? @obj)")]
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
									@handler.RaiseEvents(this);
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
						if (this.Expectations.handlers1 is not null)
						{
							var @handler = this.Expectations.handlers1.First;
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							@handler.RaiseEvents(this);
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
						if (this.Expectations.handlers2 is not null)
						{
							var @handler = this.Expectations.handlers2.First;
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							@handler.RaiseEvents(this);
							return @result!;
						}
						else
						{
							return base.ToString();
						}
					}
					
					[global::Rocks.MemberIdentifier(3, "int NoParameters()")]
					public override int NoParameters()
					{
						if (this.Expectations.handlers3 is not null)
						{
							var @handler = this.Expectations.handlers3.First;
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							@handler.RaiseEvents(this);
							return @result!;
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for int NoParameters()");
					}
					
					#pragma warning disable CS0067
					public override event global::System.EventHandler? MyEvent;
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
					
					private global::AbstractClassMethodReturnWithEventsCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::AbstractClassMethodReturnWithEventsCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::AbstractClassMethodReturnWithEventsCreateExpectations.Adornments.AdornmentsForHandler0 Equals(global::Rocks.Argument<object?> @obj)
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						global::System.ArgumentNullException.ThrowIfNull(@obj);
						
						var @handler = new global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler0
						{
							@obj = @obj,
						};
						
						if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(@handler); }
						else { this.Expectations.handlers0.Add(@handler); }
						return new(@handler);
					}
					
					internal new global::AbstractClassMethodReturnWithEventsCreateExpectations.Adornments.AdornmentsForHandler1 GetHashCode()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						var handler = new global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler1();
						if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(handler); }
						else { this.Expectations.handlers1.Add(handler); }
						return new(handler);
					}
					
					internal new global::AbstractClassMethodReturnWithEventsCreateExpectations.Adornments.AdornmentsForHandler2 ToString()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						var handler = new global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler2();
						if (this.Expectations.handlers2 is null ) { this.Expectations.handlers2 = new(handler); }
						else { this.Expectations.handlers2.Add(handler); }
						return new(handler);
					}
					
					internal global::AbstractClassMethodReturnWithEventsCreateExpectations.Adornments.AdornmentsForHandler3 NoParameters()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						var handler = new global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler3();
						if (this.Expectations.handlers3 is null ) { this.Expectations.handlers3 = new(handler); }
						else { this.Expectations.handlers3.Add(handler); }
						return new(handler);
					}
					
					private global::AbstractClassMethodReturnWithEventsCreateExpectations Expectations { get; }
				}
				
				internal global::AbstractClassMethodReturnWithEventsCreateExpectations.MethodExpectations Methods { get; }
				
				internal AbstractClassMethodReturnWithEventsCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::AbstractClassMethodReturnWithEvents Instance()
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
					public interface IAdornmentsForAbstractClassMethodReturnWithEvents<TAdornments>
						: global::Rocks.IAdornments<TAdornments>
						where TAdornments : IAdornmentsForAbstractClassMethodReturnWithEvents<TAdornments>
					{ }
					
					public sealed class AdornmentsForHandler0
						: global::Rocks.Adornments<AdornmentsForHandler0, global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler0, global::System.Func<object?, bool>, bool>, IAdornmentsForAbstractClassMethodReturnWithEvents<AdornmentsForHandler0>
					{ 
						public AdornmentsForHandler0(global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler0 handler)
							: base(handler) { }				
					}
					public sealed class AdornmentsForHandler1
						: global::Rocks.Adornments<AdornmentsForHandler1, global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler1, global::System.Func<int>, int>, IAdornmentsForAbstractClassMethodReturnWithEvents<AdornmentsForHandler1>
					{ 
						public AdornmentsForHandler1(global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler1 handler)
							: base(handler) { }				
					}
					public sealed class AdornmentsForHandler2
						: global::Rocks.Adornments<AdornmentsForHandler2, global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler2, global::System.Func<string?>, string?>, IAdornmentsForAbstractClassMethodReturnWithEvents<AdornmentsForHandler2>
					{ 
						public AdornmentsForHandler2(global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler2 handler)
							: base(handler) { }				
					}
					public sealed class AdornmentsForHandler3
						: global::Rocks.Adornments<AdornmentsForHandler3, global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler3, global::System.Func<int>, int>, IAdornmentsForAbstractClassMethodReturnWithEvents<AdornmentsForHandler3>
					{ 
						public AdornmentsForHandler3(global::AbstractClassMethodReturnWithEventsCreateExpectations.Handler3 handler)
							: base(handler) { }				
					}
				}
			}
			
			internal static class AbstractClassMethodReturnWithEventsAdornmentsEventExtensions
			{
				internal static TAdornments RaiseMyEvent<TAdornments>(this TAdornments self, global::System.EventArgs args) where TAdornments : global::AbstractClassMethodReturnWithEventsCreateExpectations.Adornments.IAdornmentsForAbstractClassMethodReturnWithEvents<TAdornments> => 
					self.AddRaiseEvent(new("MyEvent", args));
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			[(typeof(RockAttributeGenerator), "AbstractClassMethodReturnWithEvents_Rock_Create.g.cs", generatedCode)],
			[]);
	}

	[Test]
	public static async Task GenerateWithExplicitInterfacesAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			
			[assembly: RockCreate<IExplicitInterfaceImplementation>]

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
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IExplicitInterfaceImplementationCreateExpectations
				: global::Rocks.Expectations
			{
				internal sealed class Handler0
					: global::Rocks.Handler<global::System.Action>
				{ }
				private global::Rocks.Handlers<global::IExplicitInterfaceImplementationCreateExpectations.Handler0>? @handlers0;
				internal sealed class Handler1
					: global::Rocks.Handler<global::System.Action>
				{ }
				private global::Rocks.Handlers<global::IExplicitInterfaceImplementationCreateExpectations.Handler1>? @handlers1;
				
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
					: global::IExplicitInterfaceImplementation, global::Rocks.IRaiseEvents
				{
					public Mock(global::IExplicitInterfaceImplementationCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "void global::IExplicitInterfaceImplementationOne.A()")]
					void global::IExplicitInterfaceImplementationOne.A()
					{
						if (this.Expectations.handlers0 is not null)
						{
							var @handler = this.Expectations.handlers0.First;
							@handler.CallCount++;
							@handler.Callback?.Invoke();
							@handler.RaiseEvents(this);
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void global::IExplicitInterfaceImplementationOne.A()");
						}
					}
					
					[global::Rocks.MemberIdentifier(1, "void global::IExplicitInterfaceImplementationTwo.A()")]
					void global::IExplicitInterfaceImplementationTwo.A()
					{
						if (this.Expectations.handlers1 is not null)
						{
							var @handler = this.Expectations.handlers1.First;
							@handler.CallCount++;
							@handler.Callback?.Invoke();
							@handler.RaiseEvents(this);
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void global::IExplicitInterfaceImplementationTwo.A()");
						}
					}
					
					#pragma warning disable CS0067
					private global::System.EventHandler? IExplicitInterfaceImplementationOne_C;
					event global::System.EventHandler? global::IExplicitInterfaceImplementationOne.C
					{
						add => this.IExplicitInterfaceImplementationOne_C += value;
						remove => this.IExplicitInterfaceImplementationOne_C -= value;
					}
					private global::System.EventHandler? IExplicitInterfaceImplementationTwo_C;
					event global::System.EventHandler? global::IExplicitInterfaceImplementationTwo.C
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
					
					private global::IExplicitInterfaceImplementationCreateExpectations Expectations { get; }
				}
				
				internal sealed class ExplicitMethodExpectationsForIExplicitInterfaceImplementationOne
				{
					internal ExplicitMethodExpectationsForIExplicitInterfaceImplementationOne(global::IExplicitInterfaceImplementationCreateExpectations expectations) =>
						this.Expectations = expectations;
				
					internal global::IExplicitInterfaceImplementationCreateExpectations.Adornments.AdornmentsForHandler0 A()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						var handler = new global::IExplicitInterfaceImplementationCreateExpectations.Handler0();
						if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(handler); }
						else { this.Expectations.handlers0.Add(handler); }
						return new(handler);
					}
					
					private global::IExplicitInterfaceImplementationCreateExpectations Expectations { get; }
				}
				internal sealed class ExplicitMethodExpectationsForIExplicitInterfaceImplementationTwo
				{
					internal ExplicitMethodExpectationsForIExplicitInterfaceImplementationTwo(global::IExplicitInterfaceImplementationCreateExpectations expectations) =>
						this.Expectations = expectations;
				
					internal global::IExplicitInterfaceImplementationCreateExpectations.Adornments.AdornmentsForHandler1 A()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						var handler = new global::IExplicitInterfaceImplementationCreateExpectations.Handler1();
						if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(handler); }
						else { this.Expectations.handlers1.Add(handler); }
						return new(handler);
					}
					
					private global::IExplicitInterfaceImplementationCreateExpectations Expectations { get; }
				}
				
				internal global::IExplicitInterfaceImplementationCreateExpectations.ExplicitMethodExpectationsForIExplicitInterfaceImplementationOne ExplicitMethodsForIExplicitInterfaceImplementationOne { get; }
				internal global::IExplicitInterfaceImplementationCreateExpectations.ExplicitMethodExpectationsForIExplicitInterfaceImplementationTwo ExplicitMethodsForIExplicitInterfaceImplementationTwo { get; }
				
				internal IExplicitInterfaceImplementationCreateExpectations() =>
					(this.ExplicitMethodsForIExplicitInterfaceImplementationOne, this.ExplicitMethodsForIExplicitInterfaceImplementationTwo) = (new(this), new(this));
				
				internal global::IExplicitInterfaceImplementation Instance()
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
					public interface IAdornmentsForIExplicitInterfaceImplementation<TAdornments>
						: global::Rocks.IAdornments<TAdornments>
						where TAdornments : IAdornmentsForIExplicitInterfaceImplementation<TAdornments>
					{ }
					
					public sealed class AdornmentsForHandler0
						: global::Rocks.Adornments<AdornmentsForHandler0, global::IExplicitInterfaceImplementationCreateExpectations.Handler0, global::System.Action>, IAdornmentsForIExplicitInterfaceImplementation<AdornmentsForHandler0>
					{ 
						public AdornmentsForHandler0(global::IExplicitInterfaceImplementationCreateExpectations.Handler0 handler)
							: base(handler) { }				
					}
					public sealed class AdornmentsForHandler1
						: global::Rocks.Adornments<AdornmentsForHandler1, global::IExplicitInterfaceImplementationCreateExpectations.Handler1, global::System.Action>, IAdornmentsForIExplicitInterfaceImplementation<AdornmentsForHandler1>
					{ 
						public AdornmentsForHandler1(global::IExplicitInterfaceImplementationCreateExpectations.Handler1 handler)
							: base(handler) { }				
					}
				}
			}
			
			internal static class IExplicitInterfaceImplementationAdornmentsEventExtensions
			{
				internal static TAdornments RaiseC<TAdornments>(this TAdornments self, global::System.EventArgs args) where TAdornments : global::IExplicitInterfaceImplementationCreateExpectations.Adornments.IAdornmentsForIExplicitInterfaceImplementation<TAdornments> => 
					self.AddRaiseEvent(new("C", args));
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			[(typeof(RockAttributeGenerator), "IExplicitInterfaceImplementation_Rock_Create.g.cs", generatedCode)],
			[]);
	}

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
					private global::Rocks.Handlers<global::MockTests.IHaveEventsCreateExpectations.Handler0>? @handlers0;
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							if (this.handlers0 is not null) { failures.AddRange(this.Verify(this.handlers0, 0)); }
					
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
							if (this.Expectations.handlers0 is not null)
							{
								var @handler = this.Expectations.handlers0.First;
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
						
						internal global::MockTests.IHaveEventsCreateExpectations.Adornments.AdornmentsForHandler0 A()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							var handler = new global::MockTests.IHaveEventsCreateExpectations.Handler0();
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(handler); }
							else { this.Expectations.handlers0.Add(handler); }
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
					
					internal static class Adornments
					{
						public interface IAdornmentsForIHaveEvents<TAdornments>
							: global::Rocks.IAdornments<TAdornments>
							where TAdornments : IAdornmentsForIHaveEvents<TAdornments>
						{ }
						
						public sealed class AdornmentsForHandler0
							: global::Rocks.Adornments<AdornmentsForHandler0, global::MockTests.IHaveEventsCreateExpectations.Handler0, global::System.Action>, IAdornmentsForIHaveEvents<AdornmentsForHandler0>
						{ 
							public AdornmentsForHandler0(global::MockTests.IHaveEventsCreateExpectations.Handler0 handler)
								: base(handler) { }				
						}
					}
				}
				
				internal static class IHaveEventsAdornmentsEventExtensions
				{
					internal static TAdornments RaiseServerMaintenanceEvent<TAdornments>(this TAdornments self, global::MockTests.ServerMaintenanceEvent args) where TAdornments : global::MockTests.IHaveEventsCreateExpectations.Adornments.IAdornmentsForIHaveEvents<TAdornments> => 
						self.AddRaiseEvent(new("ServerMaintenanceEvent", args));
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			[(typeof(RockAttributeGenerator), "MockTests.IHaveEvents_Rock_Create.g.cs", generatedCode)],
			[]);
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
					private global::Rocks.Handlers<global::MockTests.IHaveEventsCreateExpectations.Handler0>? @handlers0;
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							if (this.handlers0 is not null) { failures.AddRange(this.Verify(this.handlers0, 0)); }
					
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
							if (this.Expectations.handlers0 is not null)
							{
								var @handler = this.Expectations.handlers0.First;
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
						
						internal global::MockTests.IHaveEventsCreateExpectations.Adornments.AdornmentsForHandler0 A()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							var handler = new global::MockTests.IHaveEventsCreateExpectations.Handler0();
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(handler); }
							else { this.Expectations.handlers0.Add(handler); }
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
					
					internal static class Adornments
					{
						public interface IAdornmentsForIHaveEvents<TAdornments>
							: global::Rocks.IAdornments<TAdornments>
							where TAdornments : IAdornmentsForIHaveEvents<TAdornments>
						{ }
						
						public sealed class AdornmentsForHandler0
							: global::Rocks.Adornments<AdornmentsForHandler0, global::MockTests.IHaveEventsCreateExpectations.Handler0, global::System.Action>, IAdornmentsForIHaveEvents<AdornmentsForHandler0>
						{ 
							public AdornmentsForHandler0(global::MockTests.IHaveEventsCreateExpectations.Handler0 handler)
								: base(handler) { }				
						}
					}
				}
				
				internal static class IHaveEventsAdornmentsEventExtensions
				{
					internal static TAdornments RaiseC<TAdornments>(this TAdornments self, global::System.EventArgs args) where TAdornments : global::MockTests.IHaveEventsCreateExpectations.Adornments.IAdornmentsForIHaveEvents<TAdornments> => 
						self.AddRaiseEvent(new("C", args));
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			[(typeof(RockAttributeGenerator), "MockTests.IHaveEvents_Rock_Create.g.cs", generatedCode)],
			[]);
	}
}