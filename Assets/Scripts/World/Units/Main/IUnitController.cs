/*
 * Author: Isaiah Mann
 * Description: Basic unit controller
 */

public interface IUnitController : IController {
	IUnit[] ActiveUnits{get;} 

	void Create(IUnit unit);
    void Destroy(IUnit unit);
}
