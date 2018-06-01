using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class history : MonoBehaviour {


    private List<ticks> klock = new List<ticks>();
    private movecard mvcrd;
    private addcard adcrd;
    private int currentTick;

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