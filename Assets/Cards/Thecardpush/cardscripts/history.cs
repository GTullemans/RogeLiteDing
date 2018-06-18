using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class history : MonoBehaviour {

    private List<ticks> klock = new List<ticks>();
    private movecard mvcrd;
    private addcard adcrd;
    private changehp cnghp;
    private changemaxhp cngmxhp;
    private sethp sthp;
    private setmaxhp stmxhp;
    private changemana cngmn;
    private changemaxmana cngmxmn;
    private setmana stmn;
    private setmaxmana stmxmn;
    private int currentTick =0;
    private List<effect> triggeredeffects = new List<effect>(); public List<effect> _effects { get { return (triggeredeffects); } set { triggeredeffects = value; } }

	void Start ()
    {
		
	}

	void Update ()
    {
        
    }

    public void moveAcard(List<GameObject> from, int frmindex, List<GameObject> to, int toindex)
    {
        mvcrd = new movecard(from, frmindex, to, toindex);
        mvcrd.Execute();
        if (klock.Count > currentTick)
        {
            klock.RemoveRange(currentTick, klock.Count - currentTick);
        }
        currentTick++;
        klock.Add(mvcrd);
    }
    public void addAcard(GameObject card, List<GameObject> to, int toindex)
    {
        adcrd = new addcard(card, to, toindex, this);
        adcrd.Execute();
        if(klock.Count > currentTick)
        {
            klock.RemoveRange(currentTick, klock.Count - currentTick);
        }
        currentTick++;
        klock.Add(adcrd);
    }
    public void changeAhealth(GameObject target, int amount)
    {
        cnghp = new changehp(target, amount);
        cnghp.Execute();
        if (klock.Count > currentTick)
        {
            klock.RemoveRange(currentTick, klock.Count - currentTick);
        }
        currentTick++;
        klock.Add(cnghp);
    }
    public void changeAmaxhealth(GameObject target, int amount)
    {
        cngmxhp = new changemaxhp(target, amount);
        cngmxhp.Execute();
        if (klock.Count > currentTick)
        {
            klock.RemoveRange(currentTick, klock.Count - currentTick);
        }
        currentTick++;
        klock.Add(cngmxhp);
    }
    public void setAhealth(GameObject target, int amount)
    {
        sthp = new sethp(target, amount);
        sthp.Execute();
        if (klock.Count > currentTick)
        {
            klock.RemoveRange(currentTick, klock.Count - currentTick);
        }
        currentTick++;
        klock.Add(sthp);
    }
    public void setAmaxhealth(GameObject target, int amount)
    {
        stmxhp = new setmaxhp(target, amount);
        stmxhp.Execute();
        if (klock.Count > currentTick)
        {
            klock.RemoveRange(currentTick, klock.Count - currentTick);
        }
        currentTick++;
        klock.Add(stmxhp);
    }
    public void changeAmana(GameObject target, int amount)
    {
        cngmn = new changemana(target, amount);
        cngmn.Execute();
        if (klock.Count > currentTick)
        {
            klock.RemoveRange(currentTick, klock.Count - currentTick);
        }
        currentTick++;
        klock.Add(cngmn);
    }
    public void changeAmaxmana(GameObject target, int amount)
    {
        cngmxmn = new changemaxmana(target, amount);
        cngmxmn.Execute();
        if (klock.Count > currentTick)
        {
            klock.RemoveRange(currentTick, klock.Count - currentTick);
        }
        currentTick++;
        klock.Add(cngmxmn);
    }
    public void setAmana(GameObject target, int amount)
    {
        stmn = new setmana(target, amount);
        stmn.Execute();
        if (klock.Count > currentTick)
        {
            klock.RemoveRange(currentTick, klock.Count - currentTick);
        }
        currentTick++;
        klock.Add(stmn);
    }
    public void setAmaxmana(GameObject target, int amount)
    {
        stmxmn = new setmaxmana(target, amount);
        stmxmn.Execute();
        if (klock.Count > currentTick)
        {
            klock.RemoveRange(currentTick, klock.Count - currentTick);
        }
        currentTick++;
        klock.Add(stmxmn);
    }

    public void windback()
    {
        if(klock.Count > 0 && klock.Count >= currentTick && currentTick >0)
        {
            klock[currentTick - 1].Undo();
            currentTick--;
        }
    }
    public void windforward()
    {
        if(klock.Count > currentTick)
        {
            klock[currentTick].Execute();
            currentTick++;
        }
    }


    public GameObject instantiateHack(GameObject target)
    {
       return(Instantiate(target));
    }
    public void destroyHack(GameObject target)
    {
        Destroy(target);
    }
}


public interface ticks
{
    void Execute();
    void Undo();
}

public class movecard : ticks
{
    private List<GameObject> _frm;
    private List<GameObject> _to;
    private int _toindex;
    private int _fromindex;
    private GameObject movedObj;

    public movecard(List<GameObject> from, int fromindex, List<GameObject> to, int toindex)
    {
        _frm = from; _to = to; _fromindex = fromindex; _toindex = toindex;
        movedObj = from[fromindex];
    }

