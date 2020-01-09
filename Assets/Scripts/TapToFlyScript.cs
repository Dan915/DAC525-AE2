using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToFlyScript : MonoBehaviour {
	public float jumpStrength;
	 public GameObject timer;

	void Start()
	{
		StartCoroutine(Wait());
	}
	void Update ()
	{
			if (Input.touchCount == 1)
			{
				Touch touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began)
				{
				gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpStrength));
				}
			}
			if (timer.GetComponent<TimerScript>().currentTime == 0)
			gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2);
		gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

	}

}
