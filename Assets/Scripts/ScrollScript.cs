using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour {
	public float speed;
	public bool turnOnMultiplier;
	public float multiplier;
	public int incDifficulty;
	GameObject GameManager;
	bool isOn = false;

	// Use this for initialization
	void Start () 
	{
		GameManager = GameObject.Find("GameManager");
		incDifficulty = GameManager.GetComponent<GameManagerScript>().difficulty;
		speed +=incDifficulty;
		StartCoroutine(Wait());
	}
	
	void Update()
	{
		multiplier += Time.deltaTime;
		if ( isOn)
		{
			if (turnOnMultiplier == true)
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed * multiplier,0);
			else
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (-speed,0);
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2.5f);
		isOn = true;
	}
}
