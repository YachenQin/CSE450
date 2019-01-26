using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;		//import the scnen management

public class MainMenu : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public void  PlayGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void StartGame()
	{
		SceneManager.LoadScene (1);
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void ModeOne()
	{
		SceneManager.LoadScene (2);
	}

	public void ModeTwo()
	{
		SceneManager.LoadScene (3);
	}

	public void ModeThree()
	{
		SceneManager.LoadScene (4);
	}
}
