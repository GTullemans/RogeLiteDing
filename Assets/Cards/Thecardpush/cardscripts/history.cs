using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class history : MonoBehaviour {

    private List<ticks> klock = new List<ticks>();
    private movecard mvcrd;
    private addcard adcrd;
    private changehp cnghp;
    private changemana cngmn;
    private int currentTick =0;

	void Start ()
    {
		
	}

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.H))
        {

        }
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

    public void windback()
    {
        if(klock.Count > 0 && klock.Count >= currentTick && currentTick > 0)
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


    public void instantiateHack(GameObject target)
    {
        Instantiate(target);
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

    public addcard(GameObject card, List<GameObject> to, int toindex, history boss)
    {
        _to = to; _toindex = toindex;
        movedObj = card; _boss = boss;
    }

    public void Execute()
    {
        _boss.instantiateHack(movedObj);
        _to.Insert(_toindex, movedObj);
    }

    public void Undo()
    {
        _to.Remove(movedObj);
        _boss.destroyHack(movedObj);
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
