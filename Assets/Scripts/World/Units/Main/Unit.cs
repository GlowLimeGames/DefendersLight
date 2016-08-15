/*
 * Author(s): Isaiah Mann
 * Description: Class that all in game units inherit from
 */
using SimpleJSON;
using UnityEngine;

[System.Serializable]
public class Unit : IUnit {
	#region JSON Keys

	public const string NAME_KEY = "Name";
	public const string TYPE_KEY = "Type";
	public const string HEALTH_KEY = "Health";
	public const string DAMAGE_KEY = "Attack Damage";
	public const string COOLDOWN_KEY = "Attack Cooldown";
	public const string RANGE_KEY = "Range";
	public const string RADIUS_KEY = "Radius";
	public const string DESCRIPTION_KEY = "Description";
	public const string NOTES_KEY = "Notes";

	#endregion

	#region Properties
	protected IWorldController controller;
	string _id;
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
	protected float AttackCooldown;
	public float IAttackCooldown {
		get {
			return this.AttackCooldown;
		}
	}
	protected int AttackRange;
	public int IAttackRange {
		get {
			return this.AttackRange;
		}
	}
	protected int AttackRadius;
	public int IAttackRadius {
		get {
			return this.AttackRadius;
		}
	}
	protected IMapLocation Location;
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
	protected WorldObjectBehaviour objectLink;
	#endregion


	#region Constructors
	public Unit (string type, int health, int damage, float cooldown, int range, int attackRadius, IMapLocation location, string description, IWorldController controller) {
		this.Type = type;
		this.Health = health;
		this.AttackDamage = damage;
		this.AttackCooldown = cooldown;
		this.AttackRange = range;
		this.AttackRadius = attackRadius;
		this.Location = location;
		this.Description = description;
		this.controller = controller;

		this._id = controller.GenerateID(this);
	}
	#endregion

	#region IUnit Interface
	public void Attack(IUnit unit) {

	}

	public void Damage(int damage) {
		this.Health -= damage;
	}

	public void Create() {

	}

	public void Destroy() {

	}
	#endregion

	#region IGameObjectLink Interface

	public void InitializeGameObject(GameObject fromObject) {
		throw new System.NotImplementedException();
	}

	public GameObject ReleaseGameObject() {
		GameObject myGameObject = objectLink.gameObject;
		myGameObject.SetActive(false);
		objectLink = null;
		return myGameObject;
	}

	#endregion

	#region JSON Serialization

	public virtual string SerializeAsJSON() {
		throw new System.NotImplementedException();
	}

	public void SaveAsJSONToPath(string path) {
		throw new System.NotImplementedException();
	}

	public virtual void DeserializeFromJSON(string jsonText) {
		throw new System.NotImplementedException();
	}

	public void DeserializeFromJSONAtPath(string jsonPath) {
		throw new System.NotImplementedException();
	}

	#endregion
}
	