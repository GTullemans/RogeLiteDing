using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour {

    [SerializeField]
    private effectbuilder ecktbuild;
    private bool pressistant;
    private string triggerType;
    private bool hasTriggeredEffect;

    public effect(effectbuilder _ecktbuild)
    {
        ecktbuild = _ecktbuild;
    }

    /*
    void Start()
    {
        pressistant = ecktbuild._pressistant;
        hasTriggeredEffect = ecktbuild._hastriggeredeffect;
        triggerType = ecktbuild._triggertype;
    }
    */

    public void check(string triggercheck, history story)
    {
        if (hasTriggeredEffect)
        {
            if(triggerType == triggercheck)
            {
                
            }
        }
    }
    public void resolve(history story)
    {
        
    }

}
