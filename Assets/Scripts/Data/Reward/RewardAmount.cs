/*
 * Author(s): Isaiah Mann
 * Description: NewStruct is a behaviourless data structure
 */

[System.Serializable]
public struct RewardAmount {
	public int Mana;
	public int XP;

	public RewardAmount(int mana, int xp) {
		this.Mana = mana;
		this.XP = xp;
	}
}
