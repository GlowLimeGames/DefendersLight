/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public class MapBounds : DLData {
	int minX, maxX;
	int minY, maxY;

	public IntVector2 Min {
		get {
			return new IntVector2(minX, minY);
		}
	}
	public IntVector2 Max {
		get {
			return new IntVector2(maxX, maxY);
		}
	}
	public IntVector2 Size {
		get {
			return new IntVector2(maxX - minX, maxY - minY);
		}
	}

	public MapBounds (int x, int y, int width, int height) {
		this.minX = x;
		this.minY = y;
		this.maxX = x + width;
		this.maxY = y + height;
	}
}
