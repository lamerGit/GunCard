using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemShuffle;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    List<int> Dec = new List<int>();
    public static List<int> Dumy = new List<int>();
    public GameObject Card1 = null;
    public GameObject Card2 = null;
    public GameObject Card4 = null;
    public GameObject Card5 = null;
    public GameObject Card6 = null;
    public static int ToggleNumber=0;
    int DecCount = 5;
    int reSetNumber = 5;

    public static int PlayerPoint = 3;
    int MaxPoint = 3;
    public Image Point = null;
    public Sprite[] PointSprite;

    //public static int TurnToggle = 0;
    void Start()
    {

        Dec.Add(2);
        Dec.Add(1);
        Dec.Add(2);
        Dec.Add(2);
        Dec.Add(1);
        Dec.Add(1);
        Dec.Add(2);
        Dec.Add(1);
        Dec.Add(2);
        Dec.Add(1);
        Dec.Add(4);
        Dec.Add(4);
        Dec.Add(5);
        Dec.Add(5);
        Dec.Add(6);
        Dec.Add(6);
        CardSet();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if(ToggleNumber==1)
        {      
            CardSet();
            ToggleNumber = 0;
        }*/
        
    }

    public void CardSet()
    {
        List.shuffle(Dec);
        for (int i = 0; i < DecCount; i++)
        {
            if(Dec.Count==0)
            {
                DecCount = DecCount - i;
                DumyComing();
                break;
            }
            if (Dec[0] == 1)
            {
                Card1Set();
            }
            else if (Dec[0] == 2)
            {
                Card2Set();
            }else if(Dec[0]==4)
            {
                Card4Set();
            }
            else if (Dec[0] == 5)
            {
                Card5Set();
            }
            else if (Dec[0] == 6)
            {
                Card6Set();
            }
            Dec.RemoveAt(0);
        }
        DecCount = reSetNumber;
    }
    public void Card1Set()
    {
        var child = Instantiate(Card1, transform.position, transform.rotation) as GameObject;
        Transform re = GameObject.FindWithTag("Respawn").GetComponent<Transform>();
        child.transform.parent = re;
    }

    public void Card2Set()
    {
        var child = Instantiate(Card2, transform.position, transform.rotation) as GameObject;
        Transform re = GameObject.FindWithTag("Respawn").GetComponent<Transform>();
        child.transform.parent = re;
    }

    public void Card4Set()
    {
        var child = Instantiate(Card4, transform.position, transform.rotation) as GameObject;
        Transform re = GameObject.FindWithTag("Respawn").GetComponent<Transform>();
        child.transform.parent = re;
    }

    public void Card5Set()
    {
        var child = Instantiate(Card5, transform.position, transform.rotation) as GameObject;
        Transform re = GameObject.FindWithTag("Respawn").GetComponent<Transform>();
        child.transform.parent = re;
    }

    public void Card6Set()
    {
        var child = Instantiate(Card6, transform.position, transform.rotation) as GameObject;
        Transform re = GameObject.FindWithTag("Respawn").GetComponent<Transform>();
        child.transform.parent = re;
    }

    public void DumyComing()
    {
        
        while (Dumy.Count > 0)
        {
             Dec.Add(Dumy[0]);
             Dumy.RemoveAt(0);
        }
        CardSet();
        
    }

    public void DownPoint(int x)
    {
        PlayerPoint -= x;
        Point.sprite = PointSprite[PlayerPoint];
    }

    public void RePoint(int x)
    {
        PlayerPoint = x;
        Point.sprite = PointSprite[PlayerPoint];
    }
}
