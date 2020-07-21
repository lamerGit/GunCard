using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public static int Signal = 0;
    public static int Local = 1;

    float speed = 10f;
    //Rigidbody rigidbody;
    Vector3 movement;

    public int PlayerHp = 30;
    public int currentHp;
    public GameObject healthBarBackground;
    public Image healthBarFilled;

    public static int PlayerHitToggle=1;

    public static int PlayerTurn = 1;

    int PlayerDEF = 0;

    
    void Start()
    {
        /*GameObject Number1 = GameObject.Find("1");
        this.transform.parent = Number1.transform;
        this.transform.localScale = new Vector3(8, 3, 1);*/
        currentHp = PlayerHp;
        healthBarFilled.fillAmount = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {

            rigidbody = this.GetComponent<Rigidbody>();

            movement = movement.normalized * speed * Time.deltaTime;

            rigidbody.MovePosition(transform.position + movement);

        }*/
        if(PlayerHitToggle==0)
        {
            PlayerHit(10);
            PlayerHitToggle = 1;
        }
    }

    public void PlayerHit(int x)
    {
        Debug.Log("PlayerHit!!!!");
        int temp;
        if(PlayerDEF!=0)
        {
            temp = PlayerDEF - x;
            if(temp<0)
            {
                PlayerDEF = 0;
                temp = temp * -1;
            }else
            {
                PlayerDEF = PlayerDEF - x;
            }
            currentHp = currentHp - temp;
        }else
        {
            currentHp = currentHp - x;
        }

        
        healthBarFilled.fillAmount = (float)currentHp / PlayerHp;
        //healthBarBackground.SetActive(true);
        Animator ani = this.GetComponent<Animator>();
        ani.SetTrigger("Hit");

        if (currentHp <= 0)
        {
            PlayerDie();

            //Destroy(this.gameObject);
        }
    }

    public void PlayerDie()
    {
        Animator ani = this.GetComponent<Animator>();
        ani.SetTrigger("Die");
    }

    public void PlayerMoveLeft()
    {
        for(float i=0; i<0.5f; i+=0.1f)
        {
            Invoke("LEFT", i);
        }
    }

    public void LEFT()
    {
        this.transform.position += new Vector3(-10, 0, 0);
    }

    public void PlayerMoveRight()
    {
        for(float i = 0; i < 0.5f; i += 0.1f)
        {
            Invoke("RIGHT", i);
        }
    }

    public void RIGHT()
    {
        this.transform.position += new Vector3(10, 0, 0);
    }

    public void PlayerShiledUP(int x)
    {
        PlayerDEF += x;
    }

    public void ReShiled()
    {
        Debug.Log("ReShiled");
        PlayerDEF = 0;
    }

}
