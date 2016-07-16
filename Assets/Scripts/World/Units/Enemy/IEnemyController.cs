public interface IEnemyController {
     void Create(IEnemy unit);
     void Destroy(IEnemy unit);
     IEnemy[] GetAll();
     IEnemyWave GetWave(int waveNumber);
}
