/*
 * Author(s): Isaiah Mann
 * Description: Describes the base behaviour of a tower
 */

public class Tower : Unit {
	protected const int ATTACK_STAT_DEFAULT = 0;

	ITowerController towerController;
	int _cost;
	public int Cost {
		get {
			return this._cost;
		}
	}
	int _unlockLevel;
	public int UnlockLevel {
		get {
			return this._unlockLevel;
		}
	}
	int _illuminationRadius;
	public int Illumination {
		get {
			return this._illuminationRadius;
		}
	}

	public Tower (string type, int health, IMapLocation location, string description, int cost, int unlockLevel,
		IWorldController worldController, ITowerController towerController,
		int damage = 0, float cooldown = 0, int range = 0, int attackRadius = 0, int illuminationRadius = 0) : 
	base(type, health, damage, cooldown, range, attackRadius, location, description, worldController) {
		this._cost = cost;
		this._unlockLevel = unlockLevel;
		this._illuminationRadius = illuminationRadius;
		this.towerController = towerController;
	}
}
