﻿using VI.Maths.Array;
using VI.ParallelComputing;
using VI.ParallelComputing.Drivers;

namespace VI.NumSharp
{
    public static partial class ProcessingDevice
    {
        private static DeviceType _device;
        private static IAnnParallelInterface _cpuArrayDevice;
        private static IAnnParallelInterface _cudaArrayDevice;

        public static DeviceType Device
        {
            get { return _device; }
            set
            {
                switch (value)
                {
                    case DeviceType.CUDA:
                        ArrayDevice = CUDAArrayDevice;
                        break;
                    case DeviceType.CPU:
                        ArrayDevice = CPUArrayDevice;
                        break;
                }
                _device = value;
            }
        }

        private static IAnnParallelInterface CPUArrayDevice
            => _cpuArrayDevice ?? (_cpuArrayDevice = new CpuAnnInterface<ArrayOperations>());
        private static IAnnParallelInterface CUDAArrayDevice
            => _cudaArrayDevice ?? (_cudaArrayDevice = new CudaAnnInterface<ArrayOperations>());

        public static IAnnParallelInterface ArrayDevice { get; private set; }
    }    
}