    public void Execute()
    {
        _frm.Remove(movedObj);
        _to.Insert(_toindex, movedObj);
    }

    public void Undo()
    {
        _to.Remove(movedObj);
        _frm.Insert(_fromindex, movedObj);
    }
}
public class addcard : ticks
{
    private List<GameObject> _to;
    private int _toindex;
    private GameObject movedObj;
    private history _boss;
    private GameObject movedobjholder;

    public addcard(GameObject card, List<GameObject> to, int toindex, history boss)
    {
        _to = to; _toindex = toindex;
        movedObj = card; _boss = boss;
    }

    public void Execute()
    {
        movedobjholder = _boss.instantiateHack(movedObj);
        _to.Insert(_toindex, movedobjholder);
    }

    public void Undo()
    {
        _to.Remove(movedobjholder);
        _boss.destroyHack(movedobjholder);
    }

}
public class changehp : ticks
{
    private GameObject changetarget;
    private int change;
    public changehp(GameObject cngtrget, int cng)
    {
        changetarget = cngtrget;
        change = cng;
    }
    public void Execute()
    {
        changetarget.GetComponent<Health>()._Health += change;
    }
    public void Undo()
    {
        changetarget.GetComponent<Health>()._Health -= change;
    }
}
public class changemaxhp : ticks
{
    private GameObject changetarget;
    private int change;
    public changemaxhp(GameObject cngtrget, int cng)
    {
        changetarget = cngtrget;
        change = cng;
    }
    public void Execute()
    {
        changetarget.GetComponent<Health>()._maxHealth += change;
    }
    public void Undo()
    {
        changetarget.GetComponent<Health>()._maxHealth -= change;
    }
}
public class sethp : ticks
{
    private GameObject changetarget;
    private int change;
    private int placeholderhp;
    public sethp(GameObject cngtrget, int cng)
    {
        changetarget = cngtrget;
        change = cng;
        placeholderhp = changetarget.GetComponent<Health>()._Health;
    }
    public void Execute()
    {
        changetarget.GetComponent<Health>()._Health = change;
    }
    public void Undo()
    {
        changetarget.GetComponent<Health>()._Health = placeholderhp;
    }
}
public class setmaxhp : ticks
{
    private GameObject changetarget;
    private int change;
    private int placeholderhp;
    public setmaxhp(GameObject cngtrget, int cng)
    {
        changetarget = cngtrget;
        change = cng;
        placeholderhp = changetarget.GetComponent<Health>()._maxHealth;
    }
    public void Execute()
    {
        changetarget.GetComponent<Health>()._maxHealth = change;
    }
    public void Undo()
    {
        changetarget.GetComponent<Health>()._maxHealth = placeholderhp;
    }
}
public class changemana : ticks
{
    private GameObject changetarget;
    private int changeamount;
    public changemana(GameObject trgt, int amnt)
    {
        changetarget = trgt;
        changeamount = amnt;
    }
    public void Execute()
    {
        changetarget.GetComponent<Mana>()._Mana += changeamount;
    }
    public void Undo()
    {
        changetarget.GetComponent<Mana>()._Mana -= changeamount;
    }
}
public class changemaxmana : ticks
{
    private GameObject changetarget;
    private int changeamount;
    public changemaxmana(GameObject trgt, int amnt)
    {
        changetarget = trgt;
        changeamount = amnt;
    }
    public void Execute()
    {
        changetarget.GetComponent<Mana>()._maxMana += changeamount;
    }
    public void Undo()
    {
        changetarget.GetComponent<Mana>()._maxMana -= changeamount;
    }
}
public class setmana : ticks
{
    private GameObject changetarget;
    private int changeamount;
    private int placeholdermana;
    public setmana(GameObject trgt, int amnt)
    {
        changetarget = trgt;
        changeamount = amnt;
        placeholdermana = changetarget.GetComponent<Mana>()._Mana;
    }
    public void Execute()
    {
        changetarget.GetComponent<Mana>()._Mana = changeamount;
    }
    public void Undo()
    {
        changetarget.GetComponent<Mana>()._Mana = placeholdermana;
    }
}
public class setmaxmana : ticks
{
    private GameObject changetarget;
    private int changeamount;
    private int placeholdermana;
    public setmaxmana(GameObject trgt, int amnt)
    {
        changetarget = trgt;
        changeamount = amnt;
        placeholdermana = changetarget.GetComponent<Mana>()._maxMana;
    }
    public void Execute()
    {
        changetarget.GetComponent<Mana>()._maxMana = changeamount;
    }
    public void Undo()
    {
        changetarget.GetComponent<Mana>()._maxMana = placeholdermana;
    }
}
/*
public class playcard : ticks
{
    private GameObject card;
    public playcard(GameObject crd)
    {
        card = crd;
    }
    public void Execute()
    {

    }
    public void Undo()
    {

    }
}

public class triggerdeffect : ticks
{
    public triggerdeffect()
    {

    }
    public void Execute()
    {

    }
    public void Undo()
    {

    }
}
*/
