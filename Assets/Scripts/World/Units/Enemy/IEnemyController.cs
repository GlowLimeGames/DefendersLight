/*
 * Author: Isaiah Mann
 * Description: Basic enemy overwatch
 */

﻿public interface IEnemyController : IUnitController {
     IEnemyWave GetWave(int waveNumber);
}
