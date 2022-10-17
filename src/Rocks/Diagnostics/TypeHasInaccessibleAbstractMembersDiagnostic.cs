﻿using Microsoft.CodeAnalysis;
using Rocks.Extensions;
using System.Globalization;

namespace Rocks.Diagnostics;

public static class TypeHasInaccessibleAbstractMembersDiagnostic
{
	internal static Diagnostic Create(ITypeSymbol type) =>
		Diagnostic.Create(new(TypeHasInaccessibleAbstractMembersDiagnostic.Id, TypeHasInaccessibleAbstractMembersDiagnostic.Title,
			string.Format(CultureInfo.CurrentCulture, TypeHasInaccessibleAbstractMembersDiagnostic.Message,
				type.GetName()),
			DiagnosticConstants.Usage, DiagnosticSeverity.Error, true,
			helpLinkUri: HelpUrlBuilder.Build(
				TypeHasInaccessibleAbstractMembersDiagnostic.Id, TypeHasInaccessibleAbstractMembersDiagnostic.Title)),
			type.Locations.Length > 0 ? type.Locations[0] : null);

	public const string Id = "ROCK8";
	public const string Message = "The type {0} has inaccessible abstract members and cannot be mocked";
	public const string Title = "Type Has Inaccessible Abstract Members";
}