using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void drw(List<GameObject> van,List<GameObject> naar, int aantal)
    {
        int boi = 0;
        for (int i = 0; i < aantal; i++)
        {
            if (van.Count != 0)
            {
                boi = Random.Range(0, van.Count);
                naar.Add(van[boi]);
                van.RemoveAt(boi);
            }
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