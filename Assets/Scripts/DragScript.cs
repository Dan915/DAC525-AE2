using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour {
	public float speed;
	Vector2 touchPos;
	private Transform playerTrans;
	int  incDifficulty;
	GameObject GameManager;

	// Use this for initialization
	void Start () 
	{
		GameManager = GameObject.Find("GameManager");
		incDifficulty = GameManager.GetComponent<GameManagerScript>().difficulty;
		speed -= incDifficulty;
		playerTrans = this.transform;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount > 0 )
        {
           	RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null && (hit.collider.gameObject.tag == "Selected" || hit.collider.gameObject.tag == "Placed"))	
			{	
				if(Input.GetTouch(0).phase == TouchPhase.Moved)
				{	
					touchPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5));			
					playerTrans.LookAt(touchPos);
					playerTrans.Translate(Vector3.forward * speed * Time.deltaTime);
					transform.rotation = Quaternion.identity;
				}
			}

		}
	}
}
