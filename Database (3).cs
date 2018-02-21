using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour 
{
	public static string user = "";
	public static string name = "";

	private string password = "";
	private string rePass = "";
	private string errorMessage = "";

	private void OnGUI()
	{
		if (errorMessage != "")
			GUILayout.Box (errorMessage);
		
		GUILayout.Label ("Name");
		name = GUILayout.TextField (name);
		GUILayout.Label ("Username");
		user = GUILayout.TextField (user);
		GUILayout.Label ("Password");
		password = GUILayout.PasswordField (password, "*"[0]);
		GUILayout.Label ("Re-password");
		rePass = GUILayout.PasswordField (rePass, "*"[0]);
		if(GUILayout.Button("Register"))
		{
			errorMessage = "";

			if (user == "" || name == "" || password == "" || rePass == "")
				errorMessage += "Please complete all the fields. \n";
			else 
			{
				if (password == rePass) 
				{
					WWWForm form = new WWWForm ();
					form.AddField ("user", user);
					form.AddField ("name", name);
					form.AddField ("password", password);
					WWW w = new WWW ("http://animodulesregistration.dx.am/register.php", form);
					StartCoroutine (register (w));
				} 
				else
					errorMessage += "Password incorrect, please try again. \n";
			}
		}
	}

	IEnumerator register(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			errorMessage += w.text;
		} 
		else 
		{
			errorMessage += "ERROR: " + w.error + "\n";
		}
	}
}
