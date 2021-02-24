﻿using NUnit.Framework;

namespace Rocks.Tests
{
	public static class ObjectEqualityTests
	{
		[Test]
		public static void AreEqualWhenBothAreNull() =>
			Assert.That(ObjectEquality.AreEqual<string?>(null, null), Is.True);

		[Test]
		public static void AreEqualWhenValue1IsNull() =>
			Assert.That(ObjectEquality.AreEqual(null as string, "a"), Is.False);

		[Test]
		public static void AreEqualWhenValue2IsNull() =>
			Assert.That(ObjectEquality.AreEqual("a", null as string), Is.False);

		[Test]
		public static void AreEqualWhenValuesAreNotArrays() =>
			Assert.That(ObjectEquality.AreEqual("a", "a"), Is.True);

		[Test]
		public static void AreEqualWhenValuesAreArrayWithDifferentLengths() =>
			Assert.That(ObjectEquality.AreEqual(new[] { "a" }, new[] { "a", "b" }), Is.False);

		[Test]
		public static void AreEqualWhenValuesAreArrayWithSameLengthsAndDifferentValues() =>
			Assert.That(ObjectEquality.AreEqual(new[] { "a" }, new[] { "b" }), Is.False);

		[Test]
		public static void AreEqualWhenValuesAreArrayWithSameLengthsAndValues() =>
			Assert.That(ObjectEquality.AreEqual(new[] { "a" }, new[] { "a" }), Is.True);
	}
}