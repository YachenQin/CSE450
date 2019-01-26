using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject Heart1, Heart2, Heart3;
	public GameObject Hearta, Heartb, Heartc;

	private int p1Life;
	private int p2Life;
	private Vector3 p1Origin;
	private Vector3 p2Origin;


	// Use this for initialization
	void Start () {
		p1Life = 3;
		p2Life = 3;
		p1Origin = player1.transform.position;
		p2Origin = player2.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (player1.transform.position.y < 0) {
			player1.transform.position = p1Origin;
			p1Life--;
		}

		if (player2.transform.position.y < 0) {
			player2.transform.position = p2Origin;
			p2Life--;
		}

		switch (p1Life) {
		case 3:
			Heart1.gameObject.SetActive (true);
			Heart2.gameObject.SetActive (true);
			Heart3.gameObject.SetActive (true);
			break;
		case 2:
			Heart1.gameObject.SetActive (true);
			Heart2.gameObject.SetActive (true);
			Heart3.gameObject.SetActive (false);
			break;
		case 1:
			Heart1.gameObject.SetActive (true);
			Heart2.gameObject.SetActive (false);
			Heart3.gameObject.SetActive (false);
			break;
		case 0:
			Heart1.gameObject.SetActive (false);
			Heart2.gameObject.SetActive (false);
			Heart3.gameObject.SetActive (false);
			SceneManager.LoadScene (5);
			break;
		}

		switch (p2Life) {
		case 3:
			Hearta.gameObject.SetActive (true);
			Heartb.gameObject.SetActive (true);
			Heartc.gameObject.SetActive (true);
			break;
		case 2:
			Hearta.gameObject.SetActive (true);
			Heartb.gameObject.SetActive (true);
			Heartc.gameObject.SetActive (false);
			break;
		case 1:
			Hearta.gameObject.SetActive (true);
			Heartb.gameObject.SetActive (false);
			Heartc.gameObject.SetActive (false);
			break;
		case 0:
			Hearta.gameObject.SetActive (false);
			Heartb.gameObject.SetActive (false);
			Heartc.gameObject.SetActive (false);
			SceneManager.LoadScene (6);
			break;
		}
			
	}
}
