using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerMoveHorizontalScript : MonoBehaviour {

	public int multipler;

	void Update () 
	{
		transform.Translate(Input.acceleration.x * multipler,0 ,0);
	}
}
