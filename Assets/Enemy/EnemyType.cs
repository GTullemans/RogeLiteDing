using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyType")]
public class EnemyType : ScriptableObject
{
    [SerializeField]
    private int _BaseHealth;
    public int BaseHealth
    {
        get { return _BaseHealth; }
    }

    //private List<GameObject> _Deck;
    //public List<GameObject> Deck
    //{
    //    get { return _Deck; }
    //}


    

}
