using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {

	int speed;
	public int rand;
	bool rotateRight = false;
	// Use this for initialization
	void Start () {
		speed = Random.Range(8,20);
		rand = Random.Range(0,20);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (rand > 10)
		rotateRight = true;
		else
		rotateRight = false;

		if (!rotateRight)
		 transform.Rotate(Vector3.forward * Time.deltaTime * speed);	
		else 
		 transform.Rotate(-Vector3.forward * Time.deltaTime * speed);	

	}
}
