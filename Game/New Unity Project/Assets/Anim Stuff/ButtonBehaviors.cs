using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehaviors : MonoBehaviour {
    
    public Animation onStart;
    public bool CarrotDown = false;//Flag to check if menu is down
    public GameObject colorSelector;//Color Selector
    public GameObject paintedObj;
    bool ColorUP = false;//Flag to see if the color selecter is showing
    public GameObject TexturePainters;//Both Texture painters
    public bool symbolsMenuOut = false;//Flag to see if the Symbols Menu is out
    public bool brushMenuOut = false;//Flag to see if the Brush menu is up
    bool symbolsOut = false;//Flag to see if the symbols are out


    void Update()
    {

    }
    //Plays the inital animation for the scene for the totem
    public void PlayAnim()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Animodule");
        go.GetComponent<Animation>().Play("OnStart3");

    }
    //Loads the Animation Suite
    public void AnimationSuite() {
        Initiate.Fade("AnimationScene", Color.white, 1.0f);
        SceneManager.UnloadSceneAsync("ColoringSuite");
       
       }
    //Plays the inital animation for the scene for the bird
    public void BirdAnim()
    {
        Initiate.Fade("BirdAnimation", Color.white, 1.0f);
        SceneManager.UnloadSceneAsync("BirdColoring");
    }
    //Loads the Totem coloring suite and destory the _GlobalStuff which is the ToKeep script contains the texture and materials
    public void ColoringSuite()
    {
        Destroy(GameObject.Find("_GlobalStuff"));
        Initiate.Fade("ColoringSuite", Color.white, 1.0f);
        SceneManager.UnloadSceneAsync("AnimationScene");
       
    }
    //Loads the Bird coloring suite and destory the _GlobalStuff which is the ToKeep script contains the texture and materials
    public void BirdColoringSuite()
    {
        Destroy(GameObject.Find("_GlobalStuff"));
        Initiate.Fade("BirdColoring", Color.white, 1.0f);
        SceneManager.UnloadSceneAsync("BirdAnimation");

    }
    //Loads the main menu
    public void MainMenu()
    {
        Initiate.Fade("menu", Color.white, 1.0f);
      
    }

    public void MainBar()
    {
        if (CarrotDown == false)//If the menu is not down
        {
            TexturePainters.SetActive(false);//Turns off Painting
            GameObject go = GameObject.FindGameObjectWithTag("Carrot");//Get the menu button(Three bars)
        
            go.GetComponent<Animation>().Play("RotateDown");//Plays the Rotate down Animation
          
            CarrotDown = true;//Set that the menu is down
            GameObject go2 = GameObject.FindGameObjectWithTag("DropDownMenu1");
            go2.GetComponent<Animation>().Play("DropDown");//Plays the Dropdown animation on the menu
          
            
        }
        else//If the menu is down
        {
            TexturePainters.SetActive(true);//Allows for painting
            GameObject go = GameObject.FindGameObjectWithTag("Carrot");
            go.GetComponent<Animation>().Play("RotateRight");//Plays the rotateRight animation for meny Button(Three bars)
            CarrotDown = false;//Set that the menu is up
            GameObject go2 = GameObject.FindGameObjectWithTag("DropDownMenu1");
            go2.GetComponent<Animation>().Play("DropUP");//Plays the drop up animation on the menu
            
        }
    }
    public void MenuClose()//Function to force the menu to close
    {
        GameObject go = GameObject.FindGameObjectWithTag("Carrot");
        go.GetComponent<Animation>().Play("RotateRight");
        CarrotDown = false;
        GameObject go2 = GameObject.FindGameObjectWithTag("DropDownMenu1");
        go2.GetComponent<Animation>().Play("DropUP");
    }
    public void MakeActive()//Function to force the ability to paint
    {
        TexturePainters.SetActive(true);
    }
    public void selectColor()
    {
        if (CarrotDown)//If the menu is open closes it
        {
            MainBar();
        }
        if(ColorUP== false)//If the color selector is not on screne
        {
            GameObject go = GameObject.FindGameObjectWithTag("ColorSelector");
            go.GetComponent<Animation>().Play("SlideIn");//Slides in the color selector
   
            TexturePainters.SetActive(false);//Disables painting
            ColorUP = true;//Set that the color selector is up
        }
        else//If the color selector is up
        {
            TexturePainters.SetActive(true);//Allow painting
            GameObject go = GameObject.FindGameObjectWithTag("ColorSelector");
            go.GetComponent<Animation>().Play("SlideOut");//Slides out color selector
   
          
            ColorUP = false;//Set that the color selector is no on screne
        }
        
    }

    public void symbols()
    {
        if (!symbolsMenuOut)//If the symbols Menu is not on screne
        {
            GameObject go = GameObject.FindGameObjectWithTag("SymbolsMenu");
            go.GetComponent<Animation>().Play("SlideRight");//Slides in the Symbol sub menu
            symbolsMenuOut = true;//set that the sub menu is out
            TexturePainters.SetActive(false);//disables painting
        }
        else//If the symbols menu is on screne 
        {
            GameObject go = GameObject.FindGameObjectWithTag("SymbolsMenu");
            go.GetComponent<Animation>().Play("SlightLeft");//Slides out the symbol sub menu
            symbolsMenuOut = false;//set that the sub menu is not out

        }
    }

    public void brush()
    {
        if (!brushMenuOut) {//If the brush menu is not out
            GameObject go = GameObject.FindGameObjectWithTag("BrushMenu");
            go.GetComponent<Animation>().Play("SlideRight");//Slides in the brush menu
            brushMenuOut = true;//Sets that it is out
          
        }
        else//If the brush menu is out
        {
            GameObject go = GameObject.FindGameObjectWithTag("BrushMenu");
            go.GetComponent<Animation>().Play("SlightLeft");//Slides out the brush menu
            brushMenuOut = false;//sets that is is not out
         
        }

    }
    //Function that check if the brush menu is out and slides it away and set that it is not out
    public void brushCheck()
    {
        if (brushMenuOut)
        {
            GameObject go = GameObject.FindGameObjectWithTag("BrushMenu");
            go.GetComponent<Animation>().Play("SlightLeft");
            brushMenuOut = false;
          
        }
    }

    public void symbolsBox()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Symbols");
        if(symbolsOut == false)//If the symbols are on not on screne
        {
            go.GetComponent<Animation>().Play("SlideInSymbol");
            symbolsOut = true;//Slides in the symbols
            
        }
        else
        {//If the symbols are on screne
            go.GetComponent<Animation>().Play("SlideOutSymbols");
            symbolsOut = false;//Slides out the symbols
           
        }
    }
    //Function to check if the symbols are out if so slides them away and set that they are not on screne
    public void symbolsBoxCheck()
    {
        if (symbolsOut)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Symbols");
            go.GetComponent<Animation>().Play("SlideOutSymbols");
            symbolsOut = false;
       
        }
    }
    //Function to check if the symbols menu is out, if so it slides them away and set that they are not on screne
    public void symbolsMenuCheck()
    {
        if (symbolsMenuOut)
        {
            GameObject go = GameObject.FindGameObjectWithTag("SymbolsMenu");
            go.GetComponent<Animation>().Play("SlightLeft");
            symbolsMenuOut = false;
         
        }
    }

    public void pieceSwitch()
    {
        string curPiece = gameObject.GetComponent<TPController>().curPeice;
        if (curPiece == "Totem1")//If the current peice is Totem1 switches  to Totem Piece 2
        {
            gameObject.GetComponent<TPController>().curPeice = "Totem2";
        }else if(curPiece == "Totem2")//If the current peice is Totem2 switches to totem Peice 2
        {
            gameObject.GetComponent<TPController>().curPeice = "Totem1";
        }
    }


}
