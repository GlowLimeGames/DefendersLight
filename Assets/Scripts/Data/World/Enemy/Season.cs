/*
 * Author(s): Isaiah Mann
 * Description: Describes the current season of the game
 */

[System.Serializable]
public class Season {
	const int INVALID_WAVE = -1;
	public string Name;
	public int Index;
	public int StartingWave;
	public int MiddleWave;
	public int EndingWave;
	public bool HasEndingWave {
		get {
			return EndingWave != INVALID_WAVE;
		}
	}
}
