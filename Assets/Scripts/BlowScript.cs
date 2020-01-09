using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowScript : MonoBehaviour {
        public GameObject text;
void Start()
{
        var audio = GetComponent<AudioSource>();
        audio.clip = Microphone.Start(null,true, 5,44100);
        audio.loop = true;
        while (!( Microphone.GetPosition(null) > 0))
        {
                text.SetActive(true);
        }
        Debug.Log("start playing... position is " + Microphone.GetPosition(null));
}
	
 
 void Update()
 {

 }
	
}
