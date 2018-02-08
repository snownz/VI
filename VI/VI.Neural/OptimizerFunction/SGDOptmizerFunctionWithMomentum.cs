﻿using VI.Neural.Layer;

namespace VI.Neural.OptimizerFunction
{
	public class SGDOptmizerFunctionWithMomentum : IOptimizerFunction
	{
		public void CalculateParams(ILayer target)
		{
			target.CachedMomentum     = target.LearningRate * target.Momentum;
			target.CachedLearningRate = target.LearningRate * (1 - target.Momentum);
		}

		public void UpdateWeight(ILayer target)
		{
			var update = target.GradientMatrix * target.CachedLearningRate;
			var momentum = target.KnowlodgeMatrix * target.CachedMomentum;
			target.KnowlodgeMatrix += (update + momentum);
		}

		public void UpdateBias(ILayer target)
		{
			var update = target.ErrorVector * target.CachedLearningRate;
			var momentum = target.BiasVector * target.CachedMomentum;
			target.BiasVector +=  (update + momentum);
		}
	}
}