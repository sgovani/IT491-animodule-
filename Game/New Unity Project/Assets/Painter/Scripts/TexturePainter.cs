/// <summary>
/// CodeArtist.mx 2015
/// This is the main class of the project, its in charge of raycasting to a model and place brush prefabs infront of the canvas camera.
/// If you are interested in saving the painted texture you can use the method at the end and should save it to a file.
/// </summary>


using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Painter_BrushMode{PAINT,DECAL};

public class TexturePainter : MonoBehaviour {
	public GameObject brushCursor, brushContainer; 	//The cursor that overlaps the model and our container for the brushes painted
	public Camera sceneCamera,canvasCam;  			//The camera that looks at the model, and the camera that looks at the canvas.
	public Sprite cursorPaint, cursorDecal; 			// Cursor for the differen functions 
	public RenderTexture canvasTexture; 			// Render Texture that looks at our Base Texture and the painted brushes
	public Material baseMaterial; 					// The material of our base texture (Were we will save the painted texture)
    public string brush ="paint";
	Painter_BrushMode mode; 						//Our painter mode (Brushes or decals)
	float brushSize=0.1f; 							//The size of our brush
    float SymbolSize = 0.1f;
	Color brushColor; 								//The selected color
	int brushCounter=0,MAX_BRUSH_COUNT=1000000; 	//To avoid having millions of brushes
	bool saving=false; 								//Flag to check if we are saving the texture
    public Slider brushSlider;
    public Slider SymbolSlider;
	
	void Update () {
        
        brushColor = ColorSelector.GetColor ();	//Updates our painted color with the selected color
		if (Input.GetMouseButton(0)) {
            if (Input.touchCount < 2)
            {
                DoAction();
            }
		}
		UpdateBrushCursor ();
	}

