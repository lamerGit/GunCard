using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{

    GameObject[] Zombies;
    // Start is called before the first frame update
    GameObject M;
    GameObject P;
    void Start()
    {
        Zombies = GameObject.FindGameObjectsWithTag("Zombie");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickButton()
    {
        M = GameObject.FindGameObjectWithTag("MANAGER");
        M.GetComponent<StartGame>().RePoint(0);
        //StartGame.PlayerPoint = 0;
        Character.PlayerTurn = 0;

        GameObject[] Cards = GameObject.FindGameObjectsWithTag("CARD");
        for (int i = 0; i < Cards.Length; i++)
        {
            if (Cards[i].GetComponent<drag>().MyType() == drag.Number.GUN)
            {
                StartGame.Dumy.Add(1);
            }
            else if (Cards[i].GetComponent<drag>().MyType() == drag.Number.MOVE)
            {
                StartGame.Dumy.Add(2);
            }

            Destroy(Cards[i].gameObject);
        }

        Zombies = GameObject.FindGameObjectsWithTag("Zombie");
        for (int i=0; i<Zombies.Length; i++)
        {
            
            Zombies[i].GetComponent<ZombieScript>().ZombieTurn();
            
            if(i==Zombies.Length-1)
            {
                Invoke("DelayTurn", 1);
            }
        }

        Button btn = this.GetComponent<Button>();
        btn.interactable = false;
        //Zombie.GetComponent<ZombieScript>().MoveTotarget();     
        //StartGame.TurnToggle = 1; 
    }

    public void DelayTurn()
    {
        Debug.Log("End Zombie");
        Character.PlayerTurn = 1;
        M = GameObject.FindGameObjectWithTag("MANAGER");
        P = GameObject.FindGameObjectWithTag("Player");
        M.GetComponent<StartGame>().RePoint(3);
        P.GetComponent<Character>().ReShiled();
        M.GetComponent<StartGame>().CardSet();
        Button btn = this.GetComponent<Button>();
        btn.interactable = true;
    }
}
