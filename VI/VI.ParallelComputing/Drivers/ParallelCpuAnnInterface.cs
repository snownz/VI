﻿using System;
using ILGPU.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VI.ParallelComputing.Drivers
{
    public class ParallelCpuAnnInterface<T> : IAnnParallelInterface
    {
        private readonly Accelerator _accelerator;
        private readonly ParalleExecutorlInterface _interface;

        public ParalleExecutorlInterface Executor => _interface;

        public ParallelCpuAnnInterface()
        {
            try
            {
                _accelerator = Device.CPU;
            }
            catch (Exception)
            {
                Console.WriteLine("\n-----------\nCPU is not supported\n-----------\n");
                return;
            }
            
            using (var translator = new ParallelTranslator(_accelerator))
            {
                var kernels = ComputeKernels(translator);
                _interface = new ParalleExecutorlInterface(_accelerator, kernels);
            }
        }

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

            for (int i = 0; i < methods.Count(); i++)
            {
                var kernel = _accelerator.LoadAutoGroupedKernel(compileds[i]);
                result.Add(methods[i], kernel);
            }

            return result;
        }
    }
}
