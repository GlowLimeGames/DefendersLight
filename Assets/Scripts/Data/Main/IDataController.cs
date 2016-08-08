/*
 * Author(s): Isaiah Mann
 * Description: Describes the public functioanlity of the DataController system
 */

﻿public interface IDataController : IController {
	void Save(IData data);
	void SaveSesion (ISessionData session);
	void SaveJSON(string fileName, string jsonText);
	string RetrieveJSON(string fileName);
	IData Load();
}
