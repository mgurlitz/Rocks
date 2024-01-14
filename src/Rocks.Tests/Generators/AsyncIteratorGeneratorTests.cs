﻿using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class AsyncIteratorGeneratorTests
{
	[Test]
	public static async Task GenerateCreateAsync()
	{
		var code =
			"""
			using Rocks;
			using System.Collections.Generic;
			using System.Runtime.CompilerServices;
			using System.Threading;
			using System.Threading.Tasks;
			
			[assembly: RockCreate<AsyncEnumeration>]

			public class AsyncEnumeration
			{
				public virtual async IAsyncEnumerable<string> GetRecordsAsync(
					[EnumeratorCancellation] CancellationToken cancellationToken = default)
				{
					await Task.CompletedTask;
					yield return "y";
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class AsyncEnumerationCreateExpectations
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
					: global::Rocks.Handler<global::System.Func<global::System.Threading.CancellationToken, global::System.Collections.Generic.IAsyncEnumerable<string>>, global::System.Collections.Generic.IAsyncEnumerable<string>>
				{
					public global::Rocks.Argument<global::System.Threading.CancellationToken> @cancellationToken { get; set; }
				}
				
				#pragma warning restore CS8618
				
				private global::System.Collections.Generic.List<global::AsyncEnumerationCreateExpectations.Handler0>? @handlers0;
				private global::System.Collections.Generic.List<global::AsyncEnumerationCreateExpectations.Handler1>? @handlers1;
				private global::System.Collections.Generic.List<global::AsyncEnumerationCreateExpectations.Handler2>? @handlers2;
				private global::System.Collections.Generic.List<global::AsyncEnumerationCreateExpectations.Handler3>? @handlers3;
				
				public override void Verify()
				{
					if (this.WasInstanceInvoked)
					{
						var failures = new global::System.Collections.Generic.List<string>();
				
						if (this.handlers0?.Count > 0) { failures.AddRange(this.Verify(this.handlers0)); }
						if (this.handlers1?.Count > 0) { failures.AddRange(this.Verify(this.handlers1)); }
						if (this.handlers2?.Count > 0) { failures.AddRange(this.Verify(this.handlers2)); }
						if (this.handlers3?.Count > 0) { failures.AddRange(this.Verify(this.handlers3)); }
				
						if (failures.Count > 0)
						{
							throw new global::Rocks.Exceptions.VerificationException(failures);
						}
					}
				}
				
				private sealed class Mock
					: global::AsyncEnumeration
				{
					public Mock(global::AsyncEnumerationCreateExpectations @expectations)
					{
						this.Expectations = @expectations;
					}
					
					[global::Rocks.MemberIdentifier(0, "bool Equals(object? @obj)")]
					public override bool Equals(object? @obj)
					{
						if (this.Expectations.handlers0?.Count > 0)
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
						if (this.Expectations.handlers1?.Count > 0)
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
						if (this.Expectations.handlers2?.Count > 0)
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
					
					[global::Rocks.MemberIdentifier(3, "global::System.Collections.Generic.IAsyncEnumerable<string> GetRecordsAsync(global::System.Threading.CancellationToken @cancellationToken)")]
					public override global::System.Collections.Generic.IAsyncEnumerable<string> GetRecordsAsync(global::System.Threading.CancellationToken @cancellationToken = default)
					{
						if (this.Expectations.handlers3?.Count > 0)
						{
							foreach (var @handler in this.Expectations.handlers3)
							{
								if (@handler.@cancellationToken.IsValid(@cancellationToken!))
								{
									@handler.CallCount++;
									var @result = @handler.Callback is not null ?
										@handler.Callback(@cancellationToken!) : @handler.ReturnValue;
									return @result!;
								}
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers match for global::System.Collections.Generic.IAsyncEnumerable<string> GetRecordsAsync(global::System.Threading.CancellationToken @cancellationToken = default)");
						}
						else
						{
							return base.GetRecordsAsync(cancellationToken: @cancellationToken!);
						}
					}
					
					private global::AsyncEnumerationCreateExpectations Expectations { get; }
				}
				
				internal sealed class MethodExpectations
				{
					internal MethodExpectations(global::AsyncEnumerationCreateExpectations expectations) =>
						this.Expectations = expectations;
					
					internal global::Rocks.Adornments<global::AsyncEnumerationCreateExpectations.Handler0, global::System.Func<object?, bool>, bool> Equals(global::Rocks.Argument<object?> @obj)
					{
						global::System.ArgumentNullException.ThrowIfNull(@obj);
						
						var handler = new global::AsyncEnumerationCreateExpectations.Handler0
						{
							@obj = @obj,
						};
						
						if (this.Expectations.handlers0 is null ) { this.Expectations.handlers0 = new(); }
						this.Expectations.handlers0.Add(handler);
						return new(handler);
					}
					
					internal new global::Rocks.Adornments<global::AsyncEnumerationCreateExpectations.Handler1, global::System.Func<int>, int> GetHashCode()
					{
						if (this.Expectations.handlers1 is null ) { this.Expectations.handlers1 = new(); }
						var handler = new global::AsyncEnumerationCreateExpectations.Handler1();
						this.Expectations.handlers1.Add(handler);
						return new(handler);
					}
					
					internal new global::Rocks.Adornments<global::AsyncEnumerationCreateExpectations.Handler2, global::System.Func<string?>, string?> ToString()
					{
						if (this.Expectations.handlers2 is null ) { this.Expectations.handlers2 = new(); }
						var handler = new global::AsyncEnumerationCreateExpectations.Handler2();
						this.Expectations.handlers2.Add(handler);
						return new(handler);
					}
					
					internal global::Rocks.Adornments<global::AsyncEnumerationCreateExpectations.Handler3, global::System.Func<global::System.Threading.CancellationToken, global::System.Collections.Generic.IAsyncEnumerable<string>>, global::System.Collections.Generic.IAsyncEnumerable<string>> GetRecordsAsync(global::Rocks.Argument<global::System.Threading.CancellationToken> @cancellationToken)
					{
						global::System.ArgumentNullException.ThrowIfNull(@cancellationToken);
						
						var handler = new global::AsyncEnumerationCreateExpectations.Handler3
						{
							@cancellationToken = @cancellationToken.Transform(default),
						};
						
						if (this.Expectations.handlers3 is null ) { this.Expectations.handlers3 = new(); }
						this.Expectations.handlers3.Add(handler);
						return new(handler);
					}
					internal global::Rocks.Adornments<global::AsyncEnumerationCreateExpectations.Handler3, global::System.Func<global::System.Threading.CancellationToken, global::System.Collections.Generic.IAsyncEnumerable<string>>, global::System.Collections.Generic.IAsyncEnumerable<string>> GetRecordsAsync(global::System.Threading.CancellationToken @cancellationToken = default) =>
						this.GetRecordsAsync(global::Rocks.Arg.Is(@cancellationToken));
					
					private global::AsyncEnumerationCreateExpectations Expectations { get; }
				}
				
				internal global::AsyncEnumerationCreateExpectations.MethodExpectations Methods { get; }
				
				internal AsyncEnumerationCreateExpectations() =>
					(this.Methods) = (new(this));
				
				internal global::AsyncEnumeration Instance()
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
			new[] { (typeof(RockAttributeGenerator), "AsyncEnumeration_Rock_Create.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}

	[Test]
	public static async Task GenerateMakeAsync()
	{
		var code =
			"""
			using Rocks;
			using System.Collections.Generic;
			using System.Runtime.CompilerServices;
			using System.Threading;
			using System.Threading.Tasks;
			
			[assembly: RockMake<AsyncEnumeration>]

			public class AsyncEnumeration
			{
				public virtual async IAsyncEnumerable<string> GetRecordsAsync(
					[EnumeratorCancellation] CancellationToken cancellationToken = default)
				{
					await Task.CompletedTask;
					yield return "y";
				}
			}
			""";

		var generatedCode =
			"""
			// <auto-generated/>
			
			#nullable enable
			
			internal sealed class AsyncEnumerationMakeExpectations
			{
				internal global::AsyncEnumeration Instance()
				{
					return new Mock();
				}
				
				private sealed class Mock
					: global::AsyncEnumeration
				{
					public Mock()
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
					public override global::System.Collections.Generic.IAsyncEnumerable<string> GetRecordsAsync(global::System.Threading.CancellationToken @cancellationToken = default)
					{
						return default!;
					}
				}
			}
			
			""";

		await TestAssistants.RunAsync<RockAttributeGenerator>(code,
			new[] { (typeof(RockAttributeGenerator), "AsyncEnumeration_Rock_Make.g.cs", generatedCode) },
			[]).ConfigureAwait(false);
	}
}