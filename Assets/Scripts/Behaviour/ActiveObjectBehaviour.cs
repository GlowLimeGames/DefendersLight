using UnityEngine;
using System.Collections;

public abstract class ActiveObjectBehaviour : WorldObjectBehaviour {
	[SerializeField]
	GenericStats _stats;


    public abstract void Attack();

    public abstract void Damage();
    
    public abstract void Heal();
    
    public abstract void Destroy();


	public GenericStats GetStats () {
		return _stats;
	}
}
