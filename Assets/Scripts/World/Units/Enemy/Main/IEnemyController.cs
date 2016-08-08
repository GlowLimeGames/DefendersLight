/*
 * Author: Isaiah Mann
 * Description: Basic enemy overwatch
 */

﻿public interface IEnemyController : IUnitController<IEnemy> {
     IEnemyWave GetWave(int waveNumber);
}
