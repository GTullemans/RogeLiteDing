using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour {

    [SerializeField]
    private effectbuilder ecktbuild;
    private bool pressistant;
    private string triggerType;
    private bool hasTriggeredEffect;

    void Start()
    {
        pressistant = ecktbuild._pressistant;
        hasTriggeredEffect = ecktbuild._hastriggeredeffect;
        triggerType = ecktbuild._triggertype;
    }


    public void check(string triggercheck)
    {
        if (hasTriggeredEffect)
        {
            if(triggerType == triggercheck)
            {

            }
        }
    }

}
