/*
 * Author(s): Isaiah Mann
 * Description: Used to store list of units
 */

[System.Serializable]
public class UnitCollection<UnitType> where UnitType:Unit {
	public UnitType[] Units;
}
