﻿using Microsoft.CodeAnalysis;
using Rocks.Extensions;
using System.Globalization;

namespace Rocks.Diagnostics;

internal static class CannotMockObsoleteTypeDiagnostic
{
	internal static Diagnostic Create(SyntaxNode node, ITypeSymbol type) =>
		Diagnostic.Create(new(CannotMockObsoleteTypeDiagnostic.Id, CannotMockObsoleteTypeDiagnostic.Title,
			string.Format(CultureInfo.CurrentCulture, CannotMockObsoleteTypeDiagnostic.Message,
				type.GetName()),
			DiagnosticConstants.Usage, DiagnosticSeverity.Error, true,
			helpLinkUri: HelpUrlBuilder.Build(
				CannotMockObsoleteTypeDiagnostic.Id, CannotMockObsoleteTypeDiagnostic.Title)),
			node.GetLocation());

	internal const string Id = "ROCK2";
	internal const string Message = "The type {0} is obsolete and cannot be mocked";
	internal const string Title = "Cannot Mock Obsolete Types";
}