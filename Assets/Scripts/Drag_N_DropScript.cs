using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_N_DropScript : MonoBehaviour {

    private GameObject binGameObject;
	private GameObject touched;
	private Vector3 touchPos;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null && (hit.collider.gameObject.tag == "Unplaced" || hit.collider.gameObject.tag == "Placed"))	
			{		
				touched = hit.collider.gameObject;	
				touched.transform.tag = "Selected";
				
			}
			else if (touched != null && touched.tag == "Selected")
			{
				touchPos = new Vector3 (Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y,0);
				touched.transform.position = touchPos;
			}
        }
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && touched!= null)
		 	touched.transform.tag = "Placed";
	}
}
