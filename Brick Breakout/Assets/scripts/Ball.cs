using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody rb;
	public float ball_Initial_Speed = 600f;
	public bool ballInPlay;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && ballInPlay == false) {
			ballInPlay = true;
			transform.parent = null;
			rb.isKinematic = false;
			rb.AddForce (new Vector3 (ball_Initial_Speed, ball_Initial_Speed, 0));
		}
	}
}
