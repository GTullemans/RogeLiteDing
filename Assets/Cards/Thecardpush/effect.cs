using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect
{

    [SerializeField]
    private effectbuilder ecktbuild;
    private bool pressistant; public bool _pressistant { get { return (pressistant); } set { pressistant = value; } }
    private string triggerType;
    private bool instant; public bool _instant { get { return (instant); } set { instant = value; } }
    private bool hasTriggeredEffect; public bool _hasTriggeredEffect { get { return (hasTriggeredEffect); } set { hasTriggeredEffect = value; } }
    private bool hasResolveEffect; public bool _hasResolveEffect { get { return (hasResolveEffect); } set { hasResolveEffect = value; } }
    private string TypeResolveEffect; public string _TypeResolveEffect { get { return (TypeResolveEffect); } set { TypeResolveEffect = value; } }
    public effect(effectbuilder _ecktbuild)
    {
        ecktbuild = _ecktbuild;
        pressistant = _ecktbuild._pressistant;
        hasResolveEffect = _ecktbuild._hasResolveEffect;
        hasTriggeredEffect = _ecktbuild._hastriggeredeffect;
        if (_ecktbuild._hastriggeredeffect)
        {
            triggerType = _ecktbuild._triggertype;
            instant = _ecktbuild._instant;
        }
        if (_ecktbuild._hasResolveEffect)
        {
            TypeResolveEffect = _ecktbuild._typeResolveEffect;
        }
    }

    public bool check(string triggercheck)
    {
        if (hasTriggeredEffect)
        {
            if (triggerType == triggercheck)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        else
        {
            return (false);
        }
    }
    public void resolve(history story, turn boss)
    {
        if(TypeResolveEffect == "Draw"){
            if(boss.dckcrd.Count != 0)
            {
                story.moveAcard(boss.dckcrd, 0, boss.hndcrd, 0);
            }
        }
        else if(TypeResolveEffect == "Discard Random")
        {
            if(boss.hndcrd.Count != 0)
            {
                story.moveAcard(boss.hndcrd, Mathf.FloorToInt(Random.Range(0, boss.hndcrd.Count - 0.5f)), boss.grvcrd, 0);
            }
        }
        else if (TypeResolveEffect == "Refill Deck")
        {
            if (boss.dckcrd.Count == 0 && boss.grvcrd.Count > 0)
            {
                while (boss.grvcrd.Count > 0)
                {
                    story.moveAcard(boss.grvcrd, Mathf.FloorToInt(Random.Range(0, boss.grvcrd.Count - 0.5f)), boss.dckcrd, 0);
                }
            }
        }
        else if (TypeResolveEffect == "Resolve")
        {

        }
        else if (TypeResolveEffect == "Play")
        {

        }
        
        
    }

}
