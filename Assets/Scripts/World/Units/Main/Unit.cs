/*
 * Author(s): Isaiah Mann
 * Description: Class that all in game units inherit from
 */
using UnityEngine;

public class Unit : IUnit {
	#region Properties
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
	protected string _type;
	public string Type {
		get {
			return _type;
		}
	}
	protected int _health;
	public int Health {
		get {
			return this._health;
		}
	}
	protected int _attackDamage;
	public int AttackDamage {
		get {
			return this._attackDamage;
		}
	}
	protected float _attackCooldown;
	public float AttackCooldown {
		get {
			return this._attackCooldown;
		}
	}
	protected int _attackRange;
	public int Range {
		get {
			return this._attackRange;
		}
	}
	protected int _attackRadius;
	public int AttackRadius {
		get {
			return this._attackRadius;
		}
	}
	protected IMapLocation _location;
	public IMapLocation Location {
		get {
			return _location;
		}
	}
	string _description;
	public string Description {
		get {
			return this._description;
		}
	}
	protected WorldObjectBehaviour objectLink;
	#endregion


	#region Constructors
	public Unit (string type, int health, int damage, float cooldown, int range, int attackRadius, IMapLocation location, string description) {
		this._type = type;
		this._health = health;
		this._attackDamage = damage;
		this._attackCooldown = cooldown;
		this._attackRange = range;
		this._attackRadius = attackRadius;
		this._location = location;
		this._description = description;

		this._id = WorldController.GenerateID(this);
	}
	#endregion

	#region IUnit Interface
	public void Attack(IUnit unit) {

	}

	public void Damage(int damage) {
		this._health -= damage;
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
}
