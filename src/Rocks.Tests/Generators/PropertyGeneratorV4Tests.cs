﻿using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class PropertyGeneratorV4Tests
{
	[Test]
	public static async Task CreateWithNewDefinitionAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<IMessagePublishTopologyConfigurator>]

			public interface IMessagePublishTopology
			{
				bool Exclude { get; }
			}

			public interface IMessagePublishTopologyConfigurator :
				IMessagePublishTopology
			{
				new bool Exclude { set; }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal sealed class IMessagePublishTopologyConfiguratorCreateExpectations
				: global::Rocks.Expectations.ExpectationsV4
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.HandlerV4<global::System.Action<bool>>
				{
					public global::Rocks.Argument<bool> @value { get; set; }
				}
				
				internal sealed class Handler1
					: global::Rocks.HandlerV4<global::System.Func<bool>, bool>
				{ }
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::IMessagePublishTopologyConfiguratorCreateExpectations.Handler0> @handlers0 = new();
				private readonly global::System.Collections.Generic.List<global::IMessagePublishTopologyConfiguratorCreateExpectations.Handler1> @handlers1 = new();
				
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
				
				private sealed class RockIMessagePublishTopologyConfigurator
					: global::IMessagePublishTopologyConfigurator
				{
					public RockIMessagePublishTopologyConfigurator(global::IMessagePublishTopologyConfiguratorCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "set_Exclude(value)")]
					public bool Exclude
					{
						set
						{
							if (this.Expectations.handlers0.Count > 0)
							{
								var @foundMatch = false;
								foreach (var @handler in this.Expectations.handlers0)
								{
									if (@handler.value.IsValid(value!))
									{
										@handler.CallCount++;
										@foundMatch = true;
										@handler.Callback?.Invoke(value!);
										
										if (!@foundMatch)
										{
											throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_Exclude(value)");
										}
										
										break;
									}
								}
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for set_Exclude(value)");
							}
						}
					}
					[global::Rocks.MemberIdentifier(1, "global::IMessagePublishTopology.get_Exclude()")]
					bool global::IMessagePublishTopology.Exclude
					{
						get
						{
							if (this.Expectations.handlers1.Count > 0)
							{
								var @handler = this.Expectations.handlers1[0];
								@handler.CallCount++;
								var @result = @handler.Callback?.Invoke() ?? @handler.ReturnValue;
								return @result!;
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::IMessagePublishTopology.get_Exclude())");
						}
					}
					
					private global::IMessagePublishTopologyConfiguratorCreateExpectations Expectations { get; }
				}
				internal sealed class IMessagePublishTopologyConfiguratorPropertyExpectations
				{
					internal sealed class IMessagePublishTopologyConfiguratorPropertySetterExpectations
					{
						internal IMessagePublishTopologyConfiguratorPropertySetterExpectations(global::IMessagePublishTopologyConfiguratorCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::IMessagePublishTopologyConfiguratorCreateExpectations.Handler0, global::System.Action<bool>> Exclude(global::Rocks.Argument<bool> @value)
						{
							var handler = new global::IMessagePublishTopologyConfiguratorCreateExpectations.Handler0
							{
								value = @value,
							};
						
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						private global::IMessagePublishTopologyConfiguratorCreateExpectations Expectations { get; }
					}
					
					internal IMessagePublishTopologyConfiguratorPropertyExpectations(global::IMessagePublishTopologyConfiguratorCreateExpectations expectations) =>
						(this.Setters) = (new(expectations));
					
					internal global::IMessagePublishTopologyConfiguratorCreateExpectations.IMessagePublishTopologyConfiguratorPropertyExpectations.IMessagePublishTopologyConfiguratorPropertySetterExpectations Setters { get; }
				}
				internal sealed class IMessagePublishTopologyConfiguratorExplicitPropertyExpectationsForIMessagePublishTopology
				{
					internal sealed class IMessagePublishTopologyConfiguratorExplicitPropertyGetterExpectationsForIMessagePublishTopology
					{
						internal IMessagePublishTopologyConfiguratorExplicitPropertyGetterExpectationsForIMessagePublishTopology(global::IMessagePublishTopologyConfiguratorCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::IMessagePublishTopologyConfiguratorCreateExpectations.Handler1, global::System.Func<bool>, bool> Exclude()
						{
							var handler = new global::IMessagePublishTopologyConfiguratorCreateExpectations.Handler1();
							this.Expectations.handlers1.Add(handler);
							return new(handler);
						}
						private global::IMessagePublishTopologyConfiguratorCreateExpectations Expectations { get; }
					}
					
					internal IMessagePublishTopologyConfiguratorExplicitPropertyExpectationsForIMessagePublishTopology(global::IMessagePublishTopologyConfiguratorCreateExpectations expectations) =>
						(this.Getters) = (new(expectations));
					
					internal global::IMessagePublishTopologyConfiguratorCreateExpectations.IMessagePublishTopologyConfiguratorExplicitPropertyExpectationsForIMessagePublishTopology.IMessagePublishTopologyConfiguratorExplicitPropertyGetterExpectationsForIMessagePublishTopology Getters { get; }
				}
				
				internal global::IMessagePublishTopologyConfiguratorCreateExpectations.IMessagePublishTopologyConfiguratorPropertyExpectations Properties { get; }
				internal global::IMessagePublishTopologyConfiguratorCreateExpectations.IMessagePublishTopologyConfiguratorExplicitPropertyExpectationsForIMessagePublishTopology ExplicitPropertiesForIMessagePublishTopology { get; }
				
				internal IMessagePublishTopologyConfiguratorCreateExpectations() =>
					(this.Properties, this.ExplicitPropertiesForIMessagePublishTopology) = (new(this), new(this));
				
				internal global::IMessagePublishTopologyConfigurator Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockIMessagePublishTopologyConfigurator(this);
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
			new[] { (typeof(RockAttributeGenerator), "IMessagePublishTopologyConfigurator_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task CreateWithMixedVisibilityAsync()
	{
		var code =
			"""
			using System;
			using Rocks;

			[assembly: RockCreate<MixedProperties>]

			#nullable enable

			public class MixedProperties
			{
				public virtual string? PublicGetPrivateSet { get; private set; }
				public virtual string? PublicGetProtectedSet { get; protected set; }
				public virtual string? PrivateGetPublicSet { private get; set; }
				public virtual string? ProtectedGetPublicSet { protected get; set; }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal sealed class MixedPropertiesCreateExpectations
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
					: global::Rocks.HandlerV4<global::System.Func<string?>, string?>
				{ }
				
				internal sealed class Handler4
					: global::Rocks.HandlerV4<global::System.Action<string?>>
				{
					public global::Rocks.Argument<string?> @value { get; set; }
				}
				
				internal sealed class Handler5
					: global::Rocks.HandlerV4<global::System.Func<string?>, string?>
				{ }
				
				internal sealed class Handler6
					: global::Rocks.HandlerV4<global::System.Action<string?>>
				{
					public global::Rocks.Argument<string?> @value { get; set; }
				}
				
				internal sealed class Handler7
					: global::Rocks.HandlerV4<global::System.Func<string?>, string?>
				{ }
				
				internal sealed class Handler8
					: global::Rocks.HandlerV4<global::System.Action<string?>>
				{
					public global::Rocks.Argument<string?> @value { get; set; }
				}
				
				internal sealed class Handler9
					: global::Rocks.HandlerV4<global::System.Func<string?>, string?>
				{ }
				
				internal sealed class Handler10
					: global::Rocks.HandlerV4<global::System.Action<string?>>
				{
					public global::Rocks.Argument<string?> @value { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler0> @handlers0 = new();
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler1> @handlers1 = new();
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler2> @handlers2 = new();
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler3> @handlers3 = new();
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler4> @handlers4 = new();
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler5> @handlers5 = new();
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler6> @handlers6 = new();
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler7> @handlers7 = new();
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler8> @handlers8 = new();
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler9> @handlers9 = new();
				private readonly global::System.Collections.Generic.List<global::MixedPropertiesCreateExpectations.Handler10> @handlers10 = new();
				
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
						failures.AddRange(this.Verify(handlers8));
						failures.AddRange(this.Verify(handlers9));
						failures.AddRange(this.Verify(handlers10));
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class RockMixedProperties
					: global::MixedProperties
				{
					public RockMixedProperties(global::MixedPropertiesCreateExpectations @expectations)
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
					
					[global::Rocks.MemberIdentifier(3, "get_PublicGetPrivateSet()")]
					public override string? PublicGetPrivateSet
					{
						get
						{
							if (this.Expectations.handlers3.Count > 0)
							{
								var @handler = this.Expectations.handlers3[0];
								@handler.CallCount++;
								var @result = @handler.Callback?.Invoke() ?? @handler.ReturnValue;
								return @result!;
							}
							else
							{
								return base.PublicGetPrivateSet;
							}
						}
					}
					[global::Rocks.MemberIdentifier(5, "get_PublicGetProtectedSet()")]
					[global::Rocks.MemberIdentifier(6, "set_PublicGetProtectedSet(value)")]
					public override string? PublicGetProtectedSet
					{
						get
						{
							if (this.Expectations.handlers5.Count > 0)
							{
								var @handler = this.Expectations.handlers5[0];
								@handler.CallCount++;
								var @result = @handler.Callback?.Invoke() ?? @handler.ReturnValue;
								return @result!;
							}
							else
							{
								return base.PublicGetProtectedSet;
							}
						}
						protected set
						{
							if (this.Expectations.handlers6.Count > 0)
							{
								var @foundMatch = false;
								foreach (var @handler in this.Expectations.handlers6)
								{
									if (@handler.value.IsValid(value!))
									{
										@handler.CallCount++;
										@foundMatch = true;
										@handler.Callback?.Invoke(value!);
										
										if (!@foundMatch)
										{
											throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_PublicGetProtectedSet(value)");
										}
										
										break;
									}
								}
							}
							else
							{
								base.PublicGetProtectedSet = value!;
							}
						}
					}
					[global::Rocks.MemberIdentifier(7, "set_PrivateGetPublicSet(value)")]
					public override string? PrivateGetPublicSet
					{
						set
						{
							if (this.Expectations.handlers7.Count > 0)
							{
								var @foundMatch = false;
								foreach (var @handler in this.Expectations.handlers7)
								{
									if (@handler.value.IsValid(value!))
									{
										@handler.CallCount++;
										@foundMatch = true;
										@handler.Callback?.Invoke(value!);
										
										if (!@foundMatch)
										{
											throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_PrivateGetPublicSet(value)");
										}
										
										break;
									}
								}
							}
							else
							{
								base.PrivateGetPublicSet = value!;
							}
						}
					}
					[global::Rocks.MemberIdentifier(9, "get_ProtectedGetPublicSet()")]
					[global::Rocks.MemberIdentifier(10, "set_ProtectedGetPublicSet(value)")]
					public override string? ProtectedGetPublicSet
					{
						protected get
						{
							if (this.Expectations.handlers9.Count > 0)
							{
								var @handler = this.Expectations.handlers9[0];
								@handler.CallCount++;
								var @result = @handler.Callback?.Invoke() ?? @handler.ReturnValue;
								return @result!;
							}
							else
							{
								return base.ProtectedGetPublicSet;
							}
						}
						set
						{
							if (this.Expectations.handlers10.Count > 0)
							{
								var @foundMatch = false;
								foreach (var @handler in this.Expectations.handlers10)
								{
									if (@handler.value.IsValid(value!))
									{
										@handler.CallCount++;
										@foundMatch = true;
										@handler.Callback?.Invoke(value!);
										
										if (!@foundMatch)
										{
											throw new global::Rocks.Exceptions.ExpectationException("No handlers match for set_ProtectedGetPublicSet(value)");
										}
										
										break;
									}
								}
							}
							else
							{
								base.ProtectedGetPublicSet = value!;
							}
						}
					}
					
					private global::MixedPropertiesCreateExpectations Expectations { get; }
				}
				
				internal sealed class MixedPropertiesMethodExpectations
				{
					internal MixedPropertiesMethodExpectations(global::MixedPropertiesCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::MixedPropertiesCreateExpectations.Handler0, global::System.Func<object?, bool>, bool> Equals(global::Rocks.Argument<object?> @obj)
					{
						global::System.ArgumentNullException.ThrowIfNull(@obj);
						
						var handler = new global::MixedPropertiesCreateExpectations.Handler0
						{
							@obj = @obj,
						};
						
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.AdornmentsV4<global::MixedPropertiesCreateExpectations.Handler1, global::System.Func<int>, int> GetHashCode()
					{
						var handler = new global::MixedPropertiesCreateExpectations.Handler1();
						this.Expectations.handlers1.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.AdornmentsV4<global::MixedPropertiesCreateExpectations.Handler2, global::System.Func<string?>, string?> ToString()
					{
						var handler = new global::MixedPropertiesCreateExpectations.Handler2();
						this.Expectations.handlers2.Add(handler);
						return new(handler);
					}
					
					private global::MixedPropertiesCreateExpectations Expectations { get; }
				}
				
				internal sealed class MixedPropertiesPropertyExpectations
				{
					internal sealed class MixedPropertiesPropertyGetterExpectations
					{
						internal MixedPropertiesPropertyGetterExpectations(global::MixedPropertiesCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::MixedPropertiesCreateExpectations.Handler3, global::System.Func<string?>, string?> PublicGetPrivateSet()
						{
							var handler = new global::MixedPropertiesCreateExpectations.Handler3();
							this.Expectations.handlers3.Add(handler);
							return new(handler);
						}
						internal global::Rocks.AdornmentsV4<global::MixedPropertiesCreateExpectations.Handler5, global::System.Func<string?>, string?> PublicGetProtectedSet()
						{
							var handler = new global::MixedPropertiesCreateExpectations.Handler5();
							this.Expectations.handlers5.Add(handler);
							return new(handler);
						}
						internal global::Rocks.AdornmentsV4<global::MixedPropertiesCreateExpectations.Handler9, global::System.Func<string?>, string?> ProtectedGetPublicSet()
						{
							var handler = new global::MixedPropertiesCreateExpectations.Handler9();
							this.Expectations.handlers9.Add(handler);
							return new(handler);
						}
						private global::MixedPropertiesCreateExpectations Expectations { get; }
					}
					
					internal sealed class MixedPropertiesPropertySetterExpectations
					{
						internal MixedPropertiesPropertySetterExpectations(global::MixedPropertiesCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::MixedPropertiesCreateExpectations.Handler6, global::System.Action<string?>> PublicGetProtectedSet(global::Rocks.Argument<string?> @value)
						{
							var handler = new global::MixedPropertiesCreateExpectations.Handler6
							{
								value = @value,
							};
						
							this.Expectations.handlers6.Add(handler);
							return new(handler);
						}
						internal global::Rocks.AdornmentsV4<global::MixedPropertiesCreateExpectations.Handler8, global::System.Action<string?>> PrivateGetPublicSet(global::Rocks.Argument<string?> @value)
						{
							var handler = new global::MixedPropertiesCreateExpectations.Handler8
							{
								value = @value,
							};
						
							this.Expectations.handlers8.Add(handler);
							return new(handler);
						}
						internal global::Rocks.AdornmentsV4<global::MixedPropertiesCreateExpectations.Handler10, global::System.Action<string?>> ProtectedGetPublicSet(global::Rocks.Argument<string?> @value)
						{
							var handler = new global::MixedPropertiesCreateExpectations.Handler10
							{
								value = @value,
							};
						
							this.Expectations.handlers10.Add(handler);
							return new(handler);
						}
						private global::MixedPropertiesCreateExpectations Expectations { get; }
					}
					
					internal MixedPropertiesPropertyExpectations(global::MixedPropertiesCreateExpectations expectations) =>
						(this.Getters, this.Setters) = (new(expectations), new(expectations));
					
					internal global::MixedPropertiesCreateExpectations.MixedPropertiesPropertyExpectations.MixedPropertiesPropertyGetterExpectations Getters { get; }
					internal global::MixedPropertiesCreateExpectations.MixedPropertiesPropertyExpectations.MixedPropertiesPropertySetterExpectations Setters { get; }
				}
				
				internal global::MixedPropertiesCreateExpectations.MixedPropertiesMethodExpectations Methods { get; }
				internal global::MixedPropertiesCreateExpectations.MixedPropertiesPropertyExpectations Properties { get; }
				
				internal MixedPropertiesCreateExpectations() =>
					(this.Methods, this.Properties) = (new(this), new(this));
				
				internal global::MixedProperties Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockMixedProperties(this);
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
			new[] { (typeof(RockAttributeGenerator), "MixedProperties_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task MakeWithMixedVisibilityAsync()
	{
		var code =
			"""
			using System;
			using Rocks;

			[assembly: RockMake<MixedProperties>]
			
			#nullable enable
			
			public class MixedProperties
			{
				public virtual string? PublicGetPrivateSet { get; private set; }
				public virtual string? PublicGetProtectedSet { get; protected set; }
				public virtual string? PrivateGetPublicSet { private get; set; }
				public virtual string? ProtectedGetPublicSet { protected get; set; }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class MixedPropertiesMakeExpectations
			{
				internal global::MixedProperties Instance()
				{
					return new RockMixedProperties();
				}
				
				private sealed class RockMixedProperties
					: global::MixedProperties
				{
					public RockMixedProperties()
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
					public override string? PublicGetPrivateSet
					{
						get => default!;
					}
					public override string? PublicGetProtectedSet
					{
						get => default!;
						protected set { }
					}
					public override string? PrivateGetPublicSet
					{
						set { }
					}
					public override string? ProtectedGetPublicSet
					{
						protected get => default!;
						set { }
					}
				}
			}
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MixedProperties_Rock_Make.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}
}