	//The main action, instantiates a brush or decal entity at the clicked position on the UV map
	/// <summary>
	/// TODO: separate the brush and the symbols from the same tool. 
	/// TODO: add a tool bar to the left of the screen instead of a hamburger menu, to allow the users to edit
	/// 
	/// </summary>
	void DoAction(){	
		if (saving)
			return;
		Vector3 uvWorldPosition=Vector3.zero;		
		if(HitTestUVPosition(ref uvWorldPosition)){
			GameObject brushObj;
            brushSize = brushSlider.value + 1;
            SymbolSize = SymbolSlider.value;
     
            switch (brush) {
                case "abundence":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/abundance_prefab"));
                    
                    break;
                case "Adaptability":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Adaptability_prefab"));
                    
                    break;
                case "adoration":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/adoration_prefab"));
                    
                    break;
                case "Affluence":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Affluence_prefab"));
                    
                    break;
                case "Arrogance":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Arrogance_prefab"));
                    
                    break;
                case "Authority":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Authority_prefab"));
                    
                    break;
                case "Bondage":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Bondage_prefab"));
                    
                    break;
                case "Bravery":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Bravery_prefab"));
                    
                    break;
                case "Brotherhood":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Brotherhood_prefab"));
                    
                    break;
                case "Confidence":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Confidence_prefab"));
                    
                    break;
                case "Cooperation":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Cooperation_prefab"));
                    
                    break;
                case "Cooperation-2":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Cooperation-2_prefab"));
                    
                    break;
                case "Craftiness":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Craftiness_prefab"));
                    
                    break;
                case "Defiance":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Defiance_prefab"));
                    
                    break;
                case "Democracy":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Democracy_prefab"));
                    
                    break;
                case "demoracy-2":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/demoracy-2_prefab"));
                    
                    break;
                case "Devotion":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Devotion_prefab"));
                    
                    break;
                case "Discipline":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Discipline_prefab"));
                    
                    break;
                case "Divinity":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Divinity_prefab"));
                    
                    break;
                case "Exemplary-Leadership":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Exemplary-Leadership_prefab"));
                    
                    break;
                case "Experience":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Experience_prefab"));
                    
                    break;
                case "Faith":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Faith_prefab"));
                    
                    break;
                case "Faith-in-God":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Faith-in-God_prefab"));
                    
                    break;
                case "Family-Unity":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Family-Unity_prefab"));
                    
                    break;
                case "Farewell":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Farewell_prefab"));
                    
                    break;
                case "Farewell-2":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Farewell-2_prefab"));
                    
                    break;
                case "Fate":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Fate_prefab"));
                    
                    break;
                case "Fearlessness":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Fearlessness_prefab"));
                    
                    break;
                case "Femininity":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Femininity_prefab"));
                    
                    break;
                case "Fortitude":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Fortitude_prefab"));
                    
                    break;
                case "Friendship":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Friendship_prefab"));
                    
                    break;
                case "Gods-Blessing":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Gods-Blessing_prefab"));
                    
                    break;
                case "Gods-Creations":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Gods-Creations_prefab"));
                    
                    break;
                case "Gods-Guidance":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Gods-Guidance_prefab"));
                    
                    break;
                case "Gods-Minipresence":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Gods-Minipresence_prefab"));
                    
                    break;
                case "Gods-Omnipotence":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Gods-Omnipotence_prefab"));
                    
                    break;
                case "Gods-Protection":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Gods-Protection_prefab"));
                    
                    break;
                case "Good-Luck":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Good-Luck_prefab"));
                    
                    break;
                case "Harmony":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Harmony_prefab"));
                    
                    break;
                case "Harmony-2":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Harmony-2_prefab"));
                    
                    break;
                case "Heroic-Deeds":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Heroic-Deeds_prefab"));
                    
                    break;
                case "Hypocrisy":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Hypocrisy_prefab"));
                    
                    break;
                case "Inequality":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Inequality_prefab"));
                    
                    break;
                case "Ingenuity":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Ingenuity_prefab"));
                    
                    break;
                case "ingratitude":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/ingratitude_prefab"));
                    
                    break;
                case "Interdependence":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Interdependence_prefab"));
                    
                    break;
                case "Jealousy":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Jealousy_prefab"));
                    
                    break;
                case "Joy-of-Living":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Joy-of-Living_prefab"));
                    
                    break;
                case "Justice":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Justice_prefab"));
                    
                    break;
                case "Knowledge":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Knowledge_prefab"));
                    
                    break;
                case "Leadership":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Leadership_prefab"));
                    
                    break;
                case "Legality":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Legality_prefab"));
                    
                    break;
                case "Life-Transformation":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Life-Transformation_prefab"));
                    
                    break;
                case "Lifes-Challenges":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Lifes-Challenges_prefab"));
                    
                    break;
                case "Loyalty":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Loyalty_prefab"));
                    
                    break;
                case "Loyalty-2":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Loyalty-2_prefab"));
                    
                    break;
                case "Majesty-of-God":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Majesty-of-God_prefab"));
                    
                    break;
                case "Maternal-Love":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Maternal-Love_prefab"));
                    
                    break;
                case "Morality":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Morality_prefab"));
                    
                    break;
                case "Nurturing-Spirit":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Nurturing-Spirit_prefab"));
                    
                    break;
                case "Patronage":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Patronage_prefab"));
                    
                    break;
                case "Patronage-2":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Patronage-2_prefab"));
                    
                    break;
                case "Permanence":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Permanence_prefab"));
                    
                    break;
                case "Poetic-Eloquence":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Poetic-Eloquence_prefab"));
                    
                    break;
                case "Power":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Power_prefab"));
                    
                    break;
                case "Precious-Treasure":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Precious-Treasure_prefab"));
                    
                    break;
                case "Precision":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Precision_prefab"));
                    
                    break;
                case "Praise":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Praise_prefab"));

                    break;
                case "Preserverance":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Preserverance_prefab"));
                    
                    break;
                case "Progress":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Progress_prefab"));
                    
                    break;
                case "Prosperity":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Prosperity_prefab"));
                    
                    break;
                case "Protection":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Protection_prefab"));
                    
                    break;
                case "Protection-1":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Protection-1_prefab"));
                    
                    break;
                case "prudence":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/prudence_prefab"));
                    
                    break;
                case "Recognition":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Recognition_prefab"));
                    
                    break;
                case "Royal-Power":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Royal-Power_prefab"));
                    
                    break;
                case "Royal-Protection":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Royal-Protection_prefab"));
                    
                    break;
                case "Seat-of-Government":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Seat-of-Government_prefab"));
                    
                    break;
                case "Security":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Security_prefab"));
                    
                    break;
                case "Serenity":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Serenity_prefab"));
                    
                    break;
                case "Spiritual-Loyalty":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Spiritual-Loyalty_prefab"));
                    
                    break;
                case "Standard-of-Quality":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Standard-of-Quality_prefab"));
                    
                    break;
                case "Strategy":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Strategy_prefab"));
                    
                    break;
                case "Strength":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Strength_prefab"));
                    
                    break;
                case "Superirority":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Superirority_prefab"));
                    
                    break;
                case "Sweetness":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Sweetness_prefab"));
                    
                    break;
                case "Tenderness":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Tenderness_prefab"));
                    
                    break;
                case "Togetherness":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Togetherness_prefab"));
                    
                    break;
                case "Toughness":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Toughness_prefab"));
                    
                    break;
                case "Unity":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Unity_prefab"));
                    
                    break;
                case "Valor":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Valor_prefab"));
                    
                    break;
                case "Veracity":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Veracity_prefab"));
                    
                    break;
                case "Wisdom":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Wisdom_prefab"));
                    
                    break;
                case "Wise-Leadership":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Adinkra/Wise-Leadership_prefab"));
                    
                    break;
                    //--------------------------
                case "Butterfly":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/Butterfly_prefab"));
                    
                    break;
                case "butterfly1":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/butterfly1_prefab"));
                    
                    break;
                case "Clouds":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/Clouds_prefab"));
                    
                    break;
                case "diamond1":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/diamond1_prefab"));
                    
                    break;
                case "dragon":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/dragon_prefab"));
                    
                    break;
                case "dragon1":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/dragon1_prefab"));
                    
                    break;
                case "dragon_fly":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/dragon_fly_prefab"));
                    
                    break;
                case "Eye":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/Eye_prefab"));
                    
                    break;
                case "face":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/face_prefab"));
                    
                    break;
                case "flower":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/flower_prefab"));
                    
                    break;
                case "hibiscus_flower":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/hibiscus_flower_prefab"));
                    
                    break;
                case "koi_fish":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/koi_fish_prefab"));
                    
                    break;
                case "lotus_flower":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/lotus_flower_prefab"));
                    
                    break;
                case "moon":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/moon_prefab"));
                    
                    break;
                case "Peace":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/Peace_prefab"));
                    
                    break;
                case "rose":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/rose_prefab"));
                    
                    break;
                case "Seahorse":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/Seahorse_prefab"));
                    
                    break;
                case "ShiningStar":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/ShiningStar_prefab"));
                    
                    break;
                case "Shooting Star":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/Shooting Star_prefab"));
                    
                    break;
                case "SmallSun":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/SmallSun_prefab"));
                    
                    break;
                case "star":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/star_prefab"));
                    
                    break;
                case "stars":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/stars_prefab"));
                    
                    break;
                case "Sun":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/Sun_prefab"));
                    
                    break;
                case "Sun with Face":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/Sun with Face_prefab"));
                    
                    break;
                case "Sun2":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/Sun2_prefab"));
                    
                    break;
                case "sun3":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/sun3_prefab"));
                    
                    break;
                case "turtle":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/turtle_prefab"));
                    
                    break;
                case "turtle2":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/turtle2_prefab"));
                    
                    break;
                case "WhatIsThis":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/WhatIsThis_prefab"));
                    
                    break;
                case "X-Star":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/X-Star_prefab"));
                    
                    break;
                case "yin_yang":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/Misc/yin_yang_prefab"));
                    break;
                    //-----------------------------------------
                case "Sacred-1":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-1_prefab"));
                    break;
                case "Sacred-2":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-2_prefab"));
                    break;
                case "Sacred-3":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-3_prefab"));
                    break;
                case "Sacred-4":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-4_prefab"));
                    break;
                case "Sacred-5":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-5_prefab"));
                    break;
                case "Sacred-6":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-6_prefab"));
                    break;
                case "Sacred-7":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-7_prefab"));
                    break;
                case "Sacred-8":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-8_prefab"));
                    break;
                case "Sacred-9":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-9_prefab"));
                    break;
                case "Sacred-10":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-10_prefab"));
                    break;
                case "Sacred-11":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-11_prefab"));
                    break;
                case "Sacred-12":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-12_prefab"));
                    break;
                case "Sacred-13":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-13_prefab"));
                    break;
                case "Sacred-14":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-14_prefab"));
                    break;
                case "Sacred-15":
                    brushObj = (GameObject)Instantiate(Resources.Load("Symbols/SacredGeometry/Sacred-15_prefab"));
                    break;
                default:
                    brushObj = (GameObject)Instantiate(Resources.Load("TexturePainter-Instances/BrushEntity")); //Paint a brush
                    brushObj.GetComponent<SpriteRenderer>().color = brushColor; //Set the brush color
                    break;
                    
            }
//            
//			if(mode==Painter_BrushMode.PAINT){
//
//				brushObj=(GameObject)Instantiate(Resources.Load("TexturePainter-Instances/MyBrushEntity2")); //Paint a brush
//				brushObj.GetComponent<SpriteRenderer>().color=brushColor; //Set the brush color
//			}
//		
            
		
			brushObj.transform.parent=brushContainer.transform; //Add the brush to our container to be wiped later
			brushObj.transform.localPosition=uvWorldPosition; //The position of the brush (in the UVMap)
            if(brush == "paint")
            {
                brushColor.a = brushSize * 2.0f;
                brushObj.transform.localScale = Vector3.one * brushSize;
            }
            else
            {
                brushColor.a = SymbolSize * 2.0f;
                brushObj.transform.localScale = Vector3.one * SymbolSize;
            }
			
		}
		brushCounter++; //Add to the max brushes
        brush ="paint";
		if (brushCounter >= MAX_BRUSH_COUNT) { //If we reach the max brushes available, flatten the texture and clear the brushes
			brushCursor.SetActive (false);
			saving=true;
			Invoke("SaveTexture",0.1f);
			
		}
	}

