/*
 * Author(s): Isaiah Mann
 * Description: Describes the public functioanlity of the DataController system
 */

﻿public interface IDataController : IController {
	void Save(IData data);
	void SaveSesion (ISessionData session);
	void SaveJSON(string fileName, string jsonText);
	string RetrieveJSON(string fileName);
	// Resources is a special folder within the Unity Assets directory that you can load in files easily from at Runtime
	string RetrieveJSONFromResources(string filePathInResources);
	IData Load();


}
