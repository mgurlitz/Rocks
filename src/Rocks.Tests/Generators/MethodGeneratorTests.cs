﻿using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Rocks.Tests.Generators;

public static class MethodGeneratorTests
{
	[Test]
	public static async Task GenerateWhenMethodHasOver16ParametersAsync()
	{
		var code =
			"""
			using Rocks;

			namespace MockTests
			{
				public interface IHaveTooMuch
				{
					int AddProperty(
						int i0, int i1, int i2, int i3, int i4,
						int i5, int i6, int i7, int i8, int i9,
						int i10, int i11, int i12, int i13, int i14,
						int i15, int i16, int i17, int i18, int i19);
				}

				public static class Test
				{
					public static void Generate()
					{
						var rock = Rock.Create<IHaveTooMuch>();
					}
				}
			}
			""";

		var generatedCode =
			"""
			using MockTests.ProjectionsForIHaveTooMuch;
			using Rocks.Extensions;
			using System.Collections.Generic;
			using System.Collections.Immutable;
			#nullable enable
			
			namespace MockTests
			{
				namespace ProjectionsForIHaveTooMuch
				{
					internal delegate int AddPropertyCallback_72853676484114143792518254191874903532168788273(int @i0, int @i1, int @i2, int @i3, int @i4, int @i5, int @i6, int @i7, int @i8, int @i9, int @i10, int @i11, int @i12, int @i13, int @i14, int @i15, int @i16, int @i17, int @i18, int @i19);
				}
				
				internal static class CreateExpectationsOfIHaveTooMuchExtensions
				{
					internal static global::Rocks.Expectations.MethodExpectations<global::MockTests.IHaveTooMuch> Methods(this global::Rocks.Expectations.Expectations<global::MockTests.IHaveTooMuch> @self) =>
						new(@self);
					
					internal static global::MockTests.IHaveTooMuch Instance(this global::Rocks.Expectations.Expectations<global::MockTests.IHaveTooMuch> @self)
					{
						if (!@self.WasInstanceInvoked)
						{
							@self.WasInstanceInvoked = true;
							var @mock = new RockIHaveTooMuch(@self);
							@self.MockType = @mock.GetType();
							return @mock;
						}
						else
						{
							throw new global::Rocks.Exceptions.NewMockInstanceException("Can only create a new mock once.");
						}
					}
					
					private sealed class RockIHaveTooMuch
						: global::MockTests.IHaveTooMuch
					{
						private readonly global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.List<global::Rocks.HandlerInformation>> handlers;
						
						public RockIHaveTooMuch(global::Rocks.Expectations.Expectations<global::MockTests.IHaveTooMuch> @expectations)
						{
							this.handlers = @expectations.Handlers;
						}
						
						[global::Rocks.MemberIdentifier(0, "int AddProperty(int @i0, int @i1, int @i2, int @i3, int @i4, int @i5, int @i6, int @i7, int @i8, int @i9, int @i10, int @i11, int @i12, int @i13, int @i14, int @i15, int @i16, int @i17, int @i18, int @i19)")]
						public int AddProperty(int @i0, int @i1, int @i2, int @i3, int @i4, int @i5, int @i6, int @i7, int @i8, int @i9, int @i10, int @i11, int @i12, int @i13, int @i14, int @i15, int @i16, int @i17, int @i18, int @i19)
						{
							if (this.handlers.TryGetValue(0, out var @methodHandlers))
							{
								foreach (var @methodHandler in @methodHandlers)
								{
									if (((global::Rocks.Argument<int>)@methodHandler.Expectations[0]).IsValid(@i0) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[1]).IsValid(@i1) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[2]).IsValid(@i2) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[3]).IsValid(@i3) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[4]).IsValid(@i4) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[5]).IsValid(@i5) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[6]).IsValid(@i6) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[7]).IsValid(@i7) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[8]).IsValid(@i8) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[9]).IsValid(@i9) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[10]).IsValid(@i10) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[11]).IsValid(@i11) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[12]).IsValid(@i12) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[13]).IsValid(@i13) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[14]).IsValid(@i14) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[15]).IsValid(@i15) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[16]).IsValid(@i16) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[17]).IsValid(@i17) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[18]).IsValid(@i18) &&
										((global::Rocks.Argument<int>)@methodHandler.Expectations[19]).IsValid(@i19))
									{
										@methodHandler.IncrementCallCount();
										var @result = @methodHandler.Method is not null ?
											((global::MockTests.ProjectionsForIHaveTooMuch.AddPropertyCallback_72853676484114143792518254191874903532168788273)@methodHandler.Method)(@i0, @i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9, @i10, @i11, @i12, @i13, @i14, @i15, @i16, @i17, @i18, @i19) :
											((global::Rocks.HandlerInformation<int>)@methodHandler).ReturnValue;
										return @result!;
									}
								}
								
								throw new global::Rocks.Exceptions.ExpectationException("No handlers match for int AddProperty(int @i0, int @i1, int @i2, int @i3, int @i4, int @i5, int @i6, int @i7, int @i8, int @i9, int @i10, int @i11, int @i12, int @i13, int @i14, int @i15, int @i16, int @i17, int @i18, int @i19)");
							}
							
							throw new global::Rocks.Exceptions.ExpectationException("No handlers were found for int AddProperty(int @i0, int @i1, int @i2, int @i3, int @i4, int @i5, int @i6, int @i7, int @i8, int @i9, int @i10, int @i11, int @i12, int @i13, int @i14, int @i15, int @i16, int @i17, int @i18, int @i19)");
						}
						
					}
				}
				
				internal static class MethodExpectationsOfIHaveTooMuchExtensions
				{
					internal static global::Rocks.MethodAdornments<global::MockTests.IHaveTooMuch, global::MockTests.ProjectionsForIHaveTooMuch.AddPropertyCallback_72853676484114143792518254191874903532168788273, int> AddProperty(this global::Rocks.Expectations.MethodExpectations<global::MockTests.IHaveTooMuch> @self, global::Rocks.Argument<int> @i0, global::Rocks.Argument<int> @i1, global::Rocks.Argument<int> @i2, global::Rocks.Argument<int> @i3, global::Rocks.Argument<int> @i4, global::Rocks.Argument<int> @i5, global::Rocks.Argument<int> @i6, global::Rocks.Argument<int> @i7, global::Rocks.Argument<int> @i8, global::Rocks.Argument<int> @i9, global::Rocks.Argument<int> @i10, global::Rocks.Argument<int> @i11, global::Rocks.Argument<int> @i12, global::Rocks.Argument<int> @i13, global::Rocks.Argument<int> @i14, global::Rocks.Argument<int> @i15, global::Rocks.Argument<int> @i16, global::Rocks.Argument<int> @i17, global::Rocks.Argument<int> @i18, global::Rocks.Argument<int> @i19)
					{
						global::System.ArgumentNullException.ThrowIfNull(@i0);
						global::System.ArgumentNullException.ThrowIfNull(@i1);
						global::System.ArgumentNullException.ThrowIfNull(@i2);
						global::System.ArgumentNullException.ThrowIfNull(@i3);
						global::System.ArgumentNullException.ThrowIfNull(@i4);
						global::System.ArgumentNullException.ThrowIfNull(@i5);
						global::System.ArgumentNullException.ThrowIfNull(@i6);
						global::System.ArgumentNullException.ThrowIfNull(@i7);
						global::System.ArgumentNullException.ThrowIfNull(@i8);
						global::System.ArgumentNullException.ThrowIfNull(@i9);
						global::System.ArgumentNullException.ThrowIfNull(@i10);
						global::System.ArgumentNullException.ThrowIfNull(@i11);
						global::System.ArgumentNullException.ThrowIfNull(@i12);
						global::System.ArgumentNullException.ThrowIfNull(@i13);
						global::System.ArgumentNullException.ThrowIfNull(@i14);
						global::System.ArgumentNullException.ThrowIfNull(@i15);
						global::System.ArgumentNullException.ThrowIfNull(@i16);
						global::System.ArgumentNullException.ThrowIfNull(@i17);
						global::System.ArgumentNullException.ThrowIfNull(@i18);
						global::System.ArgumentNullException.ThrowIfNull(@i19);
						return new global::Rocks.MethodAdornments<global::MockTests.IHaveTooMuch, global::MockTests.ProjectionsForIHaveTooMuch.AddPropertyCallback_72853676484114143792518254191874903532168788273, int>(@self.Add<int>(0, new global::System.Collections.Generic.List<global::Rocks.Argument>(20) { @i0, @i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9, @i10, @i11, @i12, @i13, @i14, @i15, @i16, @i17, @i18, @i19 }));
					}
				}
			}
			
			""";

		await TestAssistants.RunAsync<RockCreateGenerator>(code,
			new[] { (typeof(RockCreateGenerator), "MockTests.IHaveTooMuch_Rock_Create.g.cs", generatedCode) },
			Enumerable.Empty<DiagnosticResult>()).ConfigureAwait(false);
	}
}