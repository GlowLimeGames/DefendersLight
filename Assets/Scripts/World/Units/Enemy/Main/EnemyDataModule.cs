/*
 * Author(s): Isaiah Mann
 * Description: Data modules related to enemies
 */

using System.Collections.Generic;

public abstract class EnemyDataModule : DLDataModule {}

public abstract class EnemySorter : EnemyDataModule, IComparer<Enemy> {
	public abstract int Compare(Enemy enemy1, Enemy enemy2);	
}

public class EnemySpawnLevelSorter : EnemySorter {
	public override int Compare(Enemy enemy1, Enemy enemy2) {
		return enemy1.WaveSpawnedAt.CompareTo(enemy2.WaveSpawnedAt);
	}
}