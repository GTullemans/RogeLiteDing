using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes_SO : ScriptableObject {

    [SerializeField]
    private int _Strength;
    public int Strength
    {
        get { return _Strength; }
    }
    [SerializeField]
    private int _Constitution;
    public int Constitution
    {
        get { return _Constitution; }
    }
    [SerializeField]
    private int _Dexterity;
    public int Dexterity
    {
        get { return _Dexterity; }
    }
    [SerializeField]
    private int _Agilety;
    public int Agilety
    {
        get { return _Agilety; }
    }
    [SerializeField]
    private int _Intelligence;
    public int Intelligence
    {
        get { return _Intelligence; }
    }
    [SerializeField]
    private int _Wisdom;
    public int Wisdom
    {
       get { return _Wisdom; }
    }
}
