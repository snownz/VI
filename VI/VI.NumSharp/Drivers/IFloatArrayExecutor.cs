﻿namespace VI.NumSharp.Drivers
{
	public interface IFloatArrayExecutor
	{
		IFloatData V_mult_V(IFloatData v0, IFloatData v1);
		IFloatData V_div_V(IFloatData v0, IFloatData v1);
		IFloatData V_sub_V(IFloatData v0, IFloatData v1);
		IFloatData V_add_V(IFloatData v0, IFloatData v1);

		IFloatData V_add_C(IFloatData v, float c);

		IFloatData V_mult_C(IFloatData v, float c);

		IFloatData V_sub_C(IFloatData v, float c);
		IFloatData V_sub_C(float c, IFloatData v);

		IFloatData V_div_C(IFloatData v, float c);
		IFloatData V_div_C(float c, IFloatData v);

		IFloatData2D VT_mult_V(IFloatData vt, IFloatData v);
		IFloatData2D V_mult_VT(IFloatData v, IFloatData vt);
		IFloatData2D VT_mult_M(IFloatData vt, IFloatData2D m);

		IFloatData2D M_mult_M(IFloatData2D m0, IFloatData2D m1);
		IFloatData2D M_div_M(IFloatData2D m0, IFloatData2D m1);
		IFloatData2D M_sub_M(IFloatData2D m0, IFloatData2D m1);
		IFloatData2D M_add_M(IFloatData2D m0, IFloatData2D m1);

		IFloatData2D M_mult_VT(IFloatData2D m, IFloatData v);
		IFloatData2D M_mult_V(IFloatData2D m, IFloatData v);
		IFloatData2D V_mult_M(IFloatData v, IFloatData2D m);

		IFloatData2D M_mult_C(IFloatData2D m, float c);
		IFloatData2D M_add_C(IFloatData2D m, float c);

		IFloatData2D M_div_C(IFloatData2D m, float c);
		IFloatData2D C_div_M(IFloatData2D m, float c);
		IFloatData2D C_div_M(IFloatData2D m, int c);

		IFloatData2D M_mult_MT(IFloatData2D m0, IFloatData2D m1);
		IFloatData2D MT_mult_M(IFloatData2D m0, IFloatData2D m1);

		IFloatData ApplyMask(IFloatData arr, IByteData mask);

		IFloatData2D ApplyMask(IFloatData2D arr, IByteData2D mask);

		IFloatData Tanh(IFloatData arr);

		IFloatData Sin(IFloatData arr);

		IFloatData Cos(IFloatData arr);

		IFloatData Pow(IFloatData arr, float exp);

		IFloatData Exp(IFloatData arr);

		IFloatData Log(IFloatData arr);

		IFloatData2D Sqrt(IFloatData2D arr);

		IFloatData Sqrt(IFloatData arr);

		IFloatData SumLine(IFloatData2D arr);

		IFloatData SumColumn(IFloatData2D arr);

	}
}