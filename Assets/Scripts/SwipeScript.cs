using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour {
	public float force;
    float forceX, forceY;
	private Vector3 Ftouch;   
    private Vector3 Ltouch;   
    public int screenSize;
    private float dragDistance; 
    public bool is3D;
    public bool throwBall;
   
    void Start()
    {
        dragDistance = Screen.height * screenSize / 100;
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Began)
            {
                Ftouch = touch.position;
                Ltouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Ltouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) 
            {
                Ltouch = touch.position; 

                if (Mathf.Abs(Ltouch.x - Ftouch.x) > dragDistance || Mathf.Abs(Ltouch.y - Ftouch.y) > dragDistance)
                {
                    if (is3D && throwBall)
                    {
                        forceX = Ltouch.x - Ftouch.x;
                        forceY = Ltouch.y - Ftouch.y;
                        if (Ltouch.x > Ftouch.x || Ltouch.y > Ftouch.y) 
                        gameObject.GetComponent<Rigidbody>().AddForce(forceX,forceY,0);
                    }
                    if (Mathf.Abs(Ltouch.x - Ftouch.x) > Mathf.Abs(Ltouch.y - Ftouch.y))
                    {
                        if (!is3D)
                        {
                            if ((Ltouch.x > Ftouch.x)) 
                            {
                                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force,50));
                            }
                            else
                            {
                                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force,50));
                            }
                        }
                        else if (!throwBall)
                        { 
                            if ((Ltouch.x > Ftouch.x)) 
                            {
                                gameObject.GetComponent<Rigidbody>().AddForce(force,0,0);
                            }
                            else
                            {
                                gameObject.GetComponent<Rigidbody>().AddForce(-force,0,0);
                            }
                        }
                        else
                        {
                            
                            // else if (Ltouch.x > Ftouch.x)
                            //     gameObject.GetComponent<Rigidbody>().AddForce(0,forceX,0);
                            // else if (Ltouch.y > Ftouch.y)
                            //     gameObject.GetComponent<Rigidbody>().AddForce(forceY,0,0);
                        }
                    }
                }
            }
        }
    }
}
