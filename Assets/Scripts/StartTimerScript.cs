using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimerScript : MonoBehaviour {
	public GameObject Timer;

	void Start () 
	{
		StartCoroutine(Wait());
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2);
		Timer.SetActive(true);
	}

}
