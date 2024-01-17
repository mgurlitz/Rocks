﻿using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class ExplicitImplementationGeneratorTests
{
	[Test]
	public static async Task CreateWithExplicitEventsAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<MockTests.IHtmlMediaElement>]

			namespace EventStuff
			{
				public class Event : EventArgs { }

				public delegate void DomEventHandler(object sender, Event ev);
			}

			namespace GlobalHandlers
			{
				public interface IGlobalEventHandlers
				{
					event global::EventStuff.DomEventHandler CanPlay;
				}
			}

			namespace Controllers
			{
				public interface IMediaController
				{
					event global::EventStuff.DomEventHandler CanPlay;
				}
			}

			namespace MockTests
			{
				public interface IHtmlMediaElement
					: global::GlobalHandlers.IGlobalEventHandlers, global::Controllers.IMediaController
				{
					void Foo();
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class IHtmlMediaElementCreateExpectations
					: global::Rocks.Expectations
				{
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Action>
					{ }
					
					private global::System.Collections.Generic.List<global::MockTests.IHtmlMediaElementCreateExpectations.Handler0>? @handlers0;
					
					public override void Verify()
					{
						if (this.WasInstanceInvoked)
						{
							var failures = new global::System.Collections.Generic.List<string>();
					
							if (this.handlers0?.Count > 0) { failures.AddRange(this.Verify(this.handlers0, 0)); }
					
							if (failures.Count > 0)
							{
								throw new global::Rocks.Exceptions.VerificationException(failures);
							}
						}
					}
					
					private sealed class Mock
						: global::MockTests.IHtmlMediaElement, global::Rocks.IRaiseEvents
					{
						public Mock(global::MockTests.IHtmlMediaElementCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::Rocks.MemberIdentifier(0, "void Foo()")]
						public void Foo()
						{
							if (this.Expectations.handlers0?.Count > 0)
							{
								var @handler = this.Expectations.handlers0[0];
								@handler.CallCount++;
								@handler.Callback?.Invoke();
								@handler.RaiseEvents(this);
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Foo()");
							}
						}
						
						#pragma warning disable CS0067
						private global::EventStuff.DomEventHandler? IGlobalEventHandlers_CanPlay;
						event global::EventStuff.DomEventHandler? global::GlobalHandlers.IGlobalEventHandlers.CanPlay
						{
							add => this.IGlobalEventHandlers_CanPlay += value;
							remove => this.IGlobalEventHandlers_CanPlay -= value;
						}
						private global::EventStuff.DomEventHandler? IMediaController_CanPlay;
						event global::EventStuff.DomEventHandler? global::Controllers.IMediaController.CanPlay
						{
							add => this.IMediaController_CanPlay += value;
							remove => this.IMediaController_CanPlay -= value;
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
						
						private global::MockTests.IHtmlMediaElementCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.IHtmlMediaElementCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.IHtmlMediaElementCreateExpectations.Handler0, global::System.Action> Foo()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
							var handler = new global::MockTests.IHtmlMediaElementCreateExpectations.Handler0();
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.IHtmlMediaElementCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.IHtmlMediaElementCreateExpectations.MethodExpectations Methods { get; }
					
					internal IHtmlMediaElementCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal global::MockTests.IHtmlMediaElement Instance()
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
				
				internal static class IHtmlMediaElementAdornmentsEventExtensions
				{
					internal static global::Rocks.Adornments<global::MockTests.IHtmlMediaElementCreateExpectations.Handler0, global::System.Action> RaiseCanPlay(this global::Rocks.Adornments<global::MockTests.IHtmlMediaElementCreateExpectations.Handler0, global::System.Action> self, global::EventStuff.Event args) => 
						self.AddRaiseEvent(new("CanPlay", args));
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.IHtmlMediaElement_Rock_Create.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task MakeWithExplicitEventsAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockMake<MockTests.IHtmlMediaElement>]

			namespace EventStuff
			{
				public class Event : EventArgs { }

				public delegate void DomEventHandler(object sender, Event ev);
			}

			namespace GlobalHandlers
			{
				public interface IGlobalEventHandlers
				{
					event global::EventStuff.DomEventHandler CanPlay;
				}
			}

			namespace Controllers
			{
				public interface IMediaController
				{
					event global::EventStuff.DomEventHandler CanPlay;
				}
			}

			namespace MockTests
			{
				public interface IHtmlMediaElement
					: global::GlobalHandlers.IGlobalEventHandlers, global::Controllers.IMediaController
				{
					void Foo();
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class IHtmlMediaElementMakeExpectations
				{
					internal global::MockTests.IHtmlMediaElement Instance()
					{
						return new Mock();
					}
					
					private sealed class Mock
						: global::MockTests.IHtmlMediaElement
					{
						public Mock()
						{
						}
						
						public void Foo()
						{
						}
						
						#pragma warning disable CS0067
						private global::EventStuff.DomEventHandler? IGlobalEventHandlers_CanPlay;
						event global::EventStuff.DomEventHandler? global::GlobalHandlers.IGlobalEventHandlers.CanPlay
						{
							add => this.IGlobalEventHandlers_CanPlay += value;
							remove => this.IGlobalEventHandlers_CanPlay -= value;
						}
						private global::EventStuff.DomEventHandler? IMediaController_CanPlay;
						event global::EventStuff.DomEventHandler? global::Controllers.IMediaController.CanPlay
						{
							add => this.IMediaController_CanPlay += value;
							remove => this.IMediaController_CanPlay -= value;
						}
						#pragma warning restore CS0067
					}
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.IHtmlMediaElement_Rock_Make.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task CreateWithExplicitPropertySetterAsync()
	{
		var code =
			"""
			using Rocks;
			
			[assembly: RockCreate<ILeftRight>]

			namespace Values
			{
				public sealed class Information { }
			}

			public interface ILeft
			{
				Values.Information Value { get; set; }
			}
			
			public interface IRight
			{
				Values.Information Value { get; set; }
			}

			public interface ILeftRight
				: ILeft, IRight { }
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class ILeftRightCreateExpectations
				: global::Rocks.Expectations
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.Handler<global::System.Func<global::Values.Information>, global::Values.Information>
				{ }
				
				internal sealed class Handler1
					: global::Rocks.Handler<global::System.Action<global::Values.Information>>
				{
					public global::Rocks.Argument<global::Values.Information> @value { get; set; }
				}
				
				internal sealed class Handler2
					: global::Rocks.Handler<global::System.Func<global::Values.Information>, global::Values.Information>
				{ }
				
				internal sealed class Handler3
					: global::Rocks.Handler<global::System.Action<global::Values.Information>>
				{
					public global::Rocks.Argument<global::Values.Information> @value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private global::System.Collections.Generic.List<global::ILeftRightCreateExpectations.Handler0>? @handlers0;
				private global::System.Collections.Generic.List<global::ILeftRightCreateExpectations.Handler1>? @handlers1;
				private global::System.Collections.Generic.List<global::ILeftRightCreateExpectations.Handler2>? @handlers2;
				private global::System.Collections.Generic.List<global::ILeftRightCreateExpectations.Handler3>? @handlers3;
				
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
					: global::ILeftRight
				{
					public Mock(global::ILeftRightCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "global::ILeft.get_Value()")]
					[global::Rocks.MemberIdentifier(1, "global::ILeft.set_Value(value)")]
					global::Values.Information global::ILeft.Value
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
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::ILeft.get_Value())");
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
											throw new global::Rocks.Exceptions.ExpectationException("No handlers match for global::ILeft.set_Value(value)");
										}
										
										break;
									}
								}
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::ILeft.set_Value(value)");
							}
						}
					}
					[global::Rocks.MemberIdentifier(2, "global::IRight.get_Value()")]
					[global::Rocks.MemberIdentifier(3, "global::IRight.set_Value(value)")]
					global::Values.Information global::IRight.Value
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
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::IRight.get_Value())");
						}
						set
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
											throw new global::Rocks.Exceptions.ExpectationException("No handlers match for global::IRight.set_Value(value)");
										}
										
										break;
									}
								}
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::IRight.set_Value(value)");
							}
						}
					}
					
					private global::ILeftRightCreateExpectations Expectations { get; }
				}
				internal sealed class ExplicitPropertyExpectationsForILeft
				{
					internal sealed class ExplicitPropertyGetterExpectationsForILeft
					{
						internal ExplicitPropertyGetterExpectationsForILeft(global::ILeftRightCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::ILeftRightCreateExpectations.Handler0, global::System.Func<global::Values.Information>, global::Values.Information> Value()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
							var handler = new global::ILeftRightCreateExpectations.Handler0();
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						private global::ILeftRightCreateExpectations Expectations { get; }
					}
					internal sealed class ExplicitPropertySetterExpectationsForILeft
					{
						internal ExplicitPropertySetterExpectationsForILeft(global::ILeftRightCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::ILeftRightCreateExpectations.Handler1, global::System.Action<global::Values.Information>> Value(global::Rocks.Argument<global::Values.Information> @value)
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							global::System.ArgumentNullException.ThrowIfNull(@value);
						
							var handler = new global::ILeftRightCreateExpectations.Handler1
							{
								value = @value,
							};
						
							if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(); }
							this.Expectations.handlers1.Add(handler);
							return new(handler);
						}
						private global::ILeftRightCreateExpectations Expectations { get; }
					}
					
					internal ExplicitPropertyExpectationsForILeft(global::ILeftRightCreateExpectations expectations) =>
						(this.Getters, this.Setters) = (new(expectations), new(expectations));
					
					internal global::ILeftRightCreateExpectations.ExplicitPropertyExpectationsForILeft.ExplicitPropertyGetterExpectationsForILeft Getters { get; }
					internal global::ILeftRightCreateExpectations.ExplicitPropertyExpectationsForILeft.ExplicitPropertySetterExpectationsForILeft Setters { get; }
				}
				internal sealed class ExplicitPropertyExpectationsForIRight
				{
					internal sealed class ExplicitPropertyGetterExpectationsForIRight
					{
						internal ExplicitPropertyGetterExpectationsForIRight(global::ILeftRightCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::ILeftRightCreateExpectations.Handler2, global::System.Func<global::Values.Information>, global::Values.Information> Value()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							if (this.Expectations.handlers2 is null ) { this.Expectations.handlers2 = new(); }
							var handler = new global::ILeftRightCreateExpectations.Handler2();
							this.Expectations.handlers2.Add(handler);
							return new(handler);
						}
						private global::ILeftRightCreateExpectations Expectations { get; }
					}
					internal sealed class ExplicitPropertySetterExpectationsForIRight
					{
						internal ExplicitPropertySetterExpectationsForIRight(global::ILeftRightCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::ILeftRightCreateExpectations.Handler3, global::System.Action<global::Values.Information>> Value(global::Rocks.Argument<global::Values.Information> @value)
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							global::System.ArgumentNullException.ThrowIfNull(@value);
						
							var handler = new global::ILeftRightCreateExpectations.Handler3
							{
								value = @value,
							};
						
							if (this.Expectations.handlers3 is null ) { this.Expectations.handlers3 = new(); }
							this.Expectations.handlers3.Add(handler);
							return new(handler);
						}
						private global::ILeftRightCreateExpectations Expectations { get; }
					}
					
					internal ExplicitPropertyExpectationsForIRight(global::ILeftRightCreateExpectations expectations) =>
						(this.Getters, this.Setters) = (new(expectations), new(expectations));
					
					internal global::ILeftRightCreateExpectations.ExplicitPropertyExpectationsForIRight.ExplicitPropertyGetterExpectationsForIRight Getters { get; }
					internal global::ILeftRightCreateExpectations.ExplicitPropertyExpectationsForIRight.ExplicitPropertySetterExpectationsForIRight Setters { get; }
				}
				
				internal global::ILeftRightCreateExpectations.ExplicitPropertyExpectationsForILeft ExplicitPropertiesForILeft { get; }
				internal global::ILeftRightCreateExpectations.ExplicitPropertyExpectationsForIRight ExplicitPropertiesForIRight { get; }
				
				internal ILeftRightCreateExpectations() =>
					(this.ExplicitPropertiesForILeft, this.ExplicitPropertiesForIRight) = (new(this), new(this));
				
				internal global::ILeftRight Instance()
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

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "ILeftRight_Rock_Create.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task CreateWithDifferenceInReturnTypeAsync()
	{
		var code =
			"""
			using Rocks;
			
			[assembly: RockCreate<IIterable<string>>]

			public interface IIterator
			{
				void Iterate();
			}

			public interface IIterator<out T>
				: IIterator
			{
				new T Iterate();
			}
			
			public interface IIterable
			{
				IIterator GetIterator();
			}

			public interface IIterable<out T>
				: IIterable
			{
				new IIterator<T> GetIterator();
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IIterableOfstringCreateExpectations
				: global::Rocks.Expectations
			{
				internal sealed class Handler0
					: global::Rocks.Handler<global::System.Func<global::IIterator<string>>, global::IIterator<string>>
				{ }
				
				internal sealed class Handler1
					: global::Rocks.Handler<global::System.Func<global::IIterator>, global::IIterator>
				{ }
				
				private global::System.Collections.Generic.List<global::IIterableOfstringCreateExpectations.Handler0>? @handlers0;
				private global::System.Collections.Generic.List<global::IIterableOfstringCreateExpectations.Handler1>? @handlers1;
				
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
					: global::IIterable<string>
				{
					public Mock(global::IIterableOfstringCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "global::IIterator<string> GetIterator()")]
					public global::IIterator<string> GetIterator()
					{
						if (this.Expectations.handlers0?.Count > 0)
						{
							var @handler = this.Expectations.handlers0[0];
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							return @result!;
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::IIterator<string> GetIterator()");
					}
					
					[global::Rocks.MemberIdentifier(1, "global::IIterator global::IIterable.GetIterator()")]
					global::IIterator global::IIterable.GetIterator()
					{
						if (this.Expectations.handlers1?.Count > 0)
						{
							var @handler = this.Expectations.handlers1[0];
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							return @result!;
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::IIterator global::IIterable.GetIterator()");
					}
					
					private global::IIterableOfstringCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::IIterableOfstringCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.Adornments<global::IIterableOfstringCreateExpectations.Handler0, global::System.Func<global::IIterator<string>>, global::IIterator<string>> GetIterator()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
						var handler = new global::IIterableOfstringCreateExpectations.Handler0();
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					private global::IIterableOfstringCreateExpectations Expectations { get; }
				}
				internal sealed class ExplicitMethodExpectationsForIIterable
				{
					internal ExplicitMethodExpectationsForIIterable(global::IIterableOfstringCreateExpectations expectations) =>
						this.Expectations = expectations;
				
					internal global::Rocks.Adornments<global::IIterableOfstringCreateExpectations.Handler1, global::System.Func<global::IIterator>, global::IIterator> GetIterator()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(); }
						var handler = new global::IIterableOfstringCreateExpectations.Handler1();
						this.Expectations.handlers1.Add(handler);
						return new(handler);
					}
					
					private global::IIterableOfstringCreateExpectations Expectations { get; }
				}
				
				internal global::IIterableOfstringCreateExpectations.MethodExpectations Methods { get; }
				internal global::IIterableOfstringCreateExpectations.ExplicitMethodExpectationsForIIterable ExplicitMethodsForIIterable { get; }
				
				internal IIterableOfstringCreateExpectations() =>
					(this.Methods, this.ExplicitMethodsForIIterable) = (new(this), new(this));
				
				internal global::IIterable<string> Instance()
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

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IIterablestring_Rock_Create.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task CreateWithExplicitImplementationAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Collections.Generic;
			
			[assembly: RockCreate<ISetupList>]

			public interface ISetup { }

			public interface ISetupList
				: IEnumerable<ISetup> { }
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class ISetupListCreateExpectations
				: global::Rocks.Expectations
			{
				internal sealed class Handler0
					: global::Rocks.Handler<global::System.Func<global::System.Collections.Generic.IEnumerator<global::ISetup>>, global::System.Collections.Generic.IEnumerator<global::ISetup>>
				{ }
				
				internal sealed class Handler1
					: global::Rocks.Handler<global::System.Func<global::System.Collections.IEnumerator>, global::System.Collections.IEnumerator>
				{ }
				
				private global::System.Collections.Generic.List<global::ISetupListCreateExpectations.Handler0>? @handlers0;
				private global::System.Collections.Generic.List<global::ISetupListCreateExpectations.Handler1>? @handlers1;
				
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
					: global::ISetupList
				{
					public Mock(global::ISetupListCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "global::System.Collections.Generic.IEnumerator<global::ISetup> GetEnumerator()")]
					public global::System.Collections.Generic.IEnumerator<global::ISetup> GetEnumerator()
					{
						if (this.Expectations.handlers0?.Count > 0)
						{
							var @handler = this.Expectations.handlers0[0];
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							return @result!;
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::System.Collections.Generic.IEnumerator<global::ISetup> GetEnumerator()");
					}
					
					[global::Rocks.MemberIdentifier(1, "global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()")]
					global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
					{
						if (this.Expectations.handlers1?.Count > 0)
						{
							var @handler = this.Expectations.handlers1[0];
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							return @result!;
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()");
					}
					
					private global::ISetupListCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::ISetupListCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.Adornments<global::ISetupListCreateExpectations.Handler0, global::System.Func<global::System.Collections.Generic.IEnumerator<global::ISetup>>, global::System.Collections.Generic.IEnumerator<global::ISetup>> GetEnumerator()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
						var handler = new global::ISetupListCreateExpectations.Handler0();
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					private global::ISetupListCreateExpectations Expectations { get; }
				}
				internal sealed class ExplicitMethodExpectationsForIEnumerable
				{
					internal ExplicitMethodExpectationsForIEnumerable(global::ISetupListCreateExpectations expectations) =>
						this.Expectations = expectations;
				
					internal global::Rocks.Adornments<global::ISetupListCreateExpectations.Handler1, global::System.Func<global::System.Collections.IEnumerator>, global::System.Collections.IEnumerator> GetEnumerator()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(); }
						var handler = new global::ISetupListCreateExpectations.Handler1();
						this.Expectations.handlers1.Add(handler);
						return new(handler);
					}
					
					private global::ISetupListCreateExpectations Expectations { get; }
				}
				
				internal global::ISetupListCreateExpectations.MethodExpectations Methods { get; }
				internal global::ISetupListCreateExpectations.ExplicitMethodExpectationsForIEnumerable ExplicitMethodsForIEnumerable { get; }
				
				internal ISetupListCreateExpectations() =>
					(this.Methods, this.ExplicitMethodsForIEnumerable) = (new(this), new(this));
				
				internal global::ISetupList Instance()
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

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "ISetupList_Rock_Create.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task MakeWithExplicitImplementationAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Collections.Generic;
			
			[assembly: RockMake<ISetupList>]

			public interface ISetup { }

			public interface ISetupList
				: IEnumerable<ISetup> { }
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class ISetupListMakeExpectations
			{
				internal global::ISetupList Instance()
				{
					return new Mock();
				}
				
				private sealed class Mock
					: global::ISetupList
				{
					public Mock()
					{
					}
					
					public global::System.Collections.Generic.IEnumerator<global::ISetup> GetEnumerator()
					{
						return default!;
					}
					global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
					{
						return default!;
					}
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "ISetupList_Rock_Make.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task MakeWithDifferenceInReturnTypeAsync()
	{
		var code =
			"""
			using Rocks;
			
			[assembly: RockMake<IIterable<string>>]

			public interface IIterator
			{
				void Iterate();
			}

			public interface IIterator<out T>
				: IIterator
			{
				new T Iterate();
			}
			
			public interface IIterable
			{
				IIterator GetIterator();
			}

			public interface IIterable<out T>
				: IIterable
			{
				new IIterator<T> GetIterator();
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class IIterableOfstringMakeExpectations
			{
				internal global::IIterable<string> Instance()
				{
					return new Mock();
				}
				
				private sealed class Mock
					: global::IIterable<string>
				{
					public Mock()
					{
					}
					
					public global::IIterator<string> GetIterator()
					{
						return default!;
					}
					global::IIterator global::IIterable.GetIterator()
					{
						return default!;
					}
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "IIterablestring_Rock_Make.g.cs", generatedCode) },
			[]);
	}
}