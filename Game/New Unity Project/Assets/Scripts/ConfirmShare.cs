using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmShare : MonoBehaviour {

    // Use this for initialization
    public GameObject go;
    bool MenuOut = false;
	void Start () {
		
	}
	
    public void SendOut()
    {
        if (!MenuOut)
        {
            MenuOut = true;
            go.SetActive(true);
        }
        else
        {
            MenuOut = false;
            go.SetActive(false);
        }
    }
}
