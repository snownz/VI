﻿using System.Threading.Tasks;

namespace VI.NumSharp.Arrays
{
    public static class FloatArrayExtension
    {
        public static FloatArray Tanh(this FloatArray arr)
        {
            return new FloatArray(ProcessingDevice.FloatExecutor.Tanh(arr.Cache, arr.View));
        }

        public static FloatArray Sin(this FloatArray arr)
        {
            return new FloatArray(ProcessingDevice.FloatExecutor.Sin(arr.Cache, arr.View));
        }

        public static FloatArray Cos(this FloatArray arr)
        {
            return new FloatArray(ProcessingDevice.FloatExecutor.Cos(arr.Cache, arr.View));
        }

        public static FloatArray Pow(this FloatArray arr, float exp)
        {
            return new FloatArray(ProcessingDevice.FloatExecutor.Pow(arr.Cache, arr.View, exp));
        }

        public static FloatArray Exp(this FloatArray arr)
        {
            return new FloatArray(ProcessingDevice.FloatExecutor.Exp(arr.Cache, arr.View));
        }

        public static FloatArray Log(this FloatArray arr)
        {
            return new FloatArray(ProcessingDevice.FloatExecutor.Log(arr.Cache, arr.View));
        }

        public static FloatArray2D Sqrt(this FloatArray2D arr)
        {
            return new FloatArray2D(ProcessingDevice.FloatExecutor.Sqrt(arr.Cache, arr.View));
        }

        public static FloatArray Sqrt(this FloatArray arr)
        {
            return new FloatArray(ProcessingDevice.FloatExecutor.Sqrt(arr.Cache, arr.View));
        }

        public static int Pos(this FloatArray arr, float v)
        {
            int pos = -1;
            Parallel.For(0, arr.Length, i =>
            {
                if (arr[i] == v)
                {
                    pos = i;
                }
            });
            return pos;
        }

        public static FloatArray SumLine(this FloatArray2D arr)
        {
            return new FloatArray(ProcessingDevice.FloatExecutor.SumLine(arr.View));
        }

        public static FloatArray SumColumn(this FloatArray2D arr)
        {
            return new FloatArray(ProcessingDevice.FloatExecutor.SumColumn(arr.View));
        }

        public static FloatArray Divide(this FloatArray arr)
        {
            var result = new FloatArray(arr.Length / 2);
            Parallel.For(0, arr.Length, i => result[i] = arr[i] + arr[i + result.Length]);
            return result;
        }

        public static float Sum(this FloatArray arr)
        {
            var sum = 0f;
            for (var i = 0; i < arr.Length; i++) sum += arr[i];
            return sum;
        }
    }
}