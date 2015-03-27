﻿using System;
using System.Linq;

namespace Rocks.Sketchpad
{
	public static class Delegates
	{
		public delegate void RefTargetWithoutGeneric(ref Guid a);
		public delegate void RefTargetWithGeneric<T>(ref T a);

		private static void TargetWithGeneric<T>(ref T a) { }

		public static void Test<Q>()
		{
			var generic = new RefTargetWithGeneric<Guid>(Delegates.TargetWithGeneric<Guid>);
			var castedGeneric = (generic as RefTargetWithGeneric<Guid>);

			var delegates = new[]
			{
				typeof(RefTargetWithoutGeneric),
				typeof(RefTargetWithGeneric<>),
				typeof(Guid),
				typeof(Q),
				typeof(RefTargetWithGeneric<Guid>)
			};

			foreach(var @delegate in delegates)
			{
				Console.Out.WriteLine(@delegate.Name);
				Console.Out.WriteLine(@delegate.FullName);
				Console.Out.WriteLine(@delegate.IsGenericType);

				if(typeof(MulticastDelegate).IsAssignableFrom(@delegate.BaseType) && @delegate.IsGenericType)
				{
					var parameters = string.Join(", ", 
						@delegate.GetGenericArguments().Select(_ => _.Name));
					var correctedName = @delegate.FullName.Split('`')[0].Split('.').Last().Replace("+", ".");
               Console.Out.WriteLine($"{correctedName}<{parameters}>");
            }

				Console.Out.WriteLine();
			}
		}
	}
}