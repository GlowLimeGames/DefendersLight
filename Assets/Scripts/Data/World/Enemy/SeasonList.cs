/*
 * Author(s): Isaiah Mann
 * Description: List of seasons
 */

[System.Serializable]
public class SeasonList {
	public Season[] Seasons;

	public Season this[int index] {
		get {
			if (IntUtil.InRange(index, Length)) {
				return Seasons[index];
			} else {
				return null;
			}
		}
	}

	public int Length {
		get {
			return Seasons.Length;
		}
	}
}
