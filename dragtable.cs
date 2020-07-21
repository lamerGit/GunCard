using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragtable : MonoBehaviour, IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    public drag.Slot typeOfItem = drag.Slot.WEAPON;
    public GameObject obj;
    
    void Update()
    {
        GameObject[] leng = GameObject.FindGameObjectsWithTag("CARD");
        GameObject Set = GameObject.FindGameObjectWithTag("MANAGER");

        /*if(typeOfItem==drag.Slot.WEAPON && leng.Length==0 && Character.PlayerTurn==1 )
        {
            Set.GetComponent<StartGame>().CardSet();
        }*/
        /*if(typeOfItem==drag.Slot.WEAPON && Character.PlayerTurn==1 )
        {
            Set.GetComponent<StartGame>().CardSet();
        }*/
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        drag d = eventData.pointerDrag.GetComponent<drag>();
        drag.Slot L = drag.Slot.LEFT;
        drag.Slot R = drag.Slot.RIGHT;
        drag.Slot W = drag.Slot.WEAPON;

        drag.Number S = drag.Number.SWORD;
        
        if (d!=null)
        {
            if (W == typeOfItem)
            {
                d.parentToReturnTo = this.transform;
                
            }
            else if(L==typeOfItem)
            {
                Debug.Log("LEFT");
                Character.Signal = 0;
                if (StartGame.PlayerPoint != 0)
                {
                    Destroy(d.gameObject);
                }else if(StartGame.PlayerPoint==0 && d.MyType()==S)
                {
                    Destroy(d.gameObject);
                }
            }else if(R==typeOfItem)
            {
                Debug.Log("RIGHT");
                Character.Signal = 1;
                if (StartGame.PlayerPoint != 0)
                {
                    Destroy(d.gameObject);
                }
                else if (StartGame.PlayerPoint == 0 && d.MyType() == S)
                {
                    Destroy(d.gameObject);
                }
            }
        }
    }
}
