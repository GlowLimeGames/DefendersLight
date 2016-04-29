/*
 * Author: Isaiah Mann 
 * Description: Wrapper class to extend the default behaviour of MonoBehaviours
 */

using UnityEngine;
using System.Collections;

public abstract class MannBehaviour : MonoBehaviour {

	void Awake () {
		SetReferences();
		SubscribeEvents();
	}

	void Start () {
		FetchReferences();
	}

	void OnDestroy () {
		UnusbscribeEvents();
	}

	protected virtual void SubscribeEvents () {
		EventController.OnNamedEvent += HandleNamedEvent;
	}

	protected virtual void UnusbscribeEvents () {
		EventController.OnNamedEvent -= HandleNamedEvent;
	}

	protected abstract void SetReferences ();

	protected abstract void FetchReferences ();

	protected abstract void HandleNamedEvent (string eventName);
}