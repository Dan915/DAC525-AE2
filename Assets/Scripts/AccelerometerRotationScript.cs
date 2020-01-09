using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerRotationScript : MonoBehaviour {
 public int multiplier;
 GameObject GameManager;
 int incDifficulty;
 public int windForce = 5;

	void Strt()
	{
		GameManager = GameObject.Find("GameManager");
		incDifficulty = GameManager.GetComponent<GameManagerScript>().difficulty;
		windForce *= incDifficulty;
	}

	void Update () 
	{
		transform.Rotate(0, 0, -Input.acceleration.x * multiplier,Space.World);
		gameObject.GetComponent<Rigidbody2D>().AddTorque(windForce,ForceMode2D.Force);
		StartCoroutine(Wait());
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2);
		gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
	}
}
