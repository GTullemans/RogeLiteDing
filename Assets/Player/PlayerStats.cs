using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    [SerializeField]
    private int _Strength;
    [SerializeField]
    private int _Constitution;
    [SerializeField]
    private int _Dexterity;
    [SerializeField]
    private int _Agilety;
    [SerializeField]
    private int _Intelligence;
    [SerializeField]
    private int _Wisdom;

    public void SetClass(Classes_SO Class)
    {
        _Strength     = Class.Strength;
        _Constitution = Class.Constitution;
        _Dexterity    = Class.Dexterity;
        _Agilety      = Class.Agilety;
        _Intelligence = Class.Intelligence;
        _Wisdom       = Class.Wisdom;

    }




    public int GSStrength
    {
        get { return _Strength; }
        set { _Strength = value; }
    }

    public int GSConstitution
    {
        get { return _Constitution; }
        set { _Constitution = value; }
    }

    public int GSDexterity
    {
        get { return _Dexterity; }
        set { _Dexterity = value; }
    }

    public int GSAgilety
    {
        get { return _Agilety; }
        set { _Agilety = value; }
    }

    public int GSIntelligence
    {
        get { return _Intelligence; }
        set { _Intelligence = value; }
    }

    public int GSWisdom
    {
        get { return _Wisdom; }
        set { _Wisdom = value; }
    }


}
