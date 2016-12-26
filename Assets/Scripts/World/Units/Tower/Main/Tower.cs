/*
 * Author(s): Isaiah Mann
 * Description: Describes the base behaviour of a tower
 */

using System.Collections.Generic;

[System.Serializable]
public class Tower : Unit {
	const string ILLUMINATION = "Illumination";
	const string ASSAULT = "Assault";
	const string BARRICADE = "Barricade";
	public const string CORE_ORB = "Core Orb";
	static Dictionary<string, UnityEngine.Sprite> towerSprites = new Dictionary<string, UnityEngine.Sprite>();
	public Tower (string type, int health, MapLocation location, string description, int cost, int unlockLevel,
		IWorldController worldController, ITowerController towerController,
		int damage = 0, float cooldown = 0, int range = 0, string illuminationRadius = "0") : 
	base(type, health, damage, cooldown, range, location, description, worldController) {
		this.Cost = cost;
		this.UnlockLevel = unlockLevel;
		this.IlluminationRadius = illuminationRadius;
		this.towerController = towerController;
	}

	public Tower (string jsonText):base(jsonText){}

	public Tower (Tower fromClone):base(fromClone){}

	public TowerType TowerType {
		get {
			switch (Class) {
			case ILLUMINATION:
				return TowerType.Illumination;
			case ASSAULT:
				return TowerType.Assault;
			case BARRICADE:
				return TowerType.Barricade;
			default:
				return default(TowerType);	
			}
		}
	}

	#region JSON Keys

	public const string ILLUMINATION_KEY = "Ilumination Range";
	public const string REFLECTIVITIY_KEY = "Reflectivitiy";
	public const string VARIABLE_KEY = "Variable";

	#endregion

	protected const int ATTACK_STAT_DEFAULT = 0;

	protected ITowerController towerController;
	public int Cost;
	public int ICost {
		get {
			return this.Cost;
		}
	}
	public int UnlockLevel;
	public int IUnlockLevel {
		get {
			return this.UnlockLevel;
		}
	}
	public string IlluminationRadius;
	public bool IlluminationRadiusIsVariable {
		get {
			return IlluminationRadius == VARIABLE_KEY;
		}
	}
	public int IIlluminationRadius {
		get {
			if (IlluminationRadiusIsVariable) {
				return INVALID_VALUE;
			} else {
				return int.Parse(IlluminationRadius);
			}
		}
	}
	public bool HasIllumination {
		get {
			return IIlluminationRadius > NONE_VALUE || IsReflective;
		}
	}

	public string AlmanacFlavorText;
	public string IAlmanacFlavorText {
		get {
			return AlmanacFlavorText;
		}
	}

	public string AlmanacStatDescriptions;
	public string IAlmanacStatDescriptions {
		get {
			return AlmanacStatDescriptions;
		}
	}

	public float Reflectivitiy;
	public float IReflectivitiy {
		get {
			return Reflectivitiy;
		}
	}
	public bool IsReflective {
		get {
			return IReflectivitiy > NONE_VALUE;
		}
	}

	// Whether or not the tower should rotate when firing at enemies
	public bool RotateToTarget;
	public bool IRotateToTarget {
		get {
			return RotateToTarget;
		}
	}

	public override void Copy (Unit unit) {
		base.Copy(unit);
		try {
			Tower towerData = (Tower) unit;
			this.Cost = towerData.Cost;
			this.UnlockLevel = towerData.UnlockLevel;
			this.IlluminationRadius = towerData.IlluminationRadius;
			this.Reflectivitiy = towerData.Reflectivitiy;
			this.AlmanacFlavorText = towerData.AlmanacFlavorText;
			this.AlmanacStatDescriptions = towerData.IAlmanacStatDescriptions;
			this.RotateToTarget = towerData.RotateToTarget;
		} catch {
			UnityEngine.Debug.LogWarningFormat("Unable to fully copy unit. Is not of type {0}", this.GetType());
		}
	}

	public override void DeserializeFromJSON(string jsonText) {
		Tower towerData = UnityEngine.JsonUtility.FromJson<Tower>(jsonText);
		Copy(towerData);
	}

	public override void DeserializeFromJSONAtPath(string jsonPath) {

	}

	public override UnityEngine.Sprite GetSprite () {
		UnityEngine.Sprite sprite;
		if (towerSprites.TryGetValue(Type, out sprite)) {
			return sprite;
		} else if (WorldController.Instance){ 
			sprite = WorldController.Instance.GetTowerSprite(Type);
			towerSprites.Add(Type, sprite);
			return sprite;
		} else {
			return null;
		}
	}

	public bool Unlocked (PlayerData player) {
		return player.ILevel >= UnlockLevel;
	}

	public override string GetDescription () {
		return string.Format("{0}\n\n{1}", AlmanacFlavorText, AlmanacStatDescriptions);
	}
}