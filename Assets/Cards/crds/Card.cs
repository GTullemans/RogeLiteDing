 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    [SerializeField]
    private Cardbuilder crdbuild;
    [SerializeField]
    private GameObject afbeelding;
    [SerializeField]
    private GameObject afbeeldingvoortext;
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private GameObject manacost;
    [SerializeField]
    private string[] allkeywords;
    [SerializeField]
    private string[] terminology;
    


    

    // Use this for initialization
    void Start () {
        /*
        afbeelding.GetComponent<SpriteRenderer>().sprite = crdbuild._cardsprite;

        title.GetComponent<TextMesh>().text = crdbuild._cardname;
        text.GetComponent<TextMesh>().text = crdbuild._cardtext;
        manacost.GetComponent<TextMesh>().text = "" + crdbuild._cardcost;
        */
        text.text = spul(crdbuild._cardtext);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private string spul(string dinges)
    {
        bool bl = false;
        string savstrng = "";
        List<string> kwrds = new List<string>();
        foreach(char chr in dinges)
        {
            if(chr == '(')
            {
                savstrng = "";
                bl = true; 
            }
            else if(chr == ')')
            {
                kwrds.Add(savstrng);
                bl = false;
            }else
            if (bl)
            {
                savstrng += chr;
            }
        }

        foreach(string kword in kwrds)
        {
            dinges = dinges.Replace("(" + kword + ")", kword.ToUpper());
        }

       


        return (dinges);
    }
}
