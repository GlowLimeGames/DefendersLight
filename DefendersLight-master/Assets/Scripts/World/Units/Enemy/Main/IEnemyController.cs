/*
 * Author: Isaiah Mann
 * Description: Basic enemy overwatch
 */

﻿public interface IEnemyController : IUnitController<Enemy> {
     IEnemyWave GetWave(int waveNumber);
}
