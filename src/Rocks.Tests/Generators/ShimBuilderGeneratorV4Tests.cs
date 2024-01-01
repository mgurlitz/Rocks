﻿using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class ShimBuilderGeneratorV4Tests
{
	[Test]
	public static async Task CreateWhenDuplicatesOccurAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Linq;
			using System.Collections.Generic;

			[assembly: RockCreate<IRuntimeKey>]

			public interface IReadOnlyProperty 
			{ 
				Type ClrType { get; }
			}

			public interface IProperty
				: IReadOnlyProperty { }

			public interface IReadOnlyKey
			{
				bool IsPrimaryKey() => true;

				IReadOnlyList<IReadOnlyProperty> Properties { get; }
			}

			public interface IKey
				: IReadOnlyKey
			{
				Type GetKeyType() => Properties.Count > 1 ? typeof(object[]) : Properties.First().ClrType;

				new IReadOnlyList<IProperty> Properties { get; }
			}

			public interface IRuntimeKey 
				: IKey { }
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal sealed class IRuntimeKeyCreateExpectations
				: global::Rocks.Expectations.ExpectationsV4
			{
				internal sealed class Handler0
					: global::Rocks.HandlerV4<global::System.Func<global::System.Type>, global::System.Type>
				{ }
				
				internal sealed class Handler1
					: global::Rocks.HandlerV4<global::System.Func<bool>, bool>
				{ }
				
				internal sealed class Handler2
					: global::Rocks.HandlerV4<global::System.Func<global::System.Collections.Generic.IReadOnlyList<global::IProperty>>, global::System.Collections.Generic.IReadOnlyList<global::IProperty>>
				{ }
				
				internal sealed class Handler3
					: global::Rocks.HandlerV4<global::System.Func<global::System.Collections.Generic.IReadOnlyList<global::IReadOnlyProperty>>, global::System.Collections.Generic.IReadOnlyList<global::IReadOnlyProperty>>
				{ }
				
				private readonly global::System.Collections.Generic.List<global::IRuntimeKeyCreateExpectations.Handler0> @handlers0 = new();
				private readonly global::System.Collections.Generic.List<global::IRuntimeKeyCreateExpectations.Handler1> @handlers1 = new();
				private readonly global::System.Collections.Generic.List<global::IRuntimeKeyCreateExpectations.Handler2> @handlers2 = new();
				private readonly global::System.Collections.Generic.List<global::IRuntimeKeyCreateExpectations.Handler3> @handlers3 = new();
				
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
				
				private sealed class RockIRuntimeKey
					: global::IRuntimeKey
				{
					private readonly global::IKey shimForIKey;
					private readonly global::IReadOnlyKey shimForIReadOnlyKey;
					public RockIRuntimeKey(global::IRuntimeKeyCreateExpectations @expectations)
					{
						(this.Expectations, this.shimForIKey, this.shimForIReadOnlyKey) = (@expectations, new ShimIKey55018818661256234156060084750235742359064106137(this), new ShimIReadOnlyKey550014593303283198411825442751878980310579223223(this));
					}
					
					[global::Rocks.MemberIdentifier(0, "global::System.Type GetKeyType()")]
					public global::System.Type GetKeyType()
					{
						if (this.Expectations.handlers0.Count > 0)
						{
							var @handler = this.Expectations.handlers0[0];
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							return @result!;
						}
						else
						{
							return this.shimForIKey.GetKeyType();
						}
					}
					
					[global::Rocks.MemberIdentifier(1, "bool IsPrimaryKey()")]
					public bool IsPrimaryKey()
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
							return this.shimForIReadOnlyKey.IsPrimaryKey();
						}
					}
					
					[global::Rocks.MemberIdentifier(2, "get_Properties()")]
					public global::System.Collections.Generic.IReadOnlyList<global::IProperty> Properties
					{
						get
						{
							if (this.Expectations.handlers2.Count > 0)
							{
								var @handler = this.Expectations.handlers2[0];
								@handler.CallCount++;
								var @result = @handler.Callback?.Invoke() ?? @handler.ReturnValue;
								return @result!;
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_Properties())");
						}
					}
					[global::Rocks.MemberIdentifier(3, "global::IReadOnlyKey.get_Properties()")]
					global::System.Collections.Generic.IReadOnlyList<global::IReadOnlyProperty> global::IReadOnlyKey.Properties
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
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for global::IReadOnlyKey.get_Properties())");
						}
					}
					
					
					private sealed class ShimIKey55018818661256234156060084750235742359064106137
						: global::IKey
					{
						private readonly RockIRuntimeKey mock;
						
						public ShimIKey55018818661256234156060084750235742359064106137(RockIRuntimeKey @mock) =>
							this.mock = @mock;
						
						public global::System.Collections.Generic.IReadOnlyList<global::IProperty> Properties
						{
							get => ((global::IKey)this.mock).Properties!;
						}
						
						global::System.Collections.Generic.IReadOnlyList<global::IReadOnlyProperty> global::IReadOnlyKey.Properties
						{
							get => ((global::IKey)this.mock).Properties!;
						}
					}
					
					private sealed class ShimIReadOnlyKey550014593303283198411825442751878980310579223223
						: global::IReadOnlyKey
					{
						private readonly RockIRuntimeKey mock;
						
						public ShimIReadOnlyKey550014593303283198411825442751878980310579223223(RockIRuntimeKey @mock) =>
							this.mock = @mock;
						
						public global::System.Collections.Generic.IReadOnlyList<global::IReadOnlyProperty> Properties
						{
							get => ((global::IReadOnlyKey)this.mock).Properties!;
						}
					}
					private global::IRuntimeKeyCreateExpectations Expectations { get; }
				}
				
				internal sealed class IRuntimeKeyMethodExpectations
				{
					internal IRuntimeKeyMethodExpectations(global::IRuntimeKeyCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::IRuntimeKeyCreateExpectations.Handler0, global::System.Func<global::System.Type>, global::System.Type> GetKeyType()
					{
						var handler = new global::IRuntimeKeyCreateExpectations.Handler0();
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.AdornmentsV4<global::IRuntimeKeyCreateExpectations.Handler1, global::System.Func<bool>, bool> IsPrimaryKey()
					{
						var handler = new global::IRuntimeKeyCreateExpectations.Handler1();
						this.Expectations.handlers1.Add(handler);
						return new(handler);
					}
					
					private global::IRuntimeKeyCreateExpectations Expectations { get; }
				}
				
				internal sealed class IRuntimeKeyPropertyExpectations
				{
					internal sealed class IRuntimeKeyPropertyGetterExpectations
					{
						internal IRuntimeKeyPropertyGetterExpectations(global::IRuntimeKeyCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::IRuntimeKeyCreateExpectations.Handler2, global::System.Func<global::System.Collections.Generic.IReadOnlyList<global::IProperty>>, global::System.Collections.Generic.IReadOnlyList<global::IProperty>> Properties()
						{
							var handler = new global::IRuntimeKeyCreateExpectations.Handler2();
							this.Expectations.handlers2.Add(handler);
							return new(handler);
						}
						private global::IRuntimeKeyCreateExpectations Expectations { get; }
					}
					
					
					internal IRuntimeKeyPropertyExpectations(global::IRuntimeKeyCreateExpectations expectations) =>
						(this.Getters) = (new(expectations));
					
					internal global::IRuntimeKeyCreateExpectations.IRuntimeKeyPropertyExpectations.IRuntimeKeyPropertyGetterExpectations Getters { get; }
				}
				internal sealed class IRuntimeKeyExplicitPropertyExpectationsForIReadOnlyKey
				{
					internal sealed class IRuntimeKeyExplicitPropertyGetterExpectationsForIReadOnlyKey
					{
						internal IRuntimeKeyExplicitPropertyGetterExpectationsForIReadOnlyKey(global::IRuntimeKeyCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::IRuntimeKeyCreateExpectations.Handler3, global::System.Func<global::System.Collections.Generic.IReadOnlyList<global::IReadOnlyProperty>>, global::System.Collections.Generic.IReadOnlyList<global::IReadOnlyProperty>> Properties()
						{
							var handler = new global::IRuntimeKeyCreateExpectations.Handler3();
							this.Expectations.handlers3.Add(handler);
							return new(handler);
						}
						private global::IRuntimeKeyCreateExpectations Expectations { get; }
					}
					
					internal IRuntimeKeyExplicitPropertyExpectationsForIReadOnlyKey(global::IRuntimeKeyCreateExpectations expectations) =>
						(this.Getters) = (new(expectations));
					
					internal global::IRuntimeKeyCreateExpectations.IRuntimeKeyExplicitPropertyExpectationsForIReadOnlyKey.IRuntimeKeyExplicitPropertyGetterExpectationsForIReadOnlyKey Getters { get; }
				}
				
				internal global::IRuntimeKeyCreateExpectations.IRuntimeKeyMethodExpectations Methods { get; }
				internal global::IRuntimeKeyCreateExpectations.IRuntimeKeyPropertyExpectations Properties { get; }
				internal global::IRuntimeKeyCreateExpectations.IRuntimeKeyExplicitPropertyExpectationsForIReadOnlyKey ExplicitPropertiesForIReadOnlyKey { get; }
				
				internal IRuntimeKeyCreateExpectations() =>
					(this.Methods, this.Properties, this.ExplicitPropertiesForIReadOnlyKey) = (new(this), new(this), new(this));
				
				internal global::IRuntimeKey Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockIRuntimeKey(this);
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
			new[] { (typeof(RockAttributeGenerator), "IRuntimeKey_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateAbstractCreateAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<IHaveDims>]

			public interface IDoNotHaveDims
			{
				int IAmNotADim();
				int NotDim { get; }
				int this[string notDimKey] { get; }
			}
			
			public interface IHaveDims
				: IDoNotHaveDims
			{
				int IAmADim() => 2;
				int AmADim { get => 2; }
				int this[string dimKey, int dimValue] { get => dimKey.GetHashCode() + dimValue; }
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			
			internal sealed class IHaveDimsCreateExpectations
				: global::Rocks.Expectations.ExpectationsV4
			{
				#pragma warning disable CS8618
				
				internal sealed class Handler0
					: global::Rocks.HandlerV4<global::System.Func<int>, int>
				{ }
				
				internal sealed class Handler1
					: global::Rocks.HandlerV4<global::System.Func<int>, int>
				{ }
				
				internal sealed class Handler2
					: global::Rocks.HandlerV4<global::System.Func<int>, int>
				{ }
				
				internal sealed class Handler3
					: global::Rocks.HandlerV4<global::System.Func<string, int, int>, int>
				{
					public global::Rocks.Argument<string> @dimKey { get; set; }
					public global::Rocks.Argument<int> @dimValue { get; set; }
				}
				
				internal sealed class Handler4
					: global::Rocks.HandlerV4<global::System.Func<int>, int>
				{ }
				
				internal sealed class Handler5
					: global::Rocks.HandlerV4<global::System.Func<string, int>, int>
				{
					public global::Rocks.Argument<string> @notDimKey { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private readonly global::System.Collections.Generic.List<global::IHaveDimsCreateExpectations.Handler0> @handlers0 = new();
				private readonly global::System.Collections.Generic.List<global::IHaveDimsCreateExpectations.Handler1> @handlers1 = new();
				private readonly global::System.Collections.Generic.List<global::IHaveDimsCreateExpectations.Handler2> @handlers2 = new();
				private readonly global::System.Collections.Generic.List<global::IHaveDimsCreateExpectations.Handler3> @handlers3 = new();
				private readonly global::System.Collections.Generic.List<global::IHaveDimsCreateExpectations.Handler4> @handlers4 = new();
				private readonly global::System.Collections.Generic.List<global::IHaveDimsCreateExpectations.Handler5> @handlers5 = new();
				
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
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class RockIHaveDims
					: global::IHaveDims
				{
					private readonly global::IHaveDims shimForIHaveDims;
					public RockIHaveDims(global::IHaveDimsCreateExpectations @expectations)
					{
						(this.Expectations, this.shimForIHaveDims) = (@expectations, new ShimIHaveDims531557381186657891604647139828315705947108387206(this));
					}
					
					[global::Rocks.MemberIdentifier(0, "int IAmADim()")]
					public int IAmADim()
					{
						if (this.Expectations.handlers0.Count > 0)
						{
							var @handler = this.Expectations.handlers0[0];
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							return @result!;
						}
						else
						{
							return this.shimForIHaveDims.IAmADim();
						}
					}
					
					[global::Rocks.MemberIdentifier(1, "int IAmNotADim()")]
					public int IAmNotADim()
					{
						if (this.Expectations.handlers1.Count > 0)
						{
							var @handler = this.Expectations.handlers1[0];
							@handler.CallCount++;
							var @result = @handler.Callback is not null ?
								@handler.Callback() : @handler.ReturnValue;
							return @result!;
						}
						
						throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for int IAmNotADim()");
					}
					
					[global::Rocks.MemberIdentifier(2, "get_AmADim()")]
					public int AmADim
					{
						get
						{
							if (this.Expectations.handlers2.Count > 0)
							{
								var @handler = this.Expectations.handlers2[0];
								@handler.CallCount++;
								var @result = @handler.Callback?.Invoke() ?? @handler.ReturnValue;
								return @result!;
							}
							else
							{
								return this.shimForIHaveDims.AmADim;
							}
						}
					}
					[global::Rocks.MemberIdentifier(4, "get_NotDim()")]
					public int NotDim
					{
						get
						{
							if (this.Expectations.handlers4.Count > 0)
							{
								var @handler = this.Expectations.handlers4[0];
								@handler.CallCount++;
								var @result = @handler.Callback?.Invoke() ?? @handler.ReturnValue;
								return @result!;
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for get_NotDim())");
						}
					}
					
					[global::Rocks.MemberIdentifier(3, "this[string @dimKey, int @dimValue]")]
					public int this[string @dimKey, int @dimValue]
					{
						get
						{
							if (this.Expectations.handlers3.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers3)
								{
									if (@handler.@dimKey.IsValid(@dimKey!) &&
										@handler.@dimValue.IsValid(@dimValue!))
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback(@dimKey!, @dimValue!) : @handler.ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for this[string @dimKey, int @dimValue]");
							}
							else
							{
								return this.shimForIHaveDims[dimKey: @dimKey!, dimValue: @dimValue!];
							}
						}
					}
					[global::Rocks.MemberIdentifier(5, "this[string @notDimKey]")]
					public int this[string @notDimKey]
					{
						get
						{
							if (this.Expectations.handlers5.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers5)
								{
									if (@handler.@notDimKey.IsValid(@notDimKey!))
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback(@notDimKey!) : @handler.ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for this[string @notDimKey]");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for this[string @notDimKey])");
						}
					}
					
					
					private sealed class ShimIHaveDims531557381186657891604647139828315705947108387206
						: global::IHaveDims
					{
						private readonly RockIHaveDims mock;
						
						public ShimIHaveDims531557381186657891604647139828315705947108387206(RockIHaveDims @mock) =>
							this.mock = @mock;
						
						public int IAmNotADim() =>
							((global::IHaveDims)this.mock).IAmNotADim()!;
						
						public int NotDim
						{
							get => ((global::IHaveDims)this.mock).NotDim!;
						}
						
						public int this[string @notDimKey]
						{
							get => ((global::IHaveDims)this.mock)[@notDimKey]!;
						}
					}
					private global::IHaveDimsCreateExpectations Expectations { get; }
				}
				
				internal sealed class IHaveDimsMethodExpectations
				{
					internal IHaveDimsMethodExpectations(global::IHaveDimsCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.AdornmentsV4<global::IHaveDimsCreateExpectations.Handler0, global::System.Func<int>, int> IAmADim()
					{
						var handler = new global::IHaveDimsCreateExpectations.Handler0();
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.AdornmentsV4<global::IHaveDimsCreateExpectations.Handler1, global::System.Func<int>, int> IAmNotADim()
					{
						var handler = new global::IHaveDimsCreateExpectations.Handler1();
						this.Expectations.handlers1.Add(handler);
						return new(handler);
					}
					
					private global::IHaveDimsCreateExpectations Expectations { get; }
				}
				
				internal sealed class IHaveDimsPropertyExpectations
				{
					internal sealed class IHaveDimsPropertyGetterExpectations
					{
						internal IHaveDimsPropertyGetterExpectations(global::IHaveDimsCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::IHaveDimsCreateExpectations.Handler2, global::System.Func<int>, int> AmADim()
						{
							var handler = new global::IHaveDimsCreateExpectations.Handler2();
							this.Expectations.handlers2.Add(handler);
							return new(handler);
						}
						internal global::Rocks.AdornmentsV4<global::IHaveDimsCreateExpectations.Handler4, global::System.Func<int>, int> NotDim()
						{
							var handler = new global::IHaveDimsCreateExpectations.Handler4();
							this.Expectations.handlers4.Add(handler);
							return new(handler);
						}
						private global::IHaveDimsCreateExpectations Expectations { get; }
					}
					
					
					internal IHaveDimsPropertyExpectations(global::IHaveDimsCreateExpectations expectations) =>
						(this.Getters) = (new(expectations));
					
					internal global::IHaveDimsCreateExpectations.IHaveDimsPropertyExpectations.IHaveDimsPropertyGetterExpectations Getters { get; }
				}
				internal sealed class IHaveDimsIndexerExpectations
				{
					internal sealed class IHaveDimsIndexerGetterExpectations
					{
						internal IHaveDimsIndexerGetterExpectations(global::IHaveDimsCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.AdornmentsV4<global::IHaveDimsCreateExpectations.Handler3, global::System.Func<string, int, int>, int> This(global::Rocks.Argument<string> @dimKey, global::Rocks.Argument<int> @dimValue)
						{
							global::System.ArgumentNullException.ThrowIfNull(@dimKey);
							global::System.ArgumentNullException.ThrowIfNull(@dimValue);
							
							var handler = new global::IHaveDimsCreateExpectations.Handler3
							{
								@dimKey = @dimKey,
								@dimValue = @dimValue,
							};
							
							this.Expectations.handlers3.Add(handler);
							return new(handler);
						}
						internal global::Rocks.AdornmentsV4<global::IHaveDimsCreateExpectations.Handler5, global::System.Func<string, int>, int> This(global::Rocks.Argument<string> @notDimKey)
						{
							global::System.ArgumentNullException.ThrowIfNull(@notDimKey);
							
							var handler = new global::IHaveDimsCreateExpectations.Handler5
							{
								@notDimKey = @notDimKey,
							};
							
							this.Expectations.handlers5.Add(handler);
							return new(handler);
						}
						private global::IHaveDimsCreateExpectations Expectations { get; }
					}
					
					
					internal IHaveDimsIndexerExpectations(global::IHaveDimsCreateExpectations expectations) =>
						(this.Getters) = (new(expectations));
					
					internal global::IHaveDimsCreateExpectations.IHaveDimsIndexerExpectations.IHaveDimsIndexerGetterExpectations Getters { get; }
				}
				
				internal global::IHaveDimsCreateExpectations.IHaveDimsMethodExpectations Methods { get; }
				internal global::IHaveDimsCreateExpectations.IHaveDimsPropertyExpectations Properties { get; }
				internal global::IHaveDimsCreateExpectations.IHaveDimsIndexerExpectations Indexers { get; }
				
				internal IHaveDimsCreateExpectations() =>
					(this.Methods, this.Properties, this.Indexers) = (new(this), new(this), new(this));
				
				internal global::IHaveDims Instance()
				{
					if (!this.WasInstanceInvoked)
					{
						this.WasInstanceInvoked = true;
						var @mock = new RockIHaveDims(this);
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
			new[] { (typeof(RockAttributeGenerator), "IHaveDims_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}
}