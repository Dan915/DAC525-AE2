using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerMovementScript : MonoBehaviour {

public float multiplier;
bool canMove = false;

	void Start ()
	{
		StartCoroutine(Wait());
	}	
	void Update () 
	{
		if (canMove)
		transform.Translate(Input.acceleration.x * multiplier, Input.acceleration.y * multiplier,0);
		Debug.Log(Input.acceleration.y);
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2);
		canMove = true;
	}
}
