using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScene_menu : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public void BacktoMain(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex -1);
	}

	public void GameOver()
	{
		SceneManager.LoadScene (2);
	}

	public void Restart()
	{
		SceneManager.LoadScene (1);
	}

	public void PauseGame()
	{
		SceneManager.LoadScene (4);
	}
		
}
