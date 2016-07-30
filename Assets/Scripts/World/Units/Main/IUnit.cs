/*
 * Author: Isaiah Mann
 * Description: Basic unit functionality
 */

public interface IUnit {
     int GetHealth();
     void Attack(IUnit unit);
     void Damage(int damage);
     void Create();
     void Destroy();
}
