using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "effect build")]
public class effectbuilder : ScriptableObject {

   
    [SerializeField]
    private bool pressistant; public bool _pressistant { get { return (pressistant); } set { pressistant = value; } }
    [SerializeField]
    private bool hastriggeredeffect; public bool _hastriggeredeffect { get { return (hastriggeredeffect); } set { hastriggeredeffect = value; } }
    [SerializeField]
    private bool overridinginstantontrigger; public bool _instant { get { return (overridinginstantontrigger); } set { overridinginstantontrigger = value; } }
    [SerializeField]
    private string triggertype; public string _triggertype { get { return (triggertype); } set { triggertype = value; } }
    [SerializeField]
    private bool hasResolveEffect; public bool _hasResolveEffect { get { return (hasResolveEffect); } set { hasResolveEffect = value; } }
    [SerializeField]
    private string typeResolveEffect; public string _typeResolveEffect { get { return (typeResolveEffect); } set { typeResolveEffect = value; } }
    [SerializeField]
    private bool hasmultipletriggeredEffects; public bool _hasmultipletriggeredEffects { get { return (hasmultipletriggeredEffects); } set { hasmultipletriggeredEffects = value; } }    
    [SerializeField]
    private string[] multipletriggeredEffects; public string[] _multipletriggeredEffects { get { return (multipletriggeredEffects); } set { multipletriggeredEffects = value; } }
    [SerializeField]
    private bool hasmultipleResolveEffects; public bool _hasmultipleResolveEffects { get { return (hasmultipleResolveEffects); } set { hasmultipleResolveEffects = value; } }
    [SerializeField]
    private string[] multipleResolveEffects; public string[] _multipleResolveEffects { get { return (multipleResolveEffects); } set { multipleResolveEffects = value; } }

}
