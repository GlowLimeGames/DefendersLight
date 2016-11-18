/*
 * Author(s): Isaiah Mann
 * Description: Describes an enemy wave
 */

using System.Collections.Generic;

public class EnemyWave : IEnemyWave {

	#region Properties 

	public int WaveIndex {
		get; private set;
	}
	public int TotalEnemyCount{
		get {
			throw new System.NotImplementedException();
		}
	}
	public int RemainingEnemyCount{
		get {
			throw new System.NotImplementedException();
		}
	}
	public IEnemy[] AllUnits {
		get {
			throw new System.NotImplementedException();
		}
	}

	public IEnemy[] RemainingUnits{ 
		get {
			throw new System.NotImplementedException();
		}
	}

	#endregion

	#region Constructors 

	public EnemyWave (int waveIndex) {
		this.WaveIndex = waveIndex;
	}

	#endregion

	public Dictionary<Direction, IEnemy[]> GetEnemiesByAttackDirection() {
		throw new System.NotImplementedException();
	}
}
