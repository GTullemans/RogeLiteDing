using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turn : MonoBehaviour {
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
    private history _history;
    [SerializeField]
    private GameObject creddo;
    // Use this for initialization
    void Start () {
        _history = new history();
	}
	
	// Update is called once per frame
	void Update () {
        _dispdeck.text = "" + deckcrds.Count;
        _dispgrave.text = "" + gravecrds.Count;
        _dispexil.text = "" + exilcrds.Count;
        _disphand.text = "" + handcrds.Count;
        if (Input.GetKeyDown(KeyCode.A))
        {
            _history.addAcard(creddo,deckcrds,0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _history.moveAcard(deckcrds, 0, hndcrd, 0);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            _history.windback();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            _history.windforward();
        }
    }

   

   
}



public interface turnupdate
{
   void startturn();
   void endturn();
   void duringturn();
   void stackeffect();
}

public class playerturn : turnupdate
{
    public playerturn()
    {

    }
    public void startturn()
    {

    }
    public void endturn()
    {

    }
    public void duringturn()
    {

    }
    public void stackeffect()
    {

    }
}
public class enemyturn : turnupdate
{
    public enemyturn()
    {

    }
    public void startturn()
    {

    }
    public void endturn()
    {

    }
    public void duringturn()
    {

    }
    public void stackeffect()
    {

    }
}
