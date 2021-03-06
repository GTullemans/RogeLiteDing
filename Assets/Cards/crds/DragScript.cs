﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour {
    private Vector3 _MousePos;
    private bool _Kliked;
    private Collider _CardCollider;
    private Card _CardInfo;
    private int InitialLayer;
    private Vector2 InitialPos;
    private Collider Hitcoll;

    [SerializeField]
    private LayerMask _Mask;

    private movecard _MoveCard;
    // Use this for initialization
    void Start () {
        _Kliked = false;
        _CardCollider = gameObject.GetComponent<Collider>();
        _CardInfo = gameObject.GetComponent<Card>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
        _MousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);


        DragAndDrop(_MousePos);
        





    }



    private void DragAndDrop(Vector3 mousepos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider == _CardCollider)
                {
                    Hitcoll = hit.collider;
                    InitialPos = gameObject.transform.position;
                    InitialLayer = _CardInfo.lay;
                    _CardInfo.lay = 1000;
                    _Kliked = true;

                }
            }
        }
        

        if (_Kliked)
        {
            transform.position = Vector3.Lerp(transform.position, mousepos, 0.98f);



            if (Input.GetMouseButtonUp(0))
            {
                _Mask = ~_Mask;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000f, _Mask))
                {
                    Debug.Log(hit.collider.tag);
                    if (hit.collider.tag == "Play")
                    {

                    }

                    if (hit.collider.tag == "Hand")
                    {
                        
                        if (Hitcoll == _CardCollider)
                        {
                           
                            _CardInfo.lay = InitialLayer;
                            transform.position = InitialPos;
                        }
                    }


                }




                _Kliked = false;
            }
        }
    }

    private void ClickToPick(Vector3 mousepos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider == _CardCollider)
                {


                    if (_Kliked)
                    {
                        _Kliked = false;
                    }
                    else
                    {
                        _Kliked = true;
                    }
                }
            }
        }

        if (_Kliked)
        {
            transform.position = Vector3.Lerp(transform.position, _MousePos, 0.98f);
        }
    }
}
