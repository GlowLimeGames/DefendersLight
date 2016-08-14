/*
 * Author: Isaiah Mann
 * Description: Basic unit controller
 */
using System.Collections.Generic;

public interface IUnitController<UnitType> : IController where UnitType : IUnit {
	UnitType[] ActiveUnits{get;} 
	List<ActiveObjectBehaviour> Units{get;}

	void Setup(IWorldController controller, IDataController dataController, string templateResourcesPath);
	void Create(UnitType unit);
	void Destroy(UnitType unit);
	void CreateUnitTemplates(string jsonText);
}
