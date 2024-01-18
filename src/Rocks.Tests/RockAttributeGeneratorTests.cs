﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Rocks.Tests;

public static class RockAttributeGeneratorTests
{
	[Test]
	public static async Task CreateWhenTargetTypeContainsCompilerGeneratedMembersAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			
			[assembly: RockCreate<MockTests.IContainNullableReferences>]
			
			#nullable enable

			namespace MockTests
			{
				public interface IContainNullableReferences
				{
					string? DoSomething(string? a, string b);
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class IContainNullableReferencesCreateExpectations
					: global::Rocks.Expectations
				{
					#pragma warning disable CS8618
					
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Func<string?, string, string?>, string?>
					{
						public global::Rocks.Argument<string?> @a { get; set; }
						public global::Rocks.Argument<string> @b { get; set; }
					}
					
					#pragma warning restore CS8618
					
					private global::System.Collections.Generic.List<global::MockTests.IContainNullableReferencesCreateExpectations.Handler0>? @handlers0;
					
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
						: global::MockTests.IContainNullableReferences
					{
						public Mock(global::MockTests.IContainNullableReferencesCreateExpectations @expectations)
						{
							this.Expectations = @expectations;
						}
						
						[global::Rocks.MemberIdentifier(0, "string? DoSomething(string? @a, string @b)")]
						public string? DoSomething(string? @a, string @b)
						{
							if (this.Expectations.handlers0?.Count > 0)
							{
								foreach (var @handler in this.Expectations.handlers0)
								{
									if (@handler.@a.IsValid(@a!) &&
										@handler.@b.IsValid(@b!))
									{
										@handler.CallCount++;
										var @result = @handler.Callback is not null ?
											@handler.Callback(@a!, @b!) : @handler.ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for string? DoSomething(string? @a, string @b)");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for string? DoSomething(string? @a, string @b)");
						}
						
						private global::MockTests.IContainNullableReferencesCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.IContainNullableReferencesCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.IContainNullableReferencesCreateExpectations.Handler0, global::System.Func<string?, string, string?>, string?> DoSomething(global::Rocks.Argument<string?> @a, global::Rocks.Argument<string> @b)
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							global::System.ArgumentNullException.ThrowIfNull(@a);
							global::System.ArgumentNullException.ThrowIfNull(@b);
							
							var handler = new global::MockTests.IContainNullableReferencesCreateExpectations.Handler0
							{
								@a = @a,
								@b = @b,
							};
							
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.IContainNullableReferencesCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.IContainNullableReferencesCreateExpectations.MethodExpectations Methods { get; }
					
					internal IContainNullableReferencesCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal global::MockTests.IContainNullableReferences Instance()
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

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.IContainNullableReferences_Rock_Create.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task CreateWhenTargetTypeIsValidAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<MockTests.ITest>]

			namespace MockTests
			{
				public interface ITest
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
				internal sealed class ITestCreateExpectations
					: global::Rocks.Expectations
				{
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Action>
					{ }
					
					private global::System.Collections.Generic.List<global::MockTests.ITestCreateExpectations.Handler0>? @handlers0;
					
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
						: global::MockTests.ITest
					{
						public Mock(global::MockTests.ITestCreateExpectations @expectations)
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
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Foo()");
							}
						}
						
						private global::MockTests.ITestCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.ITestCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.ITestCreateExpectations.Handler0, global::System.Action> Foo()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
							var handler = new global::MockTests.ITestCreateExpectations.Handler0();
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.ITestCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.ITestCreateExpectations.MethodExpectations Methods { get; }
					
					internal ITestCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal global::MockTests.ITest Instance()
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

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.ITest_Rock_Create.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task CreateWhenTargetTypeIsInGlobalNamespaceAsync()
	{
		var code =
			"""
			using Rocks;
			using System;

			[assembly: RockCreate<ITest>]

			public interface ITest
			{
				void Foo();
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class ITestCreateExpectations
				: global::Rocks.Expectations
			{
				internal sealed class Handler0
					: global::Rocks.Handler<global::System.Action>
				{ }
				
				private global::System.Collections.Generic.List<global::ITestCreateExpectations.Handler0>? @handlers0;
				
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
					: global::ITest
				{
					public Mock(global::ITestCreateExpectations @expectations)
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
						}
						else
						{
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Foo()");
						}
					}
					
					private global::ITestCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::ITestCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.Adornments<global::ITestCreateExpectations.Handler0, global::System.Action> Foo()
					{
						global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
						if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
						var handler = new global::ITestCreateExpectations.Handler0();
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					private global::ITestCreateExpectations Expectations { get; }
				}
				
				internal global::ITestCreateExpectations.MethodExpectations Methods { get; }
				
				internal ITestCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::ITest Instance()
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
			new[] { (typeof(RockAttributeGenerator), "ITest_Rock_Create.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task CreateWhenAnExactMatchWithANonVirtualMemberExistsAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<TypeConverter<TypeNode>>]

			public class TypeNode { }

			public interface IIRTypeContext { }

			public interface ITypeConverter<TType>
				where TType : TypeNode
			{
				TypeNode ConvertType<TTypeContext>(TTypeContext typeContext, TType type)
					where TTypeContext : IIRTypeContext;
			}

			public abstract class TypeConverter<TType> : ITypeConverter<TypeNode>
				where TType : TypeNode
			{
				protected abstract TypeNode ConvertType<TTypeContext>(
					TTypeContext typeContext,
					TType type)
					where TTypeContext : IIRTypeContext;

				public TypeNode ConvertType<TTypeContext>(
					TTypeContext typeContext,
					TypeNode type)
					where TTypeContext : IIRTypeContext => new();
			}
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			Enumerable.Empty<(Type, string, string)>(),
			[]);
	}

	[Test]
	public static async Task CreateWhenTargetTypeIsInvalidAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<MockTests.ITest>]

			namespace MockTests
			{
				public interface ITest { }
			}
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			Enumerable.Empty<(Type, string, string)>(),
			[]);
	}

	[Test]
	public static async Task CreateWhenTargetTypeHasDiagnosticsAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<MockTests.ITest>]

			namespace MockTests
			{
				public interface ITest 
				{ 
					// Note the missing semicolon
					void Foo()
				}
			}
			""";

		var diagnostic = new DiagnosticResult("CS1002", DiagnosticSeverity.Error)
			.WithSpan(10, 13, 10, 13);
		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			Enumerable.Empty<(Type, string, string)>(),
			[diagnostic]);
	}

	[Test]
	public static async Task CreateWhenTargetTypeIsValidButOtherCodeHasDiagnosticsAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockCreate<MockTests.ITest>]

			namespace MockTests
			{
				public interface ITest 
				{ 
					void Foo();
			// Note the missing closing brace
				}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class ITestCreateExpectations
					: global::Rocks.Expectations
				{
					internal sealed class Handler0
						: global::Rocks.Handler<global::System.Action>
					{ }
					
					private global::System.Collections.Generic.List<global::MockTests.ITestCreateExpectations.Handler0>? @handlers0;
					
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
						: global::MockTests.ITest
					{
						public Mock(global::MockTests.ITestCreateExpectations @expectations)
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
							}
							else
							{
								throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for void Foo()");
							}
						}
						
						private global::MockTests.ITestCreateExpectations Expectations { get; }
					}
					
					internal sealed class MethodExpectations
					{
						internal MethodExpectations(global::MockTests.ITestCreateExpectations expectations) =>
							this.Expectations = expectations;
						
						internal global::Rocks.Adornments<global::MockTests.ITestCreateExpectations.Handler0, global::System.Action> Foo()
						{
							global::Rocks.Exceptions.ExpectationException.ThrowIf(this.Expectations.WasInstanceInvoked);
							if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
							var handler = new global::MockTests.ITestCreateExpectations.Handler0();
							this.Expectations.handlers0.Add(handler);
							return new(handler);
						}
						
						private global::MockTests.ITestCreateExpectations Expectations { get; }
					}
					
					internal global::MockTests.ITestCreateExpectations.MethodExpectations Methods { get; }
					
					internal ITestCreateExpectations() =>
						(this.Methods) = (new(this));
					
					internal global::MockTests.ITest Instance()
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

		var diagnostic = new DiagnosticResult("CS1513", DiagnosticSeverity.Error)
			.WithSpan(11, 3, 11, 3);
		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.ITest_Rock_Create.g.cs", generatedCode) },
			[diagnostic]);
	}

