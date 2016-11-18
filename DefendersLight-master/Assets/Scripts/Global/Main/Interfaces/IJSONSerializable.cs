/*
 * Author(s): Isaiah Mann
 * Description: Behaviour for classes that can be saved as JSON
 */

public interface IJSONSerializable {
	string SerializeAsJSON();
	void SaveAsJSONToPath(string path);
}
