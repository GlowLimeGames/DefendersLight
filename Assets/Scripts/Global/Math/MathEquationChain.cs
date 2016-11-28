/*
 * Author(s): Isaiah Mann
 * Description: 
 */

[System.Serializable]
public class MathEquationChain : MathEquation {
	// Evaluates from 0..Length-1
	public MathEquation[] SubEquations;
	public MathEquationChain (MathEquation[] subEquations) {
		this.SubEquations = subEquations;
	}

	public override float Calculate (float input) {
		if (SubEquations == null || SubEquations.Length == 0) {
			return base.Calculate (input);
		} else {
			float currentValue = input;
			for (int i = 0; i < SubEquations.Length; i++) {
				currentValue = SubEquations[i].Calculate(currentValue);
			}
			return currentValue;
		}
	}
}
