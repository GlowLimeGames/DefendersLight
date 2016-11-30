/*
 * Author(s): Isaiah Mann
 * Description: Class that all in game units inherit from
 */

using UnityEngine;

[System.Serializable]
public abstract class Unit : IUnit {
	protected const string NULL_STRING = "null";
	protected const int INVALID_VALUE = -1;
	protected const int NONE_VALUE = 0;

	const string MELEE_ATTACK = "Melee";
	const string PROJECTILE_ATTACK = "Projectile";
	const string ENERGY_ATTACK = "Energy";

	#region Properties

	protected IWorldController controller;
	protected string _id;
	public string ID {
		get {
			return this._id;
		}
	}
	bool _isActive;
	public bool IsActive {
		get {
			return this._isActive;
		}
		set {
			this._isActive = value;
		}
	}
	public string Class;
	public string Type;
	public string IType {
		get {
			return Type;
		}
	}
	public int Health;
	public int IHealth {
		get {
			return Health;
		}
	}
	public int AttackDamage;
	public int IAttackDamage {
		get {
			return this.AttackDamage;
		}
	}
	public float AttackCooldown;
	public float IAttackCooldown {
		get {
			return this.AttackCooldown;
		}
	}
	public int AttackRange;
	public int IAttackRange {
		get {
			return this.AttackRange;
		}
	}
	public MapLocation Location = MapLocation.Default;
	public IMapLocation ILocation {
		get {
			return Location;
		}
	}
	public string Description;
	public string IDescription {
		get {
			return this.Description;
		}
	}
	public string Ammo;
	public string IAmmo {
		get {
			if (Ammo == NULL_STRING || string.IsNullOrEmpty(Ammo)) {
				return null;
			} else {
				return Ammo;
			}
		}
	}
	public int SplashDamageRadius;
	public int ISplashDamageRadius {
		get {
			return SplashDamageRadius;
		}
	}
	public bool PassThroughDamage;
	public bool IPassThroughDamage {
		get {
			return PassThroughDamage;
		}
	}
	public string Attack;
	public AttackType IAttackType {
		get {
			switch (Attack) {
			case PROJECTILE_ATTACK:
				return AttackType.Projectile;
			case MELEE_ATTACK:
				return AttackType.Melee;
			case ENERGY_ATTACK:
				return AttackType.Energy;
			default:
				return AttackType.None;
			}
		}
	}

	protected ActiveObjectBehaviour objectLink;

	#endregion

	#region Constructors

	public Unit (string type, int health, int damage, float cooldown, int range, MapLocation location, string description, IWorldController controller) {
		this.Type = type;
		this.Health = health;
		this.AttackDamage = damage;
		this.AttackCooldown = cooldown;
		this.AttackRange = range;
		if (this.Location != null) {
			this.Location = location;
		}
		this.Description = description;
		this.controller = controller;
		if (controller != null) {
			this._id = controller.GenerateID(this);
		}
	}
		
	public Unit (string jsonText) {
		DeserializeFromJSON(jsonText);
	}

	protected void SetupLink (GameObject instance) {
		WorldController.AttachBehaviourScript(this.GetType(), instance);
		SendLink();
	}

	protected void SendLink () {
		objectLink.ReceiveLink(this);
	}

	protected void SeverLink () {
		objectLink.SeverLink();
	}

	#endregion

	#region IGameObjectLink Interface

	public void InitializeGameObject(GameObject fromObject) {
		SetupLink(fromObject);
	}

	public GameObject ReleaseGameObject() {
		GameObject myGameObject = objectLink.gameObject;
		myGameObject.SetActive(false);
		objectLink.SeverLink();
		objectLink = null;
		return myGameObject;
	}
		
	#endregion

	#region JSON Serialization

	public virtual string SerializeAsJSON() {
		return JsonUtility.ToJson(this);
	}

	public void SaveAsJSONToPath(string path) {
		FileUtil.AppendStringToPath(SerializeAsJSON(), path);
	}

	public abstract void DeserializeFromJSON(string jsonText);
	public abstract void DeserializeFromJSONAtPath(string jsonPath);

	#endregion

	public abstract Sprite GetSprite ();
		
	public virtual void Copy (Unit unit) {
		this.Class = unit.Class;
		this.Type = unit.Type;
		this.Health = unit.Health;
		this.AttackDamage = unit.AttackDamage;
		this.AttackCooldown = unit.AttackCooldown;
		this.AttackRange = unit.AttackRange;
		this.Location = unit.Location;
		this.Description = unit.Description;
		this.controller = unit.controller;
		this._id = unit._id;
		this.Ammo = unit.IAmmo;
	}

	public abstract string GetDescription();
}
	