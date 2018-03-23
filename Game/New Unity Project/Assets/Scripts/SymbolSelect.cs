using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolSelect : MonoBehaviour {

    public GameObject SelectPanel;//Pannel where the button get placed
    public GameObject TemplateButton;//Prefab of the button instatiated on the symbol menu
    int currentIndex;
    int currentName;
    bool dragging = false;
    float initalX = 0;
    GameObject[] buttons;
    public GameObject labelName;
    public GameObject labelType;
    public GameObject labelMeaning;
    int count = 0;
    public GameObject Scripts;//Gameobject with all scripts
    // Use this for initialization
    void Start () {
    
        buttons = GameObject.FindGameObjectsWithTag("tempButton");
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] x = GameObject.FindGameObjectsWithTag("tempButton");//Gets every object taged as tempButton (TemplateButtons)
       foreach(GameObject button in x)
        {
            if(button.GetComponent<ButtonVariables>().index == currentIndex)//If the button's index value (on Button variables script on every temp Button) equals currentIndex
            {
                string newStr = button.GetComponent<ButtonVariables>().symbolName;//Generates Name strings
                if (button.GetComponent<ButtonVariables>().symbolLiteral != "")
                {
                    newStr = newStr + "(" + button.GetComponent<ButtonVariables>().symbolLiteral + ")";
                }
                labelName.GetComponent<Text>().text = newStr;//Assigns Name to label
                labelMeaning.GetComponent<Text>().text = button.GetComponent<ButtonVariables>().symbolMeaning;//Assigns Meaning to label
                labelType.GetComponent<Text>().text = button.GetComponent<ButtonVariables>().typeMeaning;//Assigns type to label
            }
        }
    }
    public void buildSymbolList(string type)
    {
       
        Sprite[] symbols = Resources.LoadAll<Sprite>("Symbols"+type);//Load all sprites in the Resourse/Type folders
        currentIndex = 0;
        count = 0;
        initalX = 0;
        string tempType = type.Substring(1, type.Length - 1);//tempType is the type of symbols without the "/" character used for file path
   
        foreach(GameObject button in buttons)//Gets rid of all old buttons
        {
            Destroy(button);
        }


        foreach (Sprite symbol in symbols)//For each symbol in the folder
        {
            
            GameObject container = Instantiate(TemplateButton) as GameObject;//Makes a new Button and casts it to a game object
            container.GetComponent<Image>().sprite = symbol;//Sets the sprite to the symbol
            container.GetComponent<ButtonVariables>().index = count;//Sets the index
            container.GetComponent<ButtonVariables>().name = symbol.name;//Sets the name

            switch (symbol.name)//Really big switch statment, not the best but didnt know how to store information
                //On sprites, The basic function to assign the values to Button Variables based on the name of the symbol
                //If no changes are made, new cases will have to be added for all new symbols
            {
                case "abundence":
                    container.GetComponent<ButtonVariables>().symbolName = "Bese Saka";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "A bunch of cola nuts";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Abundance";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Adaptability":
                    container.GetComponent<ButtonVariables>().symbolName = "Denkyem";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Crocodile";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "adaptability";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "adoration":
                    container.GetComponent<ButtonVariables>().symbolName = "Donno";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Bell Drum";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Adoration";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Affluence":
                    container.GetComponent<ButtonVariables>().symbolName = "Nserewa";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Cowry Shells";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Afluence";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Arrogance":
                    container.GetComponent<ButtonVariables>().symbolName = "Kuntun Kantan";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Inflated Pride";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Arrogance";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Authority":
                    container.GetComponent<ButtonVariables>().symbolName = "Adinkrahene";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "King of Adinkra Symbols";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Authority";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Bondage":
                    container.GetComponent<ButtonVariables>().symbolName = "Epa";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Handcuffs";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Law and Justice, Slavery and Captivity";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Bravery":
                    container.GetComponent<ButtonVariables>().symbolName = "Gyawu Atiko";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "War Hero's Hairstyle";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Bravery";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Brotherhood":
                    container.GetComponent<ButtonVariables>().symbolName = "Nkonosonkonson";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Chain Link";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Brotherhood";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Confidence":
                    container.GetComponent<ButtonVariables>().symbolName = "Tabono";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Oars";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Confidence";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Cooperation":
                    container.GetComponent<ButtonVariables>().symbolName = "Kokuromotie";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Thumb";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Cooperation";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Cooperation-2":
                    container.GetComponent<ButtonVariables>().symbolName = "Nsa Ko, Na Nsa";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Hand go, Hand Come";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Cooperation";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Craftiness":
                    container.GetComponent<ButtonVariables>().symbolName = "Ananse Ntontan";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Spider's Web";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Wisdom, Creativity, Complexities of life";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Defiance":
                    container.GetComponent<ButtonVariables>().symbolName = "Aya";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Fern";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Endurance, Resourcefulness";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Democracy":
                    container.GetComponent<ButtonVariables>().symbolName = "Kuronti ne Akwamu";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Two Councils of State";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Democracy, Sharing Ideas, Taking Council";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "demoracy-2":
                    container.GetComponent<ButtonVariables>().symbolName = "Mpuankron";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Nine Tufts of Hair";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Democracy";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Devotion":
                    container.GetComponent<ButtonVariables>().symbolName = "Odo Nnyew Fie";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Love never loses its way Home";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Power of Love";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Discipline":
                    container.GetComponent<ButtonVariables>().symbolName = "Ani Bere A Enso";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Red Eyes Can't spark flames";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Discipline";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Divinity":
                    container.GetComponent<ButtonVariables>().symbolName = "Asase ye Duru";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "The Earth has Weight";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "The Divinity of Mother Earth";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Exemplary-Leadership":
                    container.GetComponent<ButtonVariables>().symbolName = "Ohene Papa";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Good King";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Exemplary Leadership";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Experience":
                    container.GetComponent<ButtonVariables>().symbolName = "Kyemfere";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Potsherds";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Experience";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Faith":
                    container.GetComponent<ButtonVariables>().symbolName = "Nya Gyidie";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Have Faith";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Faith";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Faith-in-God":
                    container.GetComponent<ButtonVariables>().symbolName = "Nyame Biribi Wo Soro";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "God is in the Heavens";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Hope";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Family-Unity":
                    container.GetComponent<ButtonVariables>().symbolName = "Abusua Pa";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Good Family";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Family Unity";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Farewell":
                    container.GetComponent<ButtonVariables>().symbolName = "Yebehyia";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "We Shall meet again";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Farewell";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Farewell-2":
                    container.GetComponent<ButtonVariables>().symbolName = "Nante Yie";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Goodbye";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Farewell";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Fate":
                    container.GetComponent<ButtonVariables>().symbolName = "Nkrabea";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Destiny";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Fate";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Fearlessness":
                    container.GetComponent<ButtonVariables>().symbolName = "Pempamsie";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Sew in Readiness";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Readiness, Steadfastness, Hardiness";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Femininity":
                    container.GetComponent<ButtonVariables>().symbolName = "Duafe";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Wooden Comb";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Beauty, Cleanliness, desirable feminine qualities";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Fortitude":
                    container.GetComponent<ButtonVariables>().symbolName = "Mframadan";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Wind Resistant House";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Fortitude";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Friendship":
                    container.GetComponent<ButtonVariables>().symbolName = "Nnampo Pa Baanu";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Two Good friends";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Friendship";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Gods-Blessing":
                    container.GetComponent<ButtonVariables>().symbolName = "Nyame Nti";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "By God's Grace";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Faith and Trust in God";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Gods-Creations":
                    container.GetComponent<ButtonVariables>().symbolName = "Osiadan Nyame";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "God the Builder";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "God's Creations";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Gods-Guidance":
                    container.GetComponent<ButtonVariables>().symbolName = "Nyame Nnwu Na Mawu";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "God Never dies, therfore I cannot die";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "God's omnipresence";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Gods-Minipresence":
                    container.GetComponent<ButtonVariables>().symbolName = "Abode Santann";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "All Seeing Eye";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "God's Omnipresence";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Gods-Omnipotence":
                    container.GetComponent<ButtonVariables>().symbolName = "Gye Nyame";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Except for God";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Supremecy of God";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Gods-Protection":
                    container.GetComponent<ButtonVariables>().symbolName = "Nyame Dua";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Tree of God";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "God's Protection";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Good-Luck":
                    container.GetComponent<ButtonVariables>().symbolName = "Mmusuyidee";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "The which removes bad luck";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Good fortune";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Harmony":
                    container.GetComponent<ButtonVariables>().symbolName = "Mpatapo";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Knot of Pacification and Reconciliation";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Peacemaking and Pacification";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Harmony-2":
                    container.GetComponent<ButtonVariables>().symbolName = "Obi Nka Bi";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Bite not each other";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Harmony";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Heroic-Deeds":
                    container.GetComponent<ButtonVariables>().symbolName = "Akofena";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Sword of War";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Courage, valor, heroism";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Hypocrisy":
                    container.GetComponent<ButtonVariables>().symbolName = "Kramo Bone";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Unfaithful";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Hypocrisy";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Inequality":
                    container.GetComponent<ButtonVariables>().symbolName = "Maki Nyinaa";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "All peppers";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Inequality";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Ingenuity":
                    container.GetComponent<ButtonVariables>().symbolName = "Owo Foro Adobe";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Snake climing the raffia tree";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Steadfafstness, prudence, diligence";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "ingratitude":
                    container.GetComponent<ButtonVariables>().symbolName = "Anyi Me Aye A";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "If you will not praise me";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Ingratitude";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Interdependence":
                    container.GetComponent<ButtonVariables>().symbolName = "Ese Ne Tekrema";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "The Teeth and Tounge";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Interdependence";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Jealousy":
                    container.GetComponent<ButtonVariables>().symbolName = "Fofo";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "yellow flowered plant";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Jealousy, envy";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Joy-of-Living":
                    container.GetComponent<ButtonVariables>().symbolName = "Gye W'ani";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Enjoy yourself";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Joy of Living";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Justice":
                    container.GetComponent<ButtonVariables>().symbolName = "Sepo";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Executioner's Knife";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Justice";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Knowledge":
                    container.GetComponent<ButtonVariables>().symbolName = "Nea Onnim No Sua A, Ohu";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "He who does not know can know from learning";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Knowledge, Life-long Education";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Leadership":
                    container.GetComponent<ButtonVariables>().symbolName = "Esono Anantam";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Elephant's Footprint";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Leadership";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Legality":
                    container.GetComponent<ButtonVariables>().symbolName = "Mmara Krado";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Seal of Law";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Legality";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Life-Transformation":
                    container.GetComponent<ButtonVariables>().symbolName = "Sesa Wo Suban";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Change or Transform your Character";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Life transformation";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Lifes-Challenges":
                    container.GetComponent<ButtonVariables>().symbolName = "Mrammuo";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Crossing paths";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Life's Challenges";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Loyalty":
                    container.GetComponent<ButtonVariables>().symbolName = "Agyin Dawuru";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Agyin's Gong";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Loyalty";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Loyalty-2":
                    container.GetComponent<ButtonVariables>().symbolName = "Nkotimsefo Mpua";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Loyalty";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Majesty-of-God":
                    container.GetComponent<ButtonVariables>().symbolName = "Nyame Ye Ohene";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "God is King";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Majesty of God";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Maternal-Love":
                    container.GetComponent<ButtonVariables>().symbolName = "Obaatan Awaamu";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Mother's Warm Embrace";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Maternal Love";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Morality":
                    container.GetComponent<ButtonVariables>().symbolName = "Owuo Atwedee";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "The ladder of Death";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Morality";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Nurturing-Spirit":
                    container.GetComponent<ButtonVariables>().symbolName = "Awurade";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Got the Mother";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Nurturing Spirit";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Patronage":
                    container.GetComponent<ButtonVariables>().symbolName = "Boafo Ye Na";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Willing Helper";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Patronage";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Patronage-2":
                    container.GetComponent<ButtonVariables>().symbolName = "Nsoromma";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Child of the heavens";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Guardianship";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Permanence":
                    container.GetComponent<ButtonVariables>().symbolName = "Hye Wonhye";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "That which cannot be burnt";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Endurance";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Poetic-Eloquence":
                    container.GetComponent<ButtonVariables>().symbolName = "Donno Ntoaso";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Talking Drum";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Poetic-Eloquence";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Power":
                    container.GetComponent<ButtonVariables>().symbolName = "Okodee Mmowere";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Talons of the Eagle";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Strength, bravery, power";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Praise":
                    container.GetComponent<ButtonVariables>().symbolName = "Mo No Yo";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Congradulations";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Praise";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Precious-Treasure":
                    container.GetComponent<ButtonVariables>().symbolName = "Obohemma";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Diamond";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Precious Treasure";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Precision":
                    container.GetComponent<ButtonVariables>().symbolName = "Nkyimu";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "The crossed divisions made on adinkra cloth before stamping";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Precision";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Preserverance":
                    container.GetComponent<ButtonVariables>().symbolName = "Wawa Aba";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Seed of the Wawa tree";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Hardiness, toughness, perserverance";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Progress":
                    container.GetComponent<ButtonVariables>().symbolName = "Owia A Repue";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Rising Sun";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Progress";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Prosperity":
                    container.GetComponent<ButtonVariables>().symbolName = "Asetena Pa";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Good Living";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Prosperity";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Protection":
                    container.GetComponent<ButtonVariables>().symbolName = "Eban";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Fence";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Love, safety, security";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Protection-1":
                    container.GetComponent<ButtonVariables>().symbolName = "Tuo Ne Akofena";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Gun and State Sword";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Protection";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "prudence":
                    container.GetComponent<ButtonVariables>().symbolName = "Mate Masie";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "What I hear, I keep";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Wisdome, Knowledge, prudence";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Recognition":
                    container.GetComponent<ButtonVariables>().symbolName = "Mekyia Wo";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "I salute you";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Recognition";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Royal-Power":
                    container.GetComponent<ButtonVariables>().symbolName = "Ohene Kye";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "King's Crown";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Royal Power";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Royal-Protection":
                    container.GetComponent<ButtonVariables>().symbolName = "Ohene Kyiniie";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "King's Umbrella";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Royal Protection";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Seat-of-Government":
                    container.GetComponent<ButtonVariables>().symbolName = "Aban";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Great Fortress";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Seat of Government";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Security":
                    container.GetComponent<ButtonVariables>().symbolName = "Fihankra";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "House/Compound";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Security/ safety";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Serenity":
                    container.GetComponent<ButtonVariables>().symbolName = "Adwo";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Peace";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Serenity";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Spiritual-Loyalty":
                    container.GetComponent<ButtonVariables>().symbolName = "Mpuannum";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Five tufts of hair";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Spiritual loyalty";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Standard-of-Quality":
                    container.GetComponent<ButtonVariables>().symbolName = "Hwe Mu Dua";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Measuring stick";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Quality Control";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Strategy":
                    container.GetComponent<ButtonVariables>().symbolName = "Dame-Dame";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Name of a board game";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Intelligence, ingenuity, strategy";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Strength":
                    container.GetComponent<ButtonVariables>().symbolName = "Dwannini Mmen";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Ram's horns";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Strength, Humility";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Superirority":
                    container.GetComponent<ButtonVariables>().symbolName = "Nkuruma Kesee";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Big Okra";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Superirority";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Sweetness":
                    container.GetComponent<ButtonVariables>().symbolName = "Asaawa";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Sweet Berry";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Sweetness";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Tenderness":
                    container.GetComponent<ButtonVariables>().symbolName = "Fafanto";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Butterfly";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Tenderness";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Togetherness":
                    container.GetComponent<ButtonVariables>().symbolName = "Akoma Ntoso";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Linked Hearts";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Understanding and Agreements";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Toughness":
                    container.GetComponent<ButtonVariables>().symbolName = "Nkyinkyim";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Twisting";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Initiative, dynamism, versatility";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Unity":
                    container.GetComponent<ButtonVariables>().symbolName = "Funtunfunefu-Denkyemfunefu";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Siamese crocodiles";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Unity, democracy";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Valor":
                    container.GetComponent<ButtonVariables>().symbolName = "Akoben";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "War Horn";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Vigilance, wariness";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Veracity":
                    container.GetComponent<ButtonVariables>().symbolName = "Nokore";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Truth";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Veracity";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Wisdom":
                    container.GetComponent<ButtonVariables>().symbolName = "Sankofa";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Return and Get it";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Wisdom";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                case "Wise-Leadership":
                    container.GetComponent<ButtonVariables>().symbolName = "Nyansapo";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "Wisdom Knot";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "Wise Leadership, ingenuity";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Adinkra: African symbols from Ghana";
                    break;
                //--------------------------
                case "Butterfly":
                    container.GetComponent<ButtonVariables>().symbolName = "Butterfly";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "butterfly1":
                    container.GetComponent<ButtonVariables>().symbolName = "Butterfly";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "Clouds":
                    container.GetComponent<ButtonVariables>().symbolName = "Clouds";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "diamond1":
                    container.GetComponent<ButtonVariables>().symbolName = "Diamond";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "dragon":
                    container.GetComponent<ButtonVariables>().symbolName = "Dragon";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "dragon1":
                    container.GetComponent<ButtonVariables>().symbolName = "Dragon";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "dragon_fly":
                    container.GetComponent<ButtonVariables>().symbolName = "Dragon Fly";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "Eye":
                    container.GetComponent<ButtonVariables>().symbolName = "Eye";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "face":
                    container.GetComponent<ButtonVariables>().symbolName = "Face";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "flower":
                    container.GetComponent<ButtonVariables>().symbolName = "flower";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "hibiscus_flower":
                    container.GetComponent<ButtonVariables>().symbolName = "Hibiscus Flower";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "koi_fish":
                    container.GetComponent<ButtonVariables>().symbolName = "Koi Fish";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "lotus_flower":
                    container.GetComponent<ButtonVariables>().symbolName = "Lotus Flower";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "moon":
                    container.GetComponent<ButtonVariables>().symbolName = "Moon";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "Peace":
                    container.GetComponent<ButtonVariables>().symbolName = "Peace";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "rose":
                    container.GetComponent<ButtonVariables>().symbolName = "Rose";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "Seahorse":
                    container.GetComponent<ButtonVariables>().symbolName = "Seahorse";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "ShiningStar":
                    container.GetComponent<ButtonVariables>().symbolName = "Shining Star";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "Shooting Star":
                    container.GetComponent<ButtonVariables>().symbolName = "Shooting Star";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "SmallSun":
                    container.GetComponent<ButtonVariables>().symbolName = "Small Sun";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "star":
                    container.GetComponent<ButtonVariables>().symbolName = "Star";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "stars":
                    container.GetComponent<ButtonVariables>().symbolName = "Stars";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "Sun":
                    container.GetComponent<ButtonVariables>().symbolName = "Sun";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "Sun with Face":
                    container.GetComponent<ButtonVariables>().symbolName = "Sun";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "Sun2":
                    container.GetComponent<ButtonVariables>().symbolName = "Sun";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "sun3":
                    container.GetComponent<ButtonVariables>().symbolName = "Sun";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "turtle":
                    container.GetComponent<ButtonVariables>().symbolName = "Turtle";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "turtle2":
                    container.GetComponent<ButtonVariables>().symbolName = "Turtle";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "WhatIsThis":
                    container.GetComponent<ButtonVariables>().symbolName = "Misc";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "X-Star":
                    container.GetComponent<ButtonVariables>().symbolName = "Star";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                case "yin_yang":
                    container.GetComponent<ButtonVariables>().symbolName = "Ying Yang";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;
                //-----------------------------------------
                case "Sacred-1":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-1";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-2":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-2";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-3":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-3";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-4":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-4";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-5":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-5";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-6":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-6";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-7":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-7";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-8":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-8";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-9":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-9";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-10":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-10";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-11":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-11";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-12":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-12";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-13":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-13";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-14":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-14";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                case "Sacred-15":
                    container.GetComponent<ButtonVariables>().symbolName = "Sacred-15";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "Universal Patterns woven into the fabric of nature";
                    break;
                default:
                    container.GetComponent<ButtonVariables>().symbolName = "";
                    container.GetComponent<ButtonVariables>().symbolLiteral = "";
                    container.GetComponent<ButtonVariables>().symbolMeaning = "";
                    container.GetComponent<ButtonVariables>().typeMeaning = "";
                    break;

            }
            if (count == 0)//Final check
            {
                string newStr = container.GetComponent<ButtonVariables>().symbolName;
                if(container.GetComponent<ButtonVariables>().symbolLiteral != "")
                {
                    newStr = newStr + "(" + container.GetComponent<ButtonVariables>().symbolLiteral + ")";
                }
                labelName.GetComponent<Text>().text = newStr;
                labelMeaning.GetComponent<Text>().text = container.GetComponent<ButtonVariables>().symbolMeaning;
                labelType.GetComponent<Text>().text = container.GetComponent<ButtonVariables>().typeMeaning;
            }

            container.transform.SetParent(SelectPanel.transform, false);
            container.GetComponent<Button>().onClick.AddListener(() => switchBrush(symbol.name));
            count++;
        }
        Vector3 newPos;
        if(tempType == "Adinkra")//Sets the position of the SelectPannel based on the type, not always consititant hence there even an if statement
        {
            newPos = new Vector3(92f * (count / 2), 5f, 0);
        }
        else
        {
            newPos = new Vector3(93f * (count / 2), 5f, 0);
        }
     
        initalX = newPos.x;
        SelectPanel.GetComponent<RectTransform>().localPosition = newPos;
        buttons = GameObject.FindGameObjectsWithTag("tempButton");
        currentIndex = 0;
       


        
    }


    public void selLeft()//Function for the left arrow to navagate the select panel
    {
        if(currentIndex > 0)
        { 
        currentIndex--;
        Vector3 newPos = new Vector3(SelectPanel.GetComponent<RectTransform>().localPosition.x +93f, 5f, 0);
        SelectPanel.GetComponent<RectTransform>().localPosition = newPos;
        }
    }
    public void selRight()//Function for the right arrow to navagate the select panel
    {
        if(currentIndex < count-1)
        {
            currentIndex++;
            Vector3 newPos = new Vector3(SelectPanel.GetComponent<RectTransform>().localPosition.x - 93f, 5f, 0);
            SelectPanel.GetComponent<RectTransform>().localPosition = newPos;
        }
    }
    public void switchBrush(string name)//Changes brush name in the Texture painter;
    {
        GameObject[] tps = GameObject.FindGameObjectsWithTag("TP");
        foreach(GameObject tp in tps)
        {
            if (tp.activeSelf)
            {
                tp.GetComponent<TexturePainter>().brush = name;
            }
        }
        Scripts.GetComponent<ButtonBehaviors>().symbolsBoxCheck();//Makes sure the symbolx box is gone from screen
    }
}
