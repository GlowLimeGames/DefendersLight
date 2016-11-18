﻿/*
 * Author(s): Isaiah Mann
 * Description: An animated count up or down for text
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class UIAnimatedCount : UIElement {
	[SerializeField]
	Color defaultTextColor = Color.white;

	IEnumerator countCoroutine;
	Text text;
	string prefix;
	int _currentValue = 0;
	int currentValue {
		set {
			_currentValue = value;
			SetText(value);
		}
		get {
			return _currentValue;
		}
	}
		
	protected override  void SetReferences () {
		base.SetReferences();
		text = GetComponent<Text>();
		UpdateCount();
	}

	void UpdateCount () {
		int count;
		if (int.TryParse(text.text, out count)) {
			_currentValue = count;
		}
	}

	void SetText (int currentValue) {
		text.text = prefix + currentValue.ToString();
	}

	public void SetPrefixText (string prefix) {
		this.prefix = prefix;
	}

	public void StartCount (int targetValue, float time, Color? changeTextColor) {
		StopCountCoroutine();
		if (changeTextColor != null) {
			SetColor((Color)changeTextColor);
		}
		countCoroutine = CountTo(targetValue, time, defaultTextColor);
		StartCoroutine(countCoroutine);
	}

	public void SetColor (Color color) {
		text.color = color;
	}

	void StopCountCoroutine () {
		if (countCoroutine != null) {
			StopCoroutine(countCoroutine);
		}
	}

	IEnumerator CountTo (int targetValue, float time, Color colorOnFinish) {
		UpdateCount();
		float timer = 0;
		float frames = time/Time.fixedDeltaTime;
		int step = Mathf.Clamp((int)(((float)(targetValue-currentValue))/frames), 1, int.MaxValue);
		while (timer < time && currentValue != targetValue) {
			currentValue += step;
			timer += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}
		currentValue = targetValue;
		SetColor(colorOnFinish);
	}
}
