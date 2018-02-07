﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ILGPU.Runtime;

namespace VI.ParallelComputing.Drivers
{
	public class CudaAnnInterface<T> : IAnnParallelInterface
	{
		private readonly Accelerator _accelerator;

		public CudaAnnInterface()
		{
			try
			{
				_accelerator = Device.CUDA;
			}
			catch (Exception)
			{
				Console.WriteLine("\n-----------\nCUDA is not supported\n-----------\n");
				return;
			}

			using (var translator = new ParallelTranslator(_accelerator))
			{
				var kernels = ComputeKernels(translator);
				Executor    = new ParalleExecutorlInterface(_accelerator, kernels);
			}
		}

		public ParalleExecutorlInterface Executor { get; }

		private Dictionary<string, Kernel> ComputeKernels(ParallelTranslator translator)
		{
			var result = new Dictionary<string, Kernel>();

			var methods = typeof(T)
				.GetMethods(BindingFlags.Static | BindingFlags.Public)
				.Select(x => x.Name)
				.ToList();

			var compileds = translator
				.TranslateMethod(typeof(T), methods)
				.ToList();

			for (var i = 0; i < methods.Count(); i++)
			{
				var kernel = _accelerator.LoadAutoGroupedKernel(compileds[i]);
				result.Add(methods[i], kernel);
			}

			return result;
		}
	}
}