/*
 * Author: Isaiah Mann
 * Description: Basic unit controller
 */

public interface IUnitController : IController {
     void Create(IUnit unit);
     void Destroy(IUnit unit);
     IUnit[] GetActive();
}
