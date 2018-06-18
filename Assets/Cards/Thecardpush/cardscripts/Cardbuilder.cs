using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card build")]
public class Cardbuilder : ScriptableObject {

    [SerializeField]
    private string cardname; public string _cardname { get { return (cardname); } set { cardname = value; } }
    [SerializeField]
    private Sprite cardsprite; public Sprite _cardsprite { get { return (cardsprite); } set { cardsprite = value; } }
    [SerializeField]
    private int cardclass; public int _cardclass { get { return (cardclass); } set { cardclass = value; } }
    [SerializeField]
    private int cardtype; public int _cardtype { get { return (cardtype); } set { cardtype = value; } }
    [SerializeField]
    private int cardcost; public int _cardcost { get { return (cardcost); } set { cardcost = value; } }
    [SerializeField]
    [TextArea(15, 20)]
    private string cardtext; public string _cardtext { get { return (cardtext); } set { cardtext = value; } }
    [SerializeField]
    private float[] cardscaling; public float[] _cardscaling { get { return (cardscaling); } set { cardscaling = value; } }
    [SerializeField]
    private effectbuilder[] cardeffects; public effectbuilder[] _cardeffects { get { return (cardeffects); } set { cardeffects = value; } }
}
