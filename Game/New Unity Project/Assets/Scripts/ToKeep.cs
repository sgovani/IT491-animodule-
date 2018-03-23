using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using System.IO;

public class ToKeep : MonoBehaviour {
    /*This will have to be modified for animodules with modified for animodules
    with more than 2 peices, for every new peice a new baseMat, new canvasTexture,
    offSets and Scales
         
     Most of the code will have to be duplicated again for every new peice
         
     */
    public GameObject theScript;//Texture Painters scripts

    public Material baseMat;//Empty Material for Piece 1
   public Material baseMat2;//Empty Material for Piece 2

    public RenderTexture canvasTexture; //Texture for Piece 1
    public RenderTexture canvasTexture2; //Texture for Piece 2

    public float peice1XScale = 1.5f;    //Scale and offset of the Texture to fit onto the mdoel
    public float peice1YScale = 0.94f;
    public float peice1XOffset = 0.135f;
    public float peice1YOffset = 0.03f;

    public float peice2XScale = 1.49f;
    public float peice2YScale = 0.85f;
    public float peice2XOffset = -0.63f;
    public float peice2YOffset = -0.208f;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  
    public void saveMaterial()
    {
        baseMat = new Material(Shader.Find("Standard"));//Instatiates Material as a generic
        baseMat2 = new Material(Shader.Find("Standard"));

       
        RenderTexture.active = canvasTexture;//Sets the canvasTexture to the Active Render Texture 
        Texture2D texPiece1 = new Texture2D(canvasTexture.width, canvasTexture.height, TextureFormat.RGB24, false);// Makes a new Texture based on the render texture
        texPiece1.ReadPixels(new Rect(0, 0, canvasTexture.width, canvasTexture.height), 0, 0);//Transfers the texture to the new Texture
       
        RenderTexture.active = null;

        baseMat.SetTexture("_MainTex", texPiece1);//Sets the new texture to the Main texture of the new material
        texPiece1.Apply();
        byte[] bytesPiece1 = texPiece1.EncodeToPNG();//Encodes this new texture to a PNG
        //------------------------------------------------------
        RenderTexture.active = canvasTexture2;//Same as before but for the second piece
        Texture2D texPiece2 = new Texture2D(canvasTexture2.width, canvasTexture2.height, TextureFormat.RGB24, false);
        texPiece2.ReadPixels(new Rect(0, 0, canvasTexture2.width, canvasTexture2.height), 0, 0);

        RenderTexture.active = null;

        baseMat2.SetTexture("_MainTex", texPiece2);
        texPiece2.Apply();
        byte[] bytesPiece2 = texPiece2.EncodeToPNG();
        //----------------------------------------------------

        System.DateTime date = System.DateTime.Now;
        string dateAndTimeVar = System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");//Sets a string to the current date


        File.WriteAllBytes(Application.persistentDataPath + "/" + dateAndTimeVar + ".png", bytesPiece1);//Saves both file as a png with the string as the file name

        File.WriteAllBytes(Application.persistentDataPath + "/" + dateAndTimeVar + "_2.png", bytesPiece2);

        byte[] bytesPiece1_2 = File.ReadAllBytes(Application.persistentDataPath + "/" + dateAndTimeVar + ".png");//Reads back the files

        byte[] bytesPiece2_2 = File.ReadAllBytes(Application.persistentDataPath + "/" + dateAndTimeVar + "_2.png");

        Texture2D texPiece1_2 = new Texture2D(1,1);//Makes two more textures

        Texture2D texPiece2_2 = new Texture2D(1, 1);

        texPiece1_2.LoadImage(bytesPiece1_2);//Loads the images of the png to the texture

        texPiece2_2.LoadImage(bytesPiece2_2);

        baseMat.mainTexture = texPiece1_2;//Sets the texture of the material to this new texture

        baseMat2.mainTexture = texPiece2_2;

        baseMat.SetTextureScale("_MainTex", new Vector2(peice1XScale, peice1YScale));//Sets the Materials scale, and offset for both peices
        baseMat.SetTextureOffset("_MainTex",new Vector2(peice1XOffset, peice1YOffset));

        baseMat2.SetTextureScale("_MainTex", new Vector2(peice2XScale, peice2YScale));
        baseMat2.SetTextureOffset("_MainTex", new Vector2(peice2XOffset, peice2YOffset));

        DontDestroyOnLoad(transform.gameObject);//Makes sure this script is not destroied on a new scene load 

    }
}
