using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditMenu : MonoBehaviour {

	public GameObject SelectPanel;
	public GameObject TemplateButton;
	public GameObject BackButton;

	void Start () {
		BackButton.GetComponent<Button> ().onClick.AddListener (() => Load ("menu"));
		Sprite[] drafts = Resources.LoadAll<Sprite>("Drafts");
		foreach (Sprite draft in drafts) {
			GameObject container = Instantiate (TemplateButton) as GameObject;
			container.GetComponent<Image>().sprite = draft;
			container.transform.SetParent (SelectPanel.transform, false);
			string sceneName = draft.name;
			container.GetComponent<Button> ().onClick.AddListener (() => Load (sceneName));
		}
	}

	public void Load (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
