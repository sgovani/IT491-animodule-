using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationScene : MonoBehaviour {

	public InputField FirstnameField;
	public InputField LastnameField;
	public InputField EmailField;
	public InputField PasswordField;

	public Button CancelButton;
	public Button SubmitButton;

	private static readonly string POSTAddUserURL = "http://afsaccess1.njit.edu/~sg873/";
	private static readonly string route = "registration.php";

	void Start () {

		CancelButton.GetComponent<Button> ().onClick.AddListener (
			() => Load("login")
		);
			SubmitButton.GetComponent<Button> ().onClick.AddListener (
			() =>  RegisterUser(FirstnameField.text, LastnameField.text, EmailField.text, PasswordField.text)
		);
	}

	public void Load (string sceneName) {
		Initiate.Fade(sceneName, Color.white, 1.0f);
	}

	// Send Login 
	public bool RegisterUser(string firstname, string lastname, string email, string password) {
		WWW www;
		Hashtable postHeader = new Hashtable();
		postHeader.Add("Content-Type", "application/json");
		WWWForm form = new WWWForm();

		string json = @"{  'email':'"+ email+
						"', 'fName':'"+firstname+
						"', 'lName':'"+lastname+
						"', 'passW':'"+password+"'}";

		print(json);
		form.AddField("data", json);
		www = new WWW(POSTAddUserURL+route, form);
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


	// Update is called once per frame
	void Update () {
		
	}
}
