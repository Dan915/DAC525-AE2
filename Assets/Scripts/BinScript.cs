﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour {

	public int destroyedObj;

	void OnTriggerEnter2D(Collider2D other)	
	{
		if (other.gameObject.tag == "Selected")
		Destroy(other.gameObject);
		destroyedObj++;
	}
}
