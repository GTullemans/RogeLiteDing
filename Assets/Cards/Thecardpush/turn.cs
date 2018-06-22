using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turn : MonoBehaviour {
    [SerializeField]
    private List<GameObject> handcrds = new List<GameObject>(); public List<GameObject> hndcrd { get { return (handcrds); } set { handcrds = value; } }
    [SerializeField]
    private List<GameObject> deckcrds = new List<GameObject>(); public List<GameObject> dckcrd { get { return (deckcrds); } set { deckcrds = value; } }
    [SerializeField]
    private List<GameObject> exilcrds = new List<GameObject>(); public List<GameObject> xlcrd { get { return (exilcrds); } set { exilcrds = value; } }
    [SerializeField]
    private List<GameObject> gravecrds = new List<GameObject>(); public List<GameObject> grvcrd { get { return (gravecrds); } set { gravecrds = value; } }
    [SerializeField]
    private List<GameObject> stckcrds = new List<GameObject>(); public List<GameObject> stkcrd { get { return (stckcrds); } set { stckcrds = value; } }

    private List<effect> rslngeffectstack = new List<effect>(); public List<effect> _rslngeffectstack{ get { return (rslngeffectstack); } set { rslngeffectstack = value; } }
    private List<effect> trgrdeffectstack = new List<effect>();
    

    [SerializeField]
    private Text _disphand;
    [SerializeField]
    private Text _dispdeck;
    [SerializeField]
    private Text _dispgrave;
    [SerializeField]
    private Text _dispexil;

    [SerializeField]
    private GameObject creddo;

    private history _history;
    private effect _effect;
    private List<turnupdate> turnlist = new List<turnupdate>();
    private playerturn _playerturn;
    private enemyturn _enemyturn;
    private int currenturn =0;


    [SerializeField]
    private effectbuilder testdeckrefill;
    [SerializeField]
    private effectbuilder testranddiscard;
    [SerializeField]
    private effectbuilder testdraw;
    // Use this for initialization

    void Start () {
        _history = new history(this);
        _playerturn = new playerturn(this);
        _enemyturn = new enemyturn(this);
        turnlist.Add(_playerturn); turnlist.Add(_enemyturn);
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
            makeeffect(testdraw);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            makeeffect(testranddiscard);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            makeeffect(testdeckrefill);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            _history.windback();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            _history.windforward();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(rslngeffectstack.Count + " = resolve stack.");
            Debug.Log(trgrdeffectstack.Count + " = trigger stack.");
        }
        duringtheturn();
    }
    public void makeeffect(effectbuilder builed)
    {
        _effect = new effect(builed);
        if (_effect._hasTriggeredEffect == true)
        {
            trgrdeffectstack.Add(_effect);
        }
        else
        {
            rslngeffectstack.Add(_effect);
        }
    }
    public void duringtheturn()
    {
        if (turnlist[currenturn] != null)
        {
            turnlist[currenturn].duringturn();
        }
    }
    public void changeturn(int i)
    {
        turnlist[currenturn].endturn();
        turnlist[i].startturn();
        currenturn = i;
    }
    public void checkeffects(string criteria)
    {
        for(int i=0; i<trgrdeffectstack.Count; i++)
        {
            if (trgrdeffectstack[i].check(criteria))
            {
                if (trgrdeffectstack[i]._instant)
                {
                    trgrdeffectstack[i].resolve(_history,this);
                    if (trgrdeffectstack[i]._pressistant != true)
                    {
                        trgrdeffectstack.Remove(trgrdeffectstack[i]);
                        i--;
                    }
                }
                else
                {
                    rslngeffectstack.Add(trgrdeffectstack[i]);
                    if (trgrdeffectstack[i]._pressistant != true)
                    {
                        trgrdeffectstack.Remove(trgrdeffectstack[i]);
                        i--;
                    }
                }
                
            }
        }
    }
    public void resolveeffects()
    {
        effect placeholder = rslngeffectstack[rslngeffectstack.Count - 1];
        checkeffects("Before " + placeholder._TypeResolveEffect);
        placeholder.resolve(_history,this);
        rslngeffectstack.Remove(placeholder);
        checkeffects("After " + placeholder._TypeResolveEffect);
    }

    public GameObject instantiateHack(GameObject target)
    {
        return (Instantiate(target));
    }
    public void destroyHack(GameObject target)
    {
        Destroy(target);
    }
}



public interface turnupdate
{
   void startturn();
   void endturn();
   void duringturn();
}

public class playerturn : turnupdate
{
    private turn boss;
    public playerturn(turn _boss)
    {
        boss = _boss;
    }
    public void startturn()
    {
        boss.checkeffects("Start of player turn");
    }
    public void endturn()
    {
        boss.checkeffects("End of player turn");
    }
    public void duringturn()
    {
        
        if(boss._rslngeffectstack.Count > 0) {
            boss.resolveeffects();
        }
        
    }
}
public class enemyturn : turnupdate
{
    private turn boss;
    public enemyturn(turn _boss)
    {
        boss = _boss;
    }
    public void startturn()
    {
        boss.checkeffects("Start of enemy turn");
    }
    public void endturn()
    {
        boss.checkeffects("End of enemy turn");
    }
    public void duringturn()
    {

    }
}
