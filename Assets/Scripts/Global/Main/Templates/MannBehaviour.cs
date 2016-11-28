/*
 * Author: Isaiah Mann 
 * Description: Wrapper class to extend the default behaviour of MonoBehaviours
 */

using UnityEngine;

public abstract class MannBehaviour : MonoBehaviour, System.IComparable {
	// Simulates delta time while game is paused
	protected const int INVALID_VALUE = -1;
	protected const int NONE_VALUE = 0;
	protected const float DEFAULT_FRAME_RATE = 30f;
	protected static float FAKE_DELTA_TIME;

	// Static constructor to calculate fake delta time
	static MannBehaviour () {
		if (Application.targetFrameRate == INVALID_VALUE) {
			FAKE_DELTA_TIME = 1f / DEFAULT_FRAME_RATE;
		} else {
			FAKE_DELTA_TIME = 1f / Application.targetFrameRate;
		}
	}


	public delegate void EventAction();
	public delegate void EventActionInt(int integer);
	public delegate void EventActionf(float floatingPointNumber);
	public delegate void EventActionKey(string key);
	public delegate void EventActionFlag(bool flag);
	protected bool referencesSet {get; private set;}

	void Awake () {
		if (!referencesSet) {
			SetReferences();
		}
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

	protected virtual void SetReferences () {
		referencesSet = true;
	}

	protected abstract void FetchReferences ();

	protected virtual void CleanupReferences () {
		StopAllCoroutines();
	}

	protected abstract void HandleNamedEvent (string eventName);

	public int CompareTo (object other) {
		if (other is MannBehaviour) {
			return this == (other as MannBehaviour) ? 0 : -1;
		} else {
			return -1;
		}
	}
		
	public virtual void RefreshReferences () {
		SetReferences();
	}

	protected Vector3 scalarVector (float value) {
		return Vector3.one * value;
	}
}