/*
 * Author(s): Isaiah Mann
 * Description: Template actions for a class that can be initialized from JSON
 */

public interface IJSONDeserializable {
	void DeserializeFromJSON(string jsonText);
	void DeserializeFromJSONAtPath(string jsonPath);
}
