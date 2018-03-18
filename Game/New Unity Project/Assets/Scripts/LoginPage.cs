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
	private static readonly string POSTAddUserURL = "http://afsaccess1.njit.edu/~sg873/login.php";
	
	//This scripts add a listener to a the panel and loads the menu scene user the fade script
	void Start () {
		LoginButton.GetComponent<Button> ().onClick.AddListener (() => Login(UsernameField.text, PasswordField.text));
	}

	public void Login(string username, string password) {
		// Check if backend is good to go
		loginCorrect = true;
		print (username);
		print (password);
		loginCorrect = SendLogin (username, password);

		if (loginCorrect) {
			Load ("menu");
		} else {
			// Show error 
			print("error can't login");
		}
	}

	// Send Login 
	public bool SendLogin(string username, string password) {
		WWW www;
		Hashtable postHeader = new Hashtable();
		postHeader.Add("Content-Type", "application/json");
		WWWForm form = new WWWForm();

		string json = @"{ 'user':'"+username+"','pass':'"+password+"'}";

		print(json);
		form.AddField("data", json);
		www = new WWW(POSTAddUserURL, form);
		StartCoroutine(WaitForRequest(www));

		return false;
	}

	// Callback implmentation
	IEnumerator WaitForRequest(WWW data) {
		yield return data; // Wait until the download is done
		if (data.error != null) {
			print("There was an error sending request: " + data.error);
		}
		else {
			print("WWW Request: " + data.text);
		}
	}


	public void Load (string sceneName) {
		Initiate.Fade(sceneName, Color.white, 1.0f);
	}
}
