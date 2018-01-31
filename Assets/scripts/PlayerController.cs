using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody body;
	public float thrust;
	private float count;
	public Text countText;
	public Text winText;
	public float maxPickups;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		count = 0;
		winText.text = "";
		UpdateCount ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHor = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHor, 0.0f, moveV);
		body.AddForce (movement * thrust);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("I hit something");
		if (other.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count++;
			UpdateCount ();
		}
	}

	private void UpdateCount() {
		countText.text = "Count: " + count.ToString ();
		if (count >= maxPickups) {
			winText.text = "You Won!!!";
		}
	}
}
