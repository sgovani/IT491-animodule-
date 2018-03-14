using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShareMenu : MonoBehaviour {
	
	public GameObject BackButton;

	void Start () {
		BackButton.GetComponent<Button> ().onClick.AddListener (() => Load ("menu"));
	}

	public void Load (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
