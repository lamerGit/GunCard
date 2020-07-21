using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;

    public enum Slot { WEAPON,LEFT,RIGHT};
    public Slot typeOfItem = Slot.WEAPON;

    public enum Number { GUN,MOVE,KNOCK,SHILED,SHOTGUN,SWORD};
    public Number typeCard = Number.GUN;

    int MoveSpeed = 2000;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");

        this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

     public Number MyType()
    {
        return typeCard;
    }

    void OnDestroy()
    {
        GameObject p = GameObject.FindWithTag("Player"); //태그로 플레이어 찾기
        //p.transform.Translate(new Vector2(1, 0)); << 이동하기
        Animator ani = p.GetComponent<Animator>();
        GameObject z = GameObject.FindWithTag("Zombie");
        GameObject M = GameObject.FindWithTag("MANAGER");


        
            if (Character.Signal == 0 && Character.PlayerTurn==1)
            {
                p.transform.localScale = new Vector3(-1, 1, 1);
            if (typeCard == Number.GUN)
            {
                //ani.SetTrigger("atk");
                StartGame.Dumy.Add(1);

                GameObject[] Zombies = GameObject.FindGameObjectsWithTag("Zombie");
                List<Vector2> MinList = new List<Vector2>();
                List<int> ZombieNumber = new List<int>();
                for (int i = 0; i < Zombies.Length; i++)
                {
                    Vector2 dir = p.transform.position - Zombies[i].transform.position;
                    Debug.Log(dir);
                    if (dir.x <= 200 && dir.x >= 0)
                    {
                        MinList.Add(dir);
                        ZombieNumber.Add(i);
                    }
                }
                if (MinList.Count != 0)
                {
                    Vector2 MAXMIN = new Vector2(300, 0);
                    int NumberMIN = -1;
                    for (int i = 0; i < MinList.Count; i++)
                    {
                        if (MinList[i].x < MAXMIN.x)
                        {
                            MAXMIN = MinList[i];
                            NumberMIN = ZombieNumber[i];
                        }
                    }
                    Debug.Log("Hit Dir :" + MAXMIN);
                    Zombies[NumberMIN].GetComponent<ZombieScript>().ZombieHit(10);
                    M.GetComponent<StartGame>().DownPoint(1);
                }
                else
                {
                    M.GetComponent<StartGame>().DownPoint(1);
                }

            }
            else if (typeCard == Number.MOVE)
            {

                //p.transform.position += new Vector3(-50, 0, 0);
                Animator MoveAni = p.GetComponent<Animator>();
                MoveAni.SetTrigger("Move");
                p.GetComponent<Character>().PlayerMoveLeft();

                StartGame.Dumy.Add(2);
                M.GetComponent<StartGame>().DownPoint(1);
            }
            else if (typeCard == Number.KNOCK)
            {

            }
            else if (typeCard == Number.SHILED)
            {
                StartGame.Dumy.Add(4);
                Debug.Log("ShiledUP");
                p.GetComponent<Character>().PlayerShiledUP(5);
                M.GetComponent<StartGame>().DownPoint(1);
            }
            else if (typeCard == Number.SHOTGUN)
            {
                StartGame.Dumy.Add(5);
                GameObject[] Zombies = GameObject.FindGameObjectsWithTag("Zombie");
                List<Vector2> MinList = new List<Vector2>();
                List<int> ZombieNumber = new List<int>();
                for (int i = 0; i < Zombies.Length; i++)
                {
                    Vector2 dir = p.transform.position - Zombies[i].transform.position;
                    Debug.Log(dir);
                    if (dir.x <= 80 && dir.x >= 0)
                    {
                        MinList.Add(dir);
                        ZombieNumber.Add(i);
                    }
                }
                if (MinList.Count != 0)
                {
                    //Vector2 MAXMIN = new Vector2(300, 0);
                    //int NumberMIN = -1;
                    for (int i = 0; i < ZombieNumber.Count; i++)
                    {
                        Zombies[ZombieNumber[i]].GetComponent<ZombieScript>().ZombieHit(10);
                    }
                    //Debug.Log("Hit Dir :" + MAXMIN);
                    
                    M.GetComponent<StartGame>().DownPoint(1);
                }
                else
                {
                    M.GetComponent<StartGame>().DownPoint(1);
                }
            }
            else if (typeCard == Number.SWORD)
            {
                StartGame.Dumy.Add(6);
                GameObject[] Zombies = GameObject.FindGameObjectsWithTag("Zombie");
                List<Vector2> MinList = new List<Vector2>();
                List<int> ZombieNumber = new List<int>();
                for (int i = 0; i < Zombies.Length; i++)
                {
                    Vector2 dir = p.transform.position - Zombies[i].transform.position;
                    Debug.Log(dir);
                    if (dir.x <= 50 && dir.x >= 0)
                    {
                        MinList.Add(dir);
                        ZombieNumber.Add(i);
                    }
                }
                if (MinList.Count != 0)
                {
                    Vector2 MAXMIN = new Vector2(300, 0);
                    int NumberMIN = -1;
                    for (int i = 0; i < MinList.Count; i++)
                    {
                        if (MinList[i].x < MAXMIN.x)
                        {
                            MAXMIN = MinList[i];
                            NumberMIN = ZombieNumber[i];
                        }
                    }
                    Debug.Log("Hit Dir :" + MAXMIN);
                    Zombies[NumberMIN].GetComponent<ZombieScript>().ZombieHit(5);

                }
            }


            }
            else if (Character.Signal == 1 && Character.PlayerTurn == 1)
            {
                p.transform.localScale = new Vector3(1, 1, 1);
            if (typeCard == Number.GUN)
            {
                //ani.SetTrigger("atk");
                StartGame.Dumy.Add(1);

                GameObject[] Zombies = GameObject.FindGameObjectsWithTag("Zombie");
                List<Vector2> MinList = new List<Vector2>();
                List<int> ZombieNumber = new List<int>();
                for (int i = 0; i < Zombies.Length; i++)
                {
                    Vector2 dir = p.transform.position - Zombies[i].transform.position;
                    Debug.Log(dir);
                    if (dir.x >= -200 && dir.x <= 0)
                    {
                        MinList.Add(dir);
                        ZombieNumber.Add(i);
                    }
                }
                if (MinList.Count != 0)
                {
                    Vector2 MAXMIN = new Vector2(-300, 0);
                    int NumberMIN = -1;
                    for (int i = 0; i < MinList.Count; i++)
                    {
                        if (MinList[i].x > MAXMIN.x)
                        {
                            MAXMIN = MinList[i];
                            NumberMIN = ZombieNumber[i];
                        }
                    }
                    Debug.Log("Hit Dir :" + MAXMIN);
                    Zombies[NumberMIN].GetComponent<ZombieScript>().ZombieHit(10);
                    M.GetComponent<StartGame>().DownPoint(1);
                }
                else
                {
                    M.GetComponent<StartGame>().DownPoint(1);
                }
            }
            else if (typeCard == Number.MOVE)
            {
                //p.transform.position += new Vector3( 50, 0, 0);

                Animator MoveAni = p.GetComponent<Animator>();
                MoveAni.SetTrigger("Move");
                p.GetComponent<Character>().PlayerMoveRight();

                StartGame.Dumy.Add(2);
                M.GetComponent<StartGame>().DownPoint(1);
            }
            else if (typeCard == Number.KNOCK)
            {

            }
            else if (typeCard == Number.SHILED)
            {
                StartGame.Dumy.Add(4);
                Debug.Log("ShiledUP");
                p.GetComponent<Character>().PlayerShiledUP(5);
                M.GetComponent<StartGame>().DownPoint(1);

            }
            else if (typeCard == Number.SHOTGUN)
            {
                StartGame.Dumy.Add(5);
                GameObject[] Zombies = GameObject.FindGameObjectsWithTag("Zombie");
                List<Vector2> MinList = new List<Vector2>();
                List<int> ZombieNumber = new List<int>();
                for (int i = 0; i < Zombies.Length; i++)
                {
                    Vector2 dir = p.transform.position - Zombies[i].transform.position;
                    Debug.Log(dir);
                    if (dir.x >= -80 && dir.x <= 0)
                    {
                        MinList.Add(dir);
                        ZombieNumber.Add(i);
                    }
                }
                if (MinList.Count != 0)
                {
                    Vector2 MAXMIN = new Vector2(-300, 0);
                    //int NumberMIN = -1;
                    for (int i = 0; i < ZombieNumber.Count; i++)
                    {
                        Zombies[ZombieNumber[i]].GetComponent<ZombieScript>().ZombieHit(10);
                    }
                    Debug.Log("Hit Dir :" + MAXMIN);
                    
                    M.GetComponent<StartGame>().DownPoint(1);
                }
                else
                {
                    M.GetComponent<StartGame>().DownPoint(1);
                }

            }
            else if (typeCard == Number.SWORD)
            {
                StartGame.Dumy.Add(6);
                GameObject[] Zombies = GameObject.FindGameObjectsWithTag("Zombie");
                List<Vector2> MinList = new List<Vector2>();
                List<int> ZombieNumber = new List<int>();
                for (int i = 0; i < Zombies.Length; i++)
                {
                    Vector2 dir = p.transform.position - Zombies[i].transform.position;
                    Debug.Log(dir);
                    if (dir.x >= -50 && dir.x <= 0)
                    {
                        MinList.Add(dir);
                        ZombieNumber.Add(i);
                    }
                }
                if (MinList.Count != 0)
                {
                    Vector2 MAXMIN = new Vector2(-300, 0);
                    int NumberMIN = -1;
                    for (int i = 0; i < MinList.Count; i++)
                    {
                        if (MinList[i].x > MAXMIN.x)
                        {
                            MAXMIN = MinList[i];
                            NumberMIN = ZombieNumber[i];
                        }
                    }
                    Debug.Log("Hit Dir :" + MAXMIN);
                    Zombies[NumberMIN].GetComponent<ZombieScript>().ZombieHit(5);
                }
            }

        }
            Debug.Log("HelloDes");
        
    }

    
}
