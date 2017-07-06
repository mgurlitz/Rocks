﻿using NUnit.Framework;
using Rocks.Templates;

namespace Rocks.Tests.Templates
{
	[TestFixture]
	public sealed class ClassTemplatesTests
	{
		[Test]
		public void GetClassWithObsoleteSuppression() =>
			Assert.That(ClassTemplates.GetClassWithObsoleteSuppression("a"), Is.EqualTo(
@"#pragma warning disable CS0618
#pragma warning disable CS0672
a
#pragma warning restore CS0672
#pragma warning restore CS0618"));

#if !NETCOREAPP1_1
		[Test]
		public void GetClassTemplateWhenIsUnsafeIsTrue() =>
			Assert.That(ClassTemplates.GetClass("a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", true, "m", "n", "o"), Is.EqualTo(
@"#pragma warning disable CS8019
using R = Rocks;
using RE = Rocks.Exceptions;
using S = System;
using SCG = System.Collections.Generic;
using SCO = System.Collections.ObjectModel;
using SR = System.Reflection;
using STT = System.Threading.Tasks;
a
#pragma warning restore CS8019

namespace h
{
	i
	public unsafe sealed class b
		: c, n m
	{
		private SCO.ReadOnlyDictionary<int, SCO.ReadOnlyCollection<R.HandlerInformation>> handlers;

		k

		g

		d

		e

		f

		SCO.ReadOnlyDictionary<int, SCO.ReadOnlyCollection<R.HandlerInformation>> R.IMock.Handlers => this.handlers;

		o

		l
	}
}"));
#else
		[Test]
		public void GetClassTemplateWhenIsUnsafeIsTrue() =>
			Assert.That(ClassTemplates.GetClass("a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", true, "m", "n", "o"), Is.EqualTo(
@"#pragma warning disable CS8019
using R = Rocks;
using RE = Rocks.Exceptions;
using S = System;
using SCG = System.Collections.Generic;
using SCO = System.Collections.ObjectModel;
using SR = System.Reflection;
using STT = System.Threading.Tasks;
a
using System.Reflection;
#pragma warning restore CS8019

namespace h
{
	i
	public unsafe sealed class b
		: c, n m
	{
		private SCO.ReadOnlyDictionary<int, SCO.ReadOnlyCollection<R.HandlerInformation>> handlers;

		k

		g

		d

		e

		f

		SCO.ReadOnlyDictionary<int, SCO.ReadOnlyCollection<R.HandlerInformation>> R.IMock.Handlers => this.handlers;

		o

		l
	}
}"));
#endif

#if !NETCOREAPP1_1
		[Test]
		public void GetClassTemplateWhenIsUnsafeIsFalse() =>
			Assert.That(ClassTemplates.GetClass("a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", false, "m", "n", "o"), Is.EqualTo(
@"#pragma warning disable CS8019
using R = Rocks;
using RE = Rocks.Exceptions;
using S = System;
using SCG = System.Collections.Generic;
using SCO = System.Collections.ObjectModel;
using SR = System.Reflection;
using STT = System.Threading.Tasks;
a
#pragma warning restore CS8019

namespace h
{
	i
	public  sealed class b
		: c, n m
	{
		private SCO.ReadOnlyDictionary<int, SCO.ReadOnlyCollection<R.HandlerInformation>> handlers;

		k

		g

		d

		e

		f

		SCO.ReadOnlyDictionary<int, SCO.ReadOnlyCollection<R.HandlerInformation>> R.IMock.Handlers => this.handlers;

		o

		l
	}
}"));
#else
		[Test]
		public void GetClassTemplateWhenIsUnsafeIsFalse() =>
			Assert.That(ClassTemplates.GetClass("a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", false, "m", "n", "o"), Is.EqualTo(
@"#pragma warning disable CS8019
using R = Rocks;
using RE = Rocks.Exceptions;
using S = System;
using SCG = System.Collections.Generic;
using SCO = System.Collections.ObjectModel;
using SR = System.Reflection;
using STT = System.Threading.Tasks;
a
using System.Reflection;
#pragma warning restore CS8019

namespace h
{
	i
	public  sealed class b
		: c, n m
	{
		private SCO.ReadOnlyDictionary<int, SCO.ReadOnlyCollection<R.HandlerInformation>> handlers;

		k

		g

		d

		e

		f

		SCO.ReadOnlyDictionary<int, SCO.ReadOnlyCollection<R.HandlerInformation>> R.IMock.Handlers => this.handlers;

		o

		l
	}
}"));
#endif
	}
}
