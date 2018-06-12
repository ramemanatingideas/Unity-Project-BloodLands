using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject youWon;
	public GameObject GameOver;
	public Text LivesText;
	public GameObject deathParticles;


	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;

	public static GM instance = null;
	private GameObject clonepaddle;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy (gameObject);
		}

		Setup();
	}

	public void Setup()
	{
		LivesText.text = "Lives:" + lives;
		clonepaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (bricksPrefab, transform.position, Quaternion.identity);
		
	}

	void CheckGameOver()
	{
		if (bricks < 1) {
			youWon.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Restart", resetDelay);
		}
		else if (lives < 1) {
			GameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Restart", resetDelay);
		}

	}

	void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("level1");
	}

	public void LoseLife()
	{
		lives--;
		LivesText.text = "Lives:" + lives;
		Instantiate (deathParticles, clonepaddle.transform.position, Quaternion.identity);
		Destroy (clonepaddle);
		Invoke("SetupPaddle",resetDelay);
		CheckGameOver ();

	}

	void SetupPaddle()
	{
		clonepaddle = Instantiate (paddle,transform.position, Quaternion.identity)as GameObject;
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver ();
	}

}