	//To update at realtime the painting cursor on the mesh
	void UpdateBrushCursor(){
		// Set the uvWorldPosition to zero
		Vector3 uvWorldPosition=Vector3.zero;
		Vector3 offsetVector = Vector3.zero;
		offsetVector.Set(0.07f, 0.01f, 0.0f);

		if (HitTestUVPosition (ref uvWorldPosition) && !saving) {
			brushCursor.SetActive(true);
			// Add offset to account for the circle of the cursor, the cursor needs to be in the middle not the right side of the mouse
			brushCursor.transform.position =  (uvWorldPosition + brushContainer.transform.position) - offsetVector;
			print ("Brush cursor position is" + brushCursor.transform.position);
			print ("UV WORLD POSITION IS" + uvWorldPosition);
			print ("Brush offset" + offsetVector);
		} else {
			brushCursor.SetActive(false);
		}		
	}


	//Returns the position on the texuremap according to a hit in the mesh collider
	bool HitTestUVPosition(ref Vector3 uvWorldPosition){
		RaycastHit hit;
		Vector3 cursorPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f);
		Ray cursorRay=sceneCamera.ScreenPointToRay (cursorPos);
		if (Physics.Raycast(cursorRay,out hit,200)){
			MeshCollider meshCollider = hit.collider as MeshCollider;
			if (meshCollider == null || meshCollider.sharedMesh == null)
				return false;			
			Vector2 pixelUV  = new Vector2(hit.textureCoord.x,hit.textureCoord.y);
			uvWorldPosition.x=pixelUV.x-canvasCam.orthographicSize;//To center the UV on X
			uvWorldPosition.y=pixelUV.y-canvasCam.orthographicSize;//To center the UV on Y
			uvWorldPosition.z=0.0f;
			return true;
		}
		else{		
			return false;
		}
		
	}


	//Sets the base material with a our canvas texture, then removes all our brushes
	void SaveTexture(){		
		brushCounter=0;
		System.DateTime date = System.DateTime.Now;
		RenderTexture.active = canvasTexture;
		Texture2D tex = new Texture2D(canvasTexture.width, canvasTexture.height, TextureFormat.RGB24, false);		
		tex.ReadPixels (new Rect (0, 0, canvasTexture.width, canvasTexture.height), 0, 0);
		tex.Apply ();
		RenderTexture.active = null;
		baseMaterial.mainTexture =tex;	//Put the painted texture as the base
		foreach (Transform child in brushContainer.transform) {//Clear brushes
			Destroy(child.gameObject);
		}
		//StartCoroutine ("SaveTextureToFile"); //Do you want to save the texture? This is your method!
		Invoke ("ShowCursor", 0.1f);
	}
	//Show again the user cursor (To avoid saving it to the texture)
	void ShowCursor(){	
		saving = false;
	}

	////////////////// PUBLIC METHODS //////////////////

	public void SetBrushMode(Painter_BrushMode brushMode){ //Sets if we are painting or placing decals
		mode = brushMode;
		brushCursor.GetComponent<SpriteRenderer> ().sprite = brushMode == Painter_BrushMode.PAINT ? cursorPaint : cursorDecal;
	} 	
	public void SetBrushSize(float newBrushSize){ //Sets the size of the cursor brush or decal
		brushSize = newBrushSize;
		print ("Brush size is"+ brushSize); 
		brushCursor.transform.localScale = Vector3.one * brushSize ;
	}

	////////////////// OPTIONAL METHODS //////////////////

	#if !UNITY_WEBPLAYER 
		IEnumerator SaveTextureToFile(Texture2D savedTexture){		
			brushCounter=0;
			string fullPath=System.IO.Directory.GetCurrentDirectory()+"\\UserCanvas\\";
			System.DateTime date = System.DateTime.Now;
			string fileName = "CanvasTexture.png";
			if (!System.IO.Directory.Exists(fullPath))		
				System.IO.Directory.CreateDirectory(fullPath);
			var bytes = savedTexture.EncodeToPNG();
			System.IO.File.WriteAllBytes(fullPath+fileName, bytes);
			Debug.Log ("<color=orange>Saved Successfully!</color>"+fullPath+fileName);
			yield return null;
		}
	#endif
}
