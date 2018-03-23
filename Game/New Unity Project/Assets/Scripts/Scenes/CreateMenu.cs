using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateMenu : MonoBehaviour {

	public GameObject SelectPanel;
	public GameObject TemplateButton;
	public GameObject BackButton;

	void Start () {
		BackButton.GetComponent<Button> ().onClick.AddListener (() => Load ("menu"));

        //Loads all Sprites from Templates folder under the Resources Folder
        Sprite[] templates = Resources.LoadAll<Sprite>("Templates");

        //For each sprite from the templates folder, a new Button is instatiated
        //The sprite is set for the button
        //Parent object is set
        //And a listener is added to the button so it can load the next scene
		foreach (Sprite template in templates) {
			GameObject container = Instantiate (TemplateButton) as GameObject;
			container.GetComponent<Image>().sprite = template;
			container.transform.SetParent (SelectPanel.transform, false);
			string sceneName = template.name;
            Debug.Log(sceneName);
			container.GetComponent<Button> ().onClick.AddListener (() => Load (sceneName));
		}
	}
    //Depending on the passed name the approprate scene is faded in
	public void Load (string sceneName) {
        if (sceneName == "TotemPiece")
        {
            Initiate.Fade("ColoringSuite", Color.white, 2.0f);
           
        }else if (sceneName == "BirdPiece")
        {
          
            Initiate.Fade("BirdColoring", Color.white, 2.0f);
        }
		
	}
    //Loads the menu scene
    public void Back()
    {
        Initiate.Fade("Menu", Color.white, 1.0f);
    }
}
