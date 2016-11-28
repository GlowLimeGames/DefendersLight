/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using System;
[Serializable]
public class QuadraticEquation : MathEquation {
	public float Exponent;
	public float YIntercept;
	public float XIntercept;
	public float Scalar;
	public QuadraticEquation (float exponent, float yInter, float xInter, float scalar) {
		this.Exponent = exponent;
		this.YIntercept = yInter;
		this.XIntercept = xInter;
		this.Scalar = scalar;
	}

	public override float Calculate (float input) {
		return this.Scalar * (float) Math.Pow(input + this.XIntercept, this.Exponent) + this.YIntercept;
	}

}
