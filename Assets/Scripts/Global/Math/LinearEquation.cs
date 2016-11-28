/*
 * Author(s): Isaiah Mann
 * Description: Represents a standard line equation (y(x) = mx + b)
 */

[System.Serializable]
public class LinearEquation : MathEquation {
	public float Slope;
	public float YIntercept;

	public LinearEquation (float slope, float yIntercept) {
		this.Slope = slope;
		this.YIntercept = yIntercept;
	}

	public override float Calculate (float input) {
		return Slope * input + YIntercept;
	}

	public static LinearEquation Default {
		get {
			return new LinearEquation(1, 0);
		}
	}
}
