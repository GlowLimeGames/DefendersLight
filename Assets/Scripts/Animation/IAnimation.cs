/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public interface IAnimation {
	bool Looping {get; set;}
	string Name {get;}

	void Play();
	void Pause();
	void Stop();
	void Seek(float time);
}
