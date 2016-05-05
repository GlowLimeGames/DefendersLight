using UnityEngine;
using System.Collections;

public abstract class ActiveObjectBehaviour : WorldObjectBehaviour {

    public abstract void Attack();

    public abstract void Damage();
    
    public abstract void Heal();
    
    public abstract void Destroy();
}
