 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

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
    private Text title;
    [SerializeField]
    private Text manacost;
    [SerializeField]
    private string[] allkeywords;
    [SerializeField]
    private string[] terminology;
    [SerializeField]
    private Canvas secondlayer;
    [SerializeField]
    private int layerorder; public int lay { get { return (layerorder); }
        set { layerorder = value; secondlayer.sortingOrder = layerorder + 1; gameObject.GetComponent<SortingGroup>().sortingOrder = layerorder; } }

    private float[] pwrscale;
    private GameObject owner; public GameObject _owner { get { return (owner); } set { owner = value; } }

    private string temporarytextsave;
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<SortingGroup>().sortingOrder = layerorder;
        secondlayer.sortingOrder = layerorder + 1;
        afbeelding.GetComponent<SpriteRenderer>().sprite = crdbuild._cardsprite;
        
        title.text = crdbuild._cardname;
        manacost.text = "" + crdbuild._cardcost;
        pwrscale = crdbuild._cardscaling;
        temporarytextsave = kwrdnote(crdbuild._cardtext);
        text.text = scaleupdate(temporarytextsave);

    }
	
	// Update is called once per frame
	void Update () {
	    
	}


    private string kwrdnote(string dinges)
    {
        bool bl = false;
        string savstrngKWRD = "";
        List<string> kwrds = new List<string>();

            foreach (char chr in dinges)
            {
                if (chr == '(')
                {
                    savstrngKWRD = "";
                    bl = true;
                }
                else if (chr == ')')
                {
                    kwrds.Add(savstrngKWRD);
                    bl = false;
                }
                else
                if (bl)
                {
                    savstrngKWRD += chr;
                }

            }
            foreach (string kword in kwrds)
            {
                dinges = dinges.Replace("(" + kword + ")", kword.ToUpper());
            }

        return (dinges);

    }
    private string scaleupdate(string dinges)
    {
        bool bl = false;
        string savstrngNUM = "";
        List<string> nums = new List<string>();

        foreach (char chr in dinges)
        {
            if (chr == '<')
            {
                savstrngNUM = "";
                bl = true;
            }
            else if (chr == '>')
            {
                nums.Add(savstrngNUM);
                bl = false;
            }
            else
            if (bl)
            {
                savstrngNUM += chr;
            }

        }
        int buffer = 0;
        foreach (string num in nums)
        {
            dinges = dinges.Replace("<" + num + ">", Mathf.Floor( int.Parse(num)+1*pwrscale[buffer] ) +"");
            buffer++;
        }
        return (dinges);
    }
}
