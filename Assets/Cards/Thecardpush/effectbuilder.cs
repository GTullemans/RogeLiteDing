﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "effect build")]
public class effectbuilder : ScriptableObject {

   
    [SerializeField]
    private bool pressistant; public bool _pressistant { get { return (pressistant); } set { pressistant = value; } }
    [SerializeField]
    private bool hastriggeredeffect; public bool _hastriggeredeffect { get { return (hastriggeredeffect); } set { hastriggeredeffect = value; } }   
    [SerializeField]
    private string triggertype; public string _triggertype { get { return (triggertype); } set { triggertype = value; } }
    [SerializeField]
    private bool hasResolveEffect; 
    [SerializeField]
    private string typeResolveEffect;
    
        



    
}
