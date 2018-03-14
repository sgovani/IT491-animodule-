using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPController : MonoBehaviour {

    public string curPeice;
    public GameObject tp1;
    public GameObject tp2;
    public GameObject mainCamera;

    public Quaternion rot1;
    public Quaternion rot2;

	void Start () {//Sets the rotation of the camera for both peices;
        rot1 = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        rot2 = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        if (curPeice == "Totem1")//Makes sure the correct totem's TP is being used 
        {
            tp1.SetActive(true);
            tp2.SetActive(false);
        }else if(curPeice == "Totem2")
        {
            tp2.SetActive(true);
            tp1.SetActive(false);
        }
	}
	
	
	void Update () {
        if (curPeice == "Totem1")//Makes sure the correct totem's TP is being used and rotates the camera to the correct rotation
        {
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, rot1, Time.deltaTime * 10.0f);
            tp1.SetActive(true);
            tp2.SetActive(false);
        }
        else if (curPeice == "Totem2")
        {
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, rot2, Time.deltaTime * 10.0f);
            tp2.SetActive(true);
            tp1.SetActive(false);
        }
    }
}
