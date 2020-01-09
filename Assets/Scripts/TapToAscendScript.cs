using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToAscendScript : MonoBehaviour {

	public float jumpStrength;

	void Start()
	{
		StartCoroutine(Wait());
	}
	void Update ()
	{
			if (Input.touchCount > 0)
			{
				gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpStrength));
			}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2);
		gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

	}
}