	[Test]
	public static async Task MakeWhenValueTaskOfTIsReturnedAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Threading.Tasks;

			[assembly: RockMake<MockTests.ITest>]

			namespace MockTests
			{
				public interface ITest
				{
					ValueTask<T> Foo<T>();
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class ITestMakeExpectations
				{
					internal global::MockTests.ITest Instance()
					{
						return new Mock();
					}
					
					private sealed class Mock
						: global::MockTests.ITest
					{
						public Mock()
						{
						}
						
						public global::System.Threading.Tasks.ValueTask<T> Foo<T>()
						{
							return new global::System.Threading.Tasks.ValueTask<T>(default(T)!);
						}
					}
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.ITest_Rock_Make.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task MakeWhenTargetTypeIsValidAsync()
	{
		var code =
			"""
			using Rocks;
			using System;
			using System.Threading.Tasks;

			[assembly: RockMake<MockTests.ITest>]

			namespace MockTests
			{
				public interface ITest
				{
					unsafe int* Foo(int* value);
					unsafe delegate*<int, void> FooMethod(delegate*<int, void> value);
					unsafe int* Data { get; set; }
					unsafe delegate*<int, void> DataMethod { get; set; }
					unsafe int* this[int* a] { get; set; }
					unsafe delegate*<int, void> this[delegate*<int, void> a] { get; set; }
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class ITestMakeExpectations
				{
					internal global::MockTests.ITest Instance()
					{
						return new Mock();
					}
					
					private sealed class Mock
						: global::MockTests.ITest
					{
						public Mock()
						{
						}
						
						public unsafe int* Foo(int* @value)
						{
							return default!;
						}
						public unsafe delegate*<int, void> FooMethod(delegate*<int, void> @value)
						{
							return default!;
						}
						public unsafe int* Data
						{
							get => default!;
							set { }
						}
						public unsafe delegate*<int, void> DataMethod
						{
							get => default!;
							set { }
						}
						public unsafe int* this[int* @a]
						{
							get => default!;
							set { }
						}
						public unsafe delegate*<int, void> this[delegate*<int, void> @a]
						{
							get => default!;
							set { }
						}
					}
				}
			}
			
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.ITest_Rock_Make.g.cs", generatedCode) },
			[]);
	}

	[Test]
	public static async Task MakeWhenTargetTypeIsInvalidAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockMake<MockTests.InvalidTarget>]

			namespace MockTests
			{
				public sealed class InvalidTarget { }
			}
			""";

		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			Enumerable.Empty<(Type, string, string)>(),
			[]);
	}

