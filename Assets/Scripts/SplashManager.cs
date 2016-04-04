using UnityEngine;
using System.Collections;

public class SplashManager : MonoBehaviour {

	public AudioClip splashSound;
	private LevelManager m_levelManager;

	//-----------------------------------------------------------------------------------------------------
	// Use this for initialization
	void Start () {

		AudioSource.PlayClipAtPoint(splashSound, this.transform.position, 0.5f);
		m_levelManager = GameObject.FindObjectOfType<LevelManager>();
		Invoke ("LoadFirstLevel", splashSound.length );
	}

	//-----------------------------------------------------------------------------------------------------
	// Update is called once per frame
	void Update () {
		
	}
	//-----------------------------------------------------------------------------------------------------
	// Load next level
	void LoadFirstLevel()
	{
		m_levelManager.LoadNextLevel();
	}
}
