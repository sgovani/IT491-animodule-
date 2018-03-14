using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject CreateButton;
	public GameObject ShareButton;

    //Another script to load scenes using the fade script
    
	void Start () {
		CreateButton.GetComponent<Button> ().onClick.AddListener (() => Load("create"));
		
		ShareButton.GetComponent<Button> ().onClick.AddListener (() => Load("share"));
	}
	
	public void Load(string sceneName){
        Initiate.Fade(sceneName, Color.white, 1.0f);
	}
}
