using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	//Array storing the different music for each level
	public AudioClip[] levelMusicArray;

	private AudioSource m_audioSource;
	//-----------------------------------------------------------------------------------------------------
	void Awake () 
	{
		DontDestroyOnLoad(this.gameObject);
	}
	//-----------------------------------------------------------------------------------------------------
	void Start () 
	{
		m_audioSource = GetComponent<AudioSource>();
		if(!m_audioSource)
		{
			Debug.LogWarning("Warning, no audio source attached tpo music manager");
		}
	}
	//-----------------------------------------------------------------------------------------------------
	// Call it every time a level it's loaded
	void OnLevelWasLoaded (int level) 
	{
			//Update music and level
			AudioClip newMusic = levelMusicArray[level];
			if(newMusic)
			{
				m_audioSource.Stop();
				m_audioSource.clip = newMusic;
				m_audioSource.Play();
			}
	}
}
