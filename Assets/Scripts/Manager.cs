using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public static bool autoPlay = false;

	private static Manager m_mpInstance = null;
	private static int m_lastLevel = 1;
	private static int m_inputEntry = 0;
	private static float m_points = 0;

	//-----------------------------------------------------------------------------------------------------
	// Use this for initialization
	void Awake()
	{
		//Singleton Pattern, if the sysem creates an object that has been created (it's static), destroy the current instance
		if( m_mpInstance != null)
		{
			Destroy (gameObject);
		}
		else
		{
			m_mpInstance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	//-----------------------------------------------------------------------------------------------------
	void Start()
	{
	}
	//-----------------------------------------------------------------------------------------------------
	void onDestroy()
	{
	}
	//-----------------------------------------------------------------------------------------------------
	void Update()
	{
		//If R it's pressed, reload the level
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
		else if(Input.GetKeyDown(KeyCode.T))
		{
			//if T it's pressed, the game will autoplay
			autoPlay = !autoPlay;
		}
		else if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	
	//-----------------------------------------------------------------------------------------------------
	public int getLastLevel()
	{
		return m_lastLevel;
	}
	//-----------------------------------------------------------------------------------------------------
	//Saves last level
	public void setLastLevel(int level)
	{
		m_lastLevel = level;
	}
	//-----------------------------------------------------------------------------------------------------
	public int getInputEntry()
	{
		return m_inputEntry;
	}
	//-----------------------------------------------------------------------------------------------------
	public void setInputEntry(int input)
	{
		m_inputEntry = input;
	}
	//-----------------------------------------------------------------------------------------------------
	//Handles the score
	public void addPointsToScore(float newPoints)
	{
		m_points += newPoints;

		Text[] txt = GameObject.FindObjectsOfType<Text>() as Text[];
		foreach( Text t in txt)
		{
			if(t.gameObject.name == "ScoreText")
			{
				t.text = getScore().ToString() + " Km";
			}
		}
	}
	//-----------------------------------------------------------------------------------------------------
	//Resets the Score
	public void resetScore()
	{
		m_points = 0;
	}
	//-----------------------------------------------------------------------------------------------------
	public int getScore()
	{
		return (int)m_points;
	}
	//-----------------------------------------------------------------------------------------------------
	//Update the GUI text
	public void UpdateGUI(string text)
	{
	}
	//-----------------------------------------------------------------------------------------------------
	//Clear the GUI text
	public void ClearGUI()
	{
	}
}
