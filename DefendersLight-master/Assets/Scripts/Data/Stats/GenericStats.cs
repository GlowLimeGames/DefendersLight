/*
 * Author: Isaiah Mann
 * Decsription: A generic class to hold world object stats
 */
using UnityEngine;

public class GenericStats : ScriptableObject {
	public string Name;
	public int Level;
	public string LevelString {
		get {
			return GameText.LEVEL + Level;
		}
	}
	public int Range;
	public int Damage;
	public int Health;
	public int MaxHealth;
	public float AttackDelay;

	// Restores stats to default
	public void ResetStats () {
		Health = MaxHealth;
	}
}