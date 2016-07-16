using System.Collections.Generic;

public interface IEnemyWave {
	int GetUnitCount();
	IEnemy[] GetUnits();
	Dictionary<Direction, IEnemy[]> GetEnemiesByAttackDirection();
}
