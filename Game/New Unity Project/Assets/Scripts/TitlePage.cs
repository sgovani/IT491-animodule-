using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitlePage : MonoBehaviour {

	public GameObject Panel;
    //This scripts add a listener to a the panel and loads the menu scene user the fade script
	void Start () {
		Panel.GetComponent<Button>().onClick.AddListener(()=>Load("menu"));
	}
	
	public void Load (string sceneName) {
        Initiate.Fade(sceneName, Color.white, 1.0f);
		
	}
}
