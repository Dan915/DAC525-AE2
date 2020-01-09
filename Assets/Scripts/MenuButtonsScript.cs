using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsScript : MonoBehaviour {
	// Use this for initialization
	public void Play()
	{
		SceneManager.LoadScene("Load Scene");
	}
}
