using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginPage : MonoBehaviour {

	public GameObject LoginButton;
	public InputField UsernameField;
	public InputField PasswordField;
	bool loginCorrect;

	//This scripts add a listener to a the panel and loads the menu scene user the fade script
	void Start () {
		LoginButton.GetComponent<Button> ().onClick.AddListener (() => Login(UsernameField.text, PasswordField.text));
	}

	public void Login(string username, string password) {
		// Check if backend is good to go
		loginCorrect = true;
		print (username);
		print (password);

		if (loginCorrect) {
			Load ("create");
		} else {
			// Show error 
			print("error can't login");
		}
	}

	public void Load (string sceneName) {
		Initiate.Fade(sceneName, Color.white, 1.0f);
	}
}
