﻿using VI.Neural.Layer;
using VI.NumSharp;
using VI.NumSharp.Arrays;

namespace VI.Neural.OptimizerFunction
{
	public class AdagradOptimizerFunction : IOptimizerFunction
	{
		private FloatArray mB;
		private FloatArray2D mW;

		public void CalculateParams(ILayer target)
		{
			mW = NumMath.Array(target.Size, target.ConectionsSize, 0f);
			mB = NumMath.Array(target.Size, 0f);
		}

		public void UpdateBias(ILayer target)
		{
			mB                += target.ErrorVector   * target.ErrorVector;
			target.BiasVector += -target.LearningRate * target.ErrorVector / (mB + 1e-8f).Sqrt();
		}

		public void UpdateWeight(ILayer target)
		{
			mW                     += target.GradientMatrix * target.GradientMatrix;
			target.KnowlodgeMatrix += -target.LearningRate  * target.GradientMatrix / (mW + 1e-8f).Sqrt();
		}
	}
}