/*
 * Author(s): Isaiah Mann
 * Description: Controls the tuning stats in the game
 */

using UnityEngine;

public class TuningController : SingletonController<TuningController> {
	const string FILE_NAME = "Tuning";
	DLTuning tuning;

	protected override void FetchReferences () {
		base.FetchReferences ();
		parseJSON();
	}

	void parseJSON () {
		string tuningJSON = data.RetrieveJSONFromResources(FILE_NAME);
		tuning = JsonUtility.FromJson<DLTuning>(tuningJSON);
	}

	public float SellValueFraction {
		get {
			return tuning.SellValues;
		}
	}

	public int XPBonusPerWave {
		get {
			return tuning.XPBonusPerWave;
		}
	}
}