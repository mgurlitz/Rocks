﻿using Microsoft.CodeAnalysis;
using NUnit.Framework;
using Rocks.Descriptors;
using Rocks.Diagnostics;
using System.Globalization;

namespace Rocks.Tests.Descriptors;

public static class TypeHasMatchWithNonVirtualDescriptorTests
{
	[Test]
	public static void Create()
	{
		var descriptor = TypeHasMatchWithNonVirtualDescriptor.Create();

		Assert.Multiple(() =>
		{
			Assert.That(descriptor.Id, Is.EqualTo(TypeHasMatchWithNonVirtualDescriptor.Id));
			Assert.That(descriptor.Title.ToString(CultureInfo.CurrentCulture), Is.EqualTo(TypeHasMatchWithNonVirtualDescriptor.Title));
			Assert.That(descriptor.MessageFormat.ToString(CultureInfo.CurrentCulture), Is.EqualTo(TypeHasMatchWithNonVirtualDescriptor.Message));
			Assert.That(descriptor.DefaultSeverity, Is.EqualTo(DiagnosticSeverity.Error));
			Assert.That(descriptor.Category, Is.EqualTo(DiagnosticConstants.Usage));
			Assert.That(descriptor.HelpLinkUri, Is.EqualTo(HelpUrlBuilder.Build(
				TypeHasMatchWithNonVirtualDescriptor.Id, TypeHasMatchWithNonVirtualDescriptor.Title)));
		});
	}
}