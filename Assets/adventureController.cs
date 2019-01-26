using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adventureController : MonoBehaviour {

	Rigidbody rb;
	public float turnSpeed = 200.0f;
	public float moveSpeed = 1f;
	public float maxSpeed = 6f;
	public float defaultSpeed = 1f;
	public float explosiveForce = 150f;
	public GameObject hugeCube;
//	public GameObject opponent;
//	public GameObject spawnSpot;
//	public GameObject chip, melon, pepper;

	private int eaten;
	private float paperFraction;
	private bool moving;
	private Vector3 speed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		moving = false;
		paperFraction = defaultSpeed / 2;
		eaten = 0;
	}

	// Update is called once per frame
	void Update () {
	
		if (!moving) {
			float turn = turnSpeed * Time.deltaTime;
			Quaternion turnRotation = Quaternion.Euler (0.0f, turn, 0.0f);
			rb.MoveRotation (rb.rotation * turnRotation);
		}
		if (Input.GetKeyDown ("space")) {
			moving = true;
			speed = moveSpeed * transform.forward;
			rb.AddForce(speed*Time.deltaTime);

		} else if (Input.GetKey ("space")) {
			rb.velocity = moveSpeed * transform.forward;
		}
		else if (Input.GetKeyUp ("space")) {
			rb.AddForce (speed * 50);
			moving = false;
			//				Debug.Log (rb.velocity);
		}

		if (eaten == 3) {
			hugeCube.GetComponent<Rigidbody> ().isKinematic = false;
		} else {
			hugeCube.GetComponent<Rigidbody> ().isKinematic = true;
		}

		if (Input.GetKey (KeyCode.R)) {
//			reload the scene
		}

	}

	void OnTriggerEnter(Collider other){
		//become slower
		if(other.CompareTag("highFraction")){
			moveSpeed = paperFraction;
		}

		//become faster
		if(other.CompareTag("lowFraction")){
			moveSpeed *= 1.6f;
		}

		//become bigger
		if (other.CompareTag ("powerUp")) {
			Destroy (other.gameObject);
			StartCoroutine (powerUp ());
		}

		if (other.CompareTag ("goal")) {
			Destroy (other.gameObject);
		}

//		//change position with opponent
//		if(other.CompareTag ("changep")){
//			Destroy (other.gameObject);
//			Vector3 temp = transform.position;
//			transform.position = opponent.transform.position;
//			opponent.transform.position = temp;
//			spawnSpot.transform.position = generatePosition ();
//			Instantiate (pepper, spawnSpot.transform);
//		}

		//change direction
//		if (other.CompareTag ("changeDir")) {
//			Destroy (other.gameObject);
//			StartCoroutine (changeDir ());
//		}
//
	}

	void OnTriggerExit(Collider other){
		moveSpeed = defaultSpeed; 
	}

	void OnCollisionEnter(Collision other){
		if(other.collider.CompareTag("Player")){
			rb.AddExplosionForce (explosiveForce, other.transform.position, 3f);
		}
	}

	IEnumerator powerUp() {
		transform.localScale = transform.localScale * 1.5f;
		explosiveForce /= 3f;
		eaten += 1;
		yield return new WaitForSeconds (20);
		transform.localScale /= 1.5f;
		explosiveForce *= 3f;
		eaten -= 1;
	}

	//generate a random position within the table
	Vector3 generatePosition(){
		float randomX = Random.Range (-1.427f, -0.081f);
		float randomZ = Random.Range (-0.451f, 0.133f);
		return new Vector3(randomX, 0.82f, randomZ);
	}

	//change the direction for 5s
//	IEnumerator changeDir(){
//		spawnSpot.transform.position = generatePosition ();
//		Instantiate (chip, spawnSpot.transform);
//		moveSpeed *= -1;
//		yield return new WaitForSeconds (5);
//		moveSpeed *= -1;
//	}
}
