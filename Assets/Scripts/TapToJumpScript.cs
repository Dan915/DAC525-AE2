using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToJumpScript : MonoBehaviour {
	public float jumpStrength;
	public float speed;
	public float rayLength;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Debug.DrawLine(transform.position, transform.position + new Vector3(0, -rayLength, 0), Color.blue);

		if (Input.touchCount > 0)
			{
				if(Input.GetTouch(0).phase == TouchPhase.Began)
				if(Physics2D.Linecast(transform.position,
       			 transform.position + new Vector3(0,-rayLength,0),
       			 1 << LayerMask.NameToLayer("Ground")))
					gameObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(0, jumpStrength));
			}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1);
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
	}

}
