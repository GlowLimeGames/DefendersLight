/*
 * Author(s): Isaiah Mann
 * Description: Represents a standard line equation (y(x) = mx + b)
 */

[System.Serializable]
public class LinearEquation : MathEquation {
	public float Slope;
	public int YIntercept;

	public LinearEquation (float slope, int yIntercept) {
		this.Slope = slope;
		this.YIntercept = yIntercept;
	}

	public override int Calculate (int input) {
		return (int) (Slope * input) + YIntercept;
	}
}
