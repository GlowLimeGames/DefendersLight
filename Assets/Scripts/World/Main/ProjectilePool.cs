/*
 * Author(s): Isaiah Mann
 * Description: Used as a spawn pool for missiles, intended as a temporary implementation
 */

public class ProjectilePool : MannBehaviour {
	public static ProjectilePool Instance;
	System.Collections.Generic.Stack<ProjectileBehaviour> pool = new System.Collections.Generic.Stack<ProjectileBehaviour>();
	protected override void SetReferences () {
		SingletonUtil.TryInit(ref Instance, this, gameObject);
	}
	public bool IsEmpty {
		get {
			return pool.Count == 0;
		}
	}

	public ProjectileBehaviour Take () {
		if (IsEmpty) {
			return null;
		} else {
			ProjectileBehaviour projectileBehaviour = pool.Pop();
			projectileBehaviour.gameObject.SetActive(true);
			return projectileBehaviour;
		}
	}

	public void Give (ProjectileBehaviour unusedProjectile) {
		pool.Push(unusedProjectile);
		unusedProjectile.gameObject.SetActive(false);
		unusedProjectile.transform.SetParent(transform);
	}

	protected override void FetchReferences () {
		
	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent (string eventName) {

	}
}