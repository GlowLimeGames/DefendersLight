/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public abstract class IntVector {}

public class IntVector2 : IntVector {
	public int X, Y;

	public IntVector2 (int x, int y) {
		this.X = x;
		this.Y = y;
	}
}