/*
 * Author(s): Isaiah Mann 
 * Description: Stores information about an audio file
 * Parsed from a JSON file
 * Events are stored as strings that indicate when to start and stop a file
 */

using UnityEngine;
using System.Collections;

[System.Serializable]
public class AudioFile : IAudioFile {
	public delegate void ClipRequestAction (AudioFile file);
	public event ClipRequestAction OnClipRequest;

	AudioClip _clip;
	public AudioClip Clip {
		get {
			if (_clip == null) {
				_clip = AudioLoader.GetClip(FileName);
				CallOnClipRequest();
			}

			return _clip;
		}
	}

	public float ClipLength {
		get {
			return Clip.length;
		}
	}

	public string FileName{get; set;}
	public string[] EventNames{get; set;}
	public string[] StopEventNames{get; set;}
	public bool Loop{get; set;}
	public string Type{get; set;}
	public int Volume{get; set;}

	// Volume for the AudioSource class uses 0-1.0f scale while our class uses 0-100 (integer) scale
	public float Volumef {
		get {
			return GetVolume();
		}
	}

	public AudioType TypeAsEnum {
		get {
			return AudioUtil.AudioTypeFromString(Type);
		}
	}

	public int Channel{get; set;}


	public override string ToString () {
		return string.Format (
			"[AudioFile:\n"+
			"FileName={0}\n" +
			"EventNames={1}\n" +
			"EndEventNames={2}\n" +
			"Loop={3}\n" +
			"Type={4}\n" +
			"Channel={5}" +
			"]", 
			FileName, 
			ArrayUtil.ToString(EventNames),
			ArrayUtil.ToString(StopEventNames),
			Loop, 
			Type, 
			Channel);
	}

	public bool HasEvent (string eventName) {
		return ArrayUtil.Contains (
			EventNames,
			eventName
		);
	}

	public bool HasEndEvent (string eventName) {
		return ArrayUtil.Contains (
			StopEventNames,
			eventName
		);
	}

	void CallOnClipRequest () {
		if (OnClipRequest != null) { 
			OnClipRequest(this);
		}
	}

	float GetVolume (int volume) {
		return (float)volume/100f;
	}

	public float GetVolume () {
		return GetVolume(Volume);
	}

	#region JSON Deserialization
	public void DeserializeFromJSON (string jsonText) {
		throw new System.NotImplementedException();
	}

	public void DeserializeFromJSONAtPath (string jsonPath) {
		throw new System.NotImplementedException();
	}
	#endregion
}