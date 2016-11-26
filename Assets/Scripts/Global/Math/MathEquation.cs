/*
 * Author(s): Isaiah Mann
 * Description: 
 */

[System.Serializable]
public class MathEquation {
	public virtual float Calculate (float input) {
		return input;
	}

	// Calculates the full float value, and then casts to int (used for vals that must be whole numbers, e.g. XP to level up)
	public virtual int CalculateAsInt (float input) {
		return (int) Calculate(input);
	}
}
