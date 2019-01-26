using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EventManager2v2 : MonoBehaviour {

	public GameObject player1, player2, player3, player4;
	public GameObject p1ScoreGB, p2ScoreGB;
	public GameObject gamingTime;

	private int p1Score;
	private int p2Score;
	private float gameDurating;
	private bool start;


	// Use this for initialization
	void Start () {
		p1Score = 0;
		p2Score = 0;
		gameDurating = 60f;
		start = false;
	}

	// Update is called once per frame
	void Update () {
		//GUI
		if (start) {
			gameDurating -= Time.deltaTime;
		}

		p1ScoreGB.GetComponent<TextMeshProUGUI> ().text = p1Score.ToString();
		p2ScoreGB.GetComponent<TextMeshProUGUI> ().text = p2Score.ToString();
		string minSec = string.Format("{0}:{1:00}", (int)gameDurating / 60, (int)gameDurating % 60); 
		gamingTime.GetComponent<TextMeshProUGUI> ().text = minSec;


		//Game Condition
		if(Input.GetKeyDown("space") || Input.GetKeyDown("return")){
			start = true;	
		}

		if (player1.transform.position.y < 1.5f) {
			player1.transform.position = generatePosition();
			p2Score += 100;
		}
		if (player4.transform.position.y < 1.5f) {
			player4.transform.position = generatePosition();
			p2Score += 100;
		}

		if (player2.transform.position.y < 1.5f) {
			player2.transform.position = generatePosition();
			p1Score += 100;
		}
		if (player3.transform.position.y < 1.5f) {
			player3.transform.position = generatePosition();
			p2Score += 100;
		}

		if (gameDurating < 0) {
			gameDurating = 0f;
			if (p1Score > p2Score) {
				SceneManager.LoadScene (8);
			}

			if (p1Score < p2Score) {
				SceneManager.LoadScene (9);
			}

			if (p2Score == p1Score) {
				SceneManager.LoadScene(7);
			}
		}


	}

	//generate a random position within the table
	Vector3 generatePosition(){
		float randomX = Random.Range (-3.427f, -0.81f);
		float randomZ = Random.Range (4.351f, 6.933f);
		return new Vector3(randomX, 2.00f, randomZ);
	}
}
