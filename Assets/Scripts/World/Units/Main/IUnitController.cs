/*
 * Author: Isaiah Mann
 * Description: Basic unit controller
 */
using System.Collections.Generic;

public interface IUnitController<UnitType> : IController where UnitType : IUnit {
	UnitType[] ActiveUnits{get;} 
	void Create(UnitType unit);
	void Destroy(UnitType unit);
}