	[Test]
	public static async Task MakeWhenTargetTypeHasDiagnosticsAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockMake<MockTests.ITest>]

			namespace MockTests
			{
				public interface ITest 
				{ 
					// Note the missing semicolon
					void Foo()
				}
			}
			""";

		var diagnostic = new DiagnosticResult("CS1002", DiagnosticSeverity.Error)
			.WithSpan(10, 13, 10, 13);
		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			Enumerable.Empty<(Type, string, string)>(),
			[diagnostic]);
	}

	[Test]
	public static async Task MakeWhenTargetTypeIsValidButOtherCodeHasDiagnosticsAsync()
	{
		var code =
			"""
			using Rocks;

			[assembly: RockMake<MockTests.ITest>]

			namespace MockTests
			{
				public interface ITest 
				{ 
					void Foo();
					// Note the missing closing brace
				}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			namespace MockTests
			{
				internal sealed class ITestMakeExpectations
				{
					internal global::MockTests.ITest Instance()
					{
						return new Mock();
					}
					
					private sealed class Mock
						: global::MockTests.ITest
					{
						public Mock()
						{
						}
						
						public void Foo()
						{
						}
					}
				}
			}
			
			""";

		var diagnostic = new DiagnosticResult("CS1513", DiagnosticSeverity.Error)
			.WithSpan(11, 3, 11, 3);
		await TestAssistants.RunGeneratorAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "MockTests.ITest_Rock_Make.g.cs", generatedCode) },
			[diagnostic]);
	}
}