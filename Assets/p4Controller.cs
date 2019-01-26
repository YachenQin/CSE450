using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p4Controller : MonoBehaviour {

	Rigidbody rb;
	public float turnSpeed = 200.0f;
	public float moveSpeed = 1.5f;
	public float maxSpeed = 6f;
	public float defaultSpeed = 1.5f;
	public float explosiveForce = 150f;
	public GameObject spawnSpot;
	public GameObject chip;

	private float paperFraction;
	private bool moving;
	private Vector3 speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		moving = false;
		paperFraction = defaultSpeed / 2;
	}

	// Update is called once per frame
	void Update () {
		if (!moving) {
			float turn = turnSpeed * Time.deltaTime;
			Quaternion turnRotation = Quaternion.Euler (0.0f, turn, 0.0f);
			rb.MoveRotation (rb.rotation * turnRotation);
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			moving = true;
			speed = moveSpeed * transform.forward;
			rb.AddForce (speed * Time.deltaTime);

		} else if (Input.GetKey (KeyCode.LeftShift)) {
			rb.velocity = moveSpeed * transform.forward;
		} else if (Input.GetKeyUp (KeyCode.LeftShift)) {
			rb.AddForce (speed * 50);
			moving = false;
			//				Debug.Log (rb.velocity);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("highFraction")){
			moveSpeed = paperFraction;
		}

		if (other.CompareTag ("powerUp")) {
			Destroy (other.gameObject);
			StartCoroutine (powerUp ());
		}

		if (other.CompareTag ("lowFraction")) {
			moveSpeed *= 1.6f;
		}
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
		transform.localScale = transform.localScale * 3f;
		explosiveForce /= 3f;
		yield return new WaitForSeconds (5);
		transform.localScale /= 3f;
		explosiveForce *= 3f;
		spawnChip ();
	}

	Vector3 generatePosition(){
		float randomX = Random.Range (-3.027f, -1.31f);
		float randomZ = Random.Range (4.551f, 6.633f);
		return new Vector3(randomX, 2.00f, randomZ);
	}

	void spawnChip(){
		spawnSpot.transform.position = generatePosition ();
		Instantiate (chip, spawnSpot.transform);
	}
}
