﻿using BenchmarkDotNet.Running;
using Rocks.Performance;

#pragma warning disable CA1852 // Seal internal types
BenchmarkRunner.Run<CastingComparisonConstruction>();
#pragma warning restore CA1852 // Seal internal types