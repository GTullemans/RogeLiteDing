using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDingen : MonoBehaviour {

    private movecard CartMove;
    [SerializeField]
    private GameObject ZoneManager;
    [SerializeField]
    private Transform HandPosition;
    [SerializeField]
    private Text _EnergyDisplay;
    private int _Energy;
    public int Energy { get { return _Energy; } set { _Energy = value; } }


    private List<GameObject> _Deck;
    private List<GameObject> _Hand;
    private List<GameObject> _Graf;
    private List<GameObject> _Exile;

  
    // Use this for initialization
    void Start () {
        _Deck = new List<GameObject>(ZoneManager.GetComponent<hand>().dckcrd);
        _Hand = new List<GameObject>(ZoneManager.GetComponent<hand>().hndcrd);
        _Graf = new List<GameObject>(ZoneManager.GetComponent<hand>().grvcrd);
        _Exile = new List<GameObject>(ZoneManager.GetComponent<hand>().xlcrd);

        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_Deck != null && _Deck.Count != 0)
            {
                
                _Deck[0].transform.position =new  Vector3(HandPosition.position.x + 1.3f*_Hand.Count, HandPosition.position.y, HandPosition.position.z);
                CartMove = new movecard(_Deck, 0, _Hand, _Hand.Count);
                CartMove.Execute();
                               
            }
        }
	}

    
}
