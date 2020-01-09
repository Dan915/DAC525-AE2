using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastSceneScript : MonoBehaviour {

public int lastScene;
int loadLevel;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
	 {
		loadLevel = SceneManager.GetActiveScene().buildIndex;
		if (loadLevel > 1)
		lastScene = SceneManager.GetActiveScene().buildIndex;
	}
}
