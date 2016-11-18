/*
 * Author: Isaiah Mann
 * Description: A single enemy wave (or level)
 */

using System.Collections.Generic;

public interface IEnemyWave {
	int TotalEnemyCount{get;}
	int RemainingEnemyCount{get;}
	IEnemy[] AllUnits{get;}
	IEnemy[] RemainingUnits{get;}
	Dictionary<Direction, IEnemy[]> GetEnemiesByAttackDirection();
}
