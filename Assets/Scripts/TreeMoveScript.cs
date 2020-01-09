using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMoveScript : MonoBehaviour {
	public float speed;
	public bool backwards = true;
	public bool up;
	public bool right;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (backwards)
		transform.Translate(-Vector3.forward * Time.deltaTime *speed);
		else if (up)
		transform.Translate(Vector3.up * Time.deltaTime *speed);
		 else if (right)
		transform.Translate(Vector3.right * Time.deltaTime *speed);

	}

}
