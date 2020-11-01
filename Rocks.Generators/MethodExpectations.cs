﻿using Rocks.Extensions;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Rocks
{
	internal sealed class MethodExpectations<T> 
		where T : class
	{
		private readonly Expectations<T> expectations;

		internal MethodExpectations(Expectations<T> expectations) =>
			this.expectations = expectations;

		internal HandlerInformation Add(int memberIdentifier, Dictionary<int, Arg> arguments)
		{
			var information = new HandlerInformation(arguments.ToImmutableDictionary());
			this.expectations.Handlers.AddOrUpdate(memberIdentifier,
				() => new List<HandlerInformation> { information }, _ => _.Add(information));
			return information;
		}
	}
}