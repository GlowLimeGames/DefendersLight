/*
 * Author(s): Isaiah Mann
 * Description: Controls the alamanc screen
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AlmanacUIController : UIController {
	[SerializeField]
	bool loadPreviousSceneOnClose;

	const string DEFAULT_PAGE = "Enemy";
	Dictionary<string, Unit[]> unitsByClass = new Dictionary<string, Unit[]>();
	WorldController world;
	Unit[] currentUnits;
	int currentUnitIndex;
	public void Setup (Dictionary<string, Unit[]> unitsByClass) {
		this.unitsByClass = unitsByClass;
	}

	[SerializeField]
	Text unitClassText;

	[SerializeField]
	UIButton leftButton;

	[SerializeField]
	UIButton rightButton;

	[SerializeField]
	GameObject unitTypesDisplay;

	[SerializeField]
	GameObject singleUnitDisplay;

	[SerializeField]
	GameObject unitSelectButtonParent;
	UILabledButton[] unitSelectButtons;

	[SerializeField]
	GameObject unitClassTabParent;
	UIButton[] unitClassTabs;

	[SerializeField]
	Image unitPortrait;

	[SerializeField]
	Text unitBodyText;

	[SerializeField]
	Text unitTypeText;

	void toggleSingleUnitSelected (bool isSelected) {
		unitTypesDisplay.SetActive(!isSelected);
		singleUnitDisplay.SetActive(isSelected);
	}

	public void LoadUnitClass (string unitClass) {
		this.unitClassText.text = unitClass;
		Unit[] unitsInClass;
		if (unitsByClass.TryGetValue(unitClass, out unitsInClass)) {
			toggleSingleUnitSelected(false);
			for (int i = 0; i < unitSelectButtons.Length; i++) {
				UILabledButton button = unitSelectButtons[i];
				if (i < unitsInClass.Length) {
					int index = i;
					button.Set(unitsInClass[i].IType,
						delegate {
							currentUnitIndex = index;
							DisplayUnit(unitsInClass[index]);
						});
					button.Show();
				} else {
					button.Hide();
				}
			}
			selectProperButton(unitClass);
			currentUnits = unitsInClass;
		}
	}

	public void DisplayUnit (Unit unit) {
		unitTypeText.text = unit.IType;
		unitPortrait.sprite = unit.GetSprite();
		unitBodyText.text = unit.GetDescription();
		toggleSingleUnitSelected(true);
		toggleButtons();
	}

	bool hasUnits () {
		return currentUnits != null;
	}

	public void Next () {
		if (HasNext()) {
			DisplayUnit(currentUnits[++currentUnitIndex]);
		}
	}

	public bool HasNext () {
		return hasUnits() && IntUtil.InRange(currentUnitIndex + 1, currentUnits.Length);
	}

	public void Previous () {
		if (HasPrevious()) {
			DisplayUnit(currentUnits[--currentUnitIndex]);
		}
	}

	public void Close () {
		if (loadPreviousSceneOnClose) {
			LoadPreviousScene();
		} else {
			Hide();
		}
	}

	void toggleButtons () {
		leftButton.ToggleInteractable(HasPrevious());
		rightButton.ToggleInteractable(HasNext());
	}

	public bool HasPrevious () {
		return hasUnits() && IntUtil.InRange(currentUnitIndex - 1, currentUnits.Length);
	}

	void selectProperButton (string selectedClass) {
		foreach (UIButton classTab in unitClassTabs) {
			if (classTab.gameObject.name.Contains(selectedClass)) {
				classTab.Select();
			} else {
				classTab.Deselect();
			}
		}
	}

	#region MannBehaviour Protocol 

	protected override void SetReferences () {
		base.SetReferences ();
		unitSelectButtons = unitSelectButtonParent.GetComponentsInChildren<UILabledButton>();
		unitClassTabs = unitClassTabParent.GetComponentsInChildren<UIButton>();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		world = WorldController.Instance;
		unitsByClass = world.UnitsByClass;
		LoadUnitClass(DEFAULT_PAGE);
	}

	#endregion
}
