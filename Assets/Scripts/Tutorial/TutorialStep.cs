/*
 * Author(s): Isaiah Mann
 * Description: A single step in a tutorial, can be serialized to and from JSOn
 */

using UnityEngine;

[System.Serializable]
public class TutorialStep {
	public string Title;
	public string Body;
	public string Image;
	[System.NonSerialized]
	public Sprite Sprite;
}
