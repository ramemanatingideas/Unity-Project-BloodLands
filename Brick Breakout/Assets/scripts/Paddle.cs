using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	private float paddleSpeed = 1f;
	private float xpos;
	private Vector3 playerPos = new Vector3 (1, -6.42f, 1.5f);


	// Update is called once per frame
	void Update () {
		xpos = transform.position.x + Input.GetAxis ("Horizontal") * paddleSpeed;
		playerPos = new Vector3 (Mathf.Clamp (xpos, -4.5f, 8f), -6.42f, 1.5f);
		transform.position = playerPos;
	}
}
