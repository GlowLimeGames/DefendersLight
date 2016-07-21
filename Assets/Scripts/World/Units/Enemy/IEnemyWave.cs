using System.Collections.Generic;

public interface IEnemyWave {
	int GetUnitCount();
	int GetUnitAliveCount();
	IEnemy[] GetUnits();
	Dictionary<Direction, IEnemy[]> GetEnemiesByAttackDirection();
}
