using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file controls the animodules themselves, and loads them for the user to see them

public class AnimController : MonoBehaviour {

	float rotSpeed = 0.5f;

	GameObject go;
    GameObject go2;

	void Start () {
        GameObject script = GameObject.Find("_GlobalStuff");//Finds the dont destory on load objects
    
		go = GameObject.FindGameObjectWithTag ("Animodule");
        go2= GameObject.FindGameObjectWithTag("AnimodulePiece2");//Gets both peices
        go.GetComponent<Renderer>().material = script.GetComponent<ToKeep>().baseMat;//Sets the materials
        go2.GetComponent<Renderer>().material = script.GetComponent <ToKeep>().baseMat2;
        go.GetComponent<Animation>().Play();//Plays the base animation
    }
	
	
	void Update () {
		if (Input.touchCount == 1) {
			Touch theTouch = Input.GetTouch (0);//Gets first input touches
			if (theTouch.phase == TouchPhase.Moved) {//Check if there is movement
				Vector2 touchDelta = theTouch.deltaPosition;
				go.transform.Rotate (touchDelta.y * rotSpeed, -touchDelta.x * rotSpeed, 0, Space.World);//Rotates based on the change in position of the touch
			}
		}
	}

    private void OnLoad() {
        GameObject script = GameObject.Find("_GlobalStuff");//Code redunancy for Start()


        go = GameObject.FindGameObjectWithTag("Animodule");
        go2 = GameObject.FindGameObjectWithTag("AnimodulePiece2");
        go.GetComponent<Renderer>().material = script.GetComponent<ToKeep>().baseMat;
        go2.GetComponent<Renderer>().material = script.GetComponent<ToKeep>().baseMat2;
        go.GetComponent<Animation>().Play();
    }
}
