using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Stats
{
    Strength,
    Constitution,
    Dexterity,
    Agilety,
    Intelligence,
    Wisdom
}
public class Equipment : ScriptableObject {
    [SerializeField]
    private Stats _Stat;
    [SerializeField]
    private int Amount;
	
}
