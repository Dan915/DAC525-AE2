using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll_A_BallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(Input.acceleration.x,Input.acceleration.y,0,Space.World);
	}
}
