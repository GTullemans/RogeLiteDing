﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hand : MonoBehaviour {
    [SerializeField]
    private List<GameObject> handcrds; public List<GameObject> hndcrd { get { return (handcrds); } set { handcrds = value; } }
    [SerializeField]
    private List<GameObject> deckcrds; public List<GameObject> dckcrd { get { return (deckcrds); } set { deckcrds = value; } }
    [SerializeField]
    private List<GameObject> exilcrds; public List<GameObject> xlcrd { get { return (exilcrds); } set { exilcrds = value; } }
    [SerializeField]
    private List<GameObject> gravecrds; public List<GameObject> grvcrd { get { return (gravecrds); } set { gravecrds = value; } }
    [SerializeField]
    private List<GameObject> stckcrds; public List<GameObject> stkcrd { get { return (stckcrds); } set { stckcrds = value; } }
    [SerializeField]
    private Text _disphand;
    [SerializeField]
    private Text _dispdeck;
    [SerializeField]
    private Text _dispgrave;
    [SerializeField]
    private Text _dispexil;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        _dispdeck.text = "" + deckcrds.Count;
        _dispgrave.text = "" + gravecrds.Count;
        _dispexil.text = "" + exilcrds.Count;
        _disphand.text = "" + handcrds.Count;
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject blop = new GameObject(); Instantiate(blop);
            deckcrds.Add(blop);
        }
    }

   

   
}



//public interface turn
//{
//    void startturn();
//    void endturn();
//    void duringturn();
//    void stackeffect();
//}

//public class playerturn : turn