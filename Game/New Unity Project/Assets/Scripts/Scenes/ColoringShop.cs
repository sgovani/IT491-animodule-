using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColoringShop : MonoBehaviour {

    public enum Mode { BRUSH=0, SYMBOL, ERASER };

    public Button BrushButton, SymbolButton, EraserButton;

	// Use this for initialization
	void Start () {
		
        EraserButton.onClick.AddListener(() => SwitchState(Mode.ERASER));
        SymbolButton.onClick.AddListener(() => SwitchState(Mode.SYMBOL));
        BrushButton.onClick.AddListener(() => SwitchState(Mode.BRUSH));

    
    }

    // add a button to go the the second piece of the totem/bird/animodule
    // this should work for any animodule as long as we load the model correctly.
    // add a panel that will contain the loaded animodule
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SwitchState(Mode mode ){
        if (mode == Mode.ERASER){
            // U.I. Updates
            // call update to change the view
            // remove the raycast
        } 

        else if (mode == Mode.BRUSH) {
            // U.I. show the slider for size
            // add a button to pop-up color selector
            // change colors when needed
            // update the cursor with the brush size

        } 
        else if (mode == Mode.SYMBOL){
            // U.I. show the slider for size
            // add a button to select a symbol
            // resizing can happen at any given time
            // for the future, make the cursor look like the symbol
        } 
        else {
          // Make U.I. look normal if nothing is clicked  
        } 
    }

	private void OnDisable()
	{
		
	}

}
