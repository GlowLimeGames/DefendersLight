/*
 * Author: Isaiah Mann 
 * Description: Wrapper class to extend the default behaviour of MonoBehaviours
 */

using UnityEngine;

public abstract class MannBehaviour : MonoBehaviour, System.IComparable {
	public delegate void EventAction();
	void Awake () {
		SetReferences();
		SubscribeEvents();
	}

	void Start () {
		FetchReferences();
	}

	void OnDestroy () {
		CleanupReferences();
		UnusbscribeEvents();
		StopAllCoroutines();
	}

    // Value should only be null if you're setting a trigger
    public bool QueryAnimator (AnimParam param, string key, object value = null) {
        Animator animator = GetComponent<Animator>();
        if (animator == null) {
            return false;
        } else {
            try {
                switch (param) {
                    case AnimParam.Bool:
                        animator.SetBool(key, (bool)value);
                        return true;
                    case AnimParam.Float:
                        animator.SetFloat(key, (float)value);
                        return true;
                    case AnimParam.Int:
                        animator.SetInteger(key, (int)value);
                        return true;
                    case AnimParam.Trigger:
                        animator.SetTrigger(key);
                        return true;
                    default:
                        return false;
                }
            } catch {
                return false;
            }
        }
    }

    public bool QuerySpriteRenderer (Sprite sprite) {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer == null) {
            return false;
        } else {
            renderer.sprite = sprite;
            return true;
        }
    }

	protected virtual void SubscribeEvents () {
		EventController.OnNamedEvent += HandleNamedEvent;
	}

	protected virtual void UnusbscribeEvents () {
		EventController.OnNamedEvent -= HandleNamedEvent;
	}

	protected abstract void SetReferences ();

	protected abstract void FetchReferences ();

	protected abstract void CleanupReferences ();

	protected abstract void HandleNamedEvent (string eventName);

	public int CompareTo (object other) {
		if (other is MannBehaviour) {
			return this == (other as MannBehaviour) ? 0 : -1;
		} else {
			return -1;
		}
	}
}