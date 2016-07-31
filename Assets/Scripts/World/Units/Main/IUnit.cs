/*
 * Author: Isaiah Mann
 * Description: Basic unit functionality
 */

public interface IUnit : IWorldObject {
	string Type {get;}
	int Health{get;}
    void Attack(IUnit unit);
    void Damage(int damage);
    void Create();
    void Destroy();
}
