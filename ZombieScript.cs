using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieScript : MonoBehaviour
{
    Transform target;
    Transform enemy;
    public float speed;

    public int ZombieHp = 30;
    public int currentHp;
    // Start is called before the first frame update

    public GameObject healthBarBackground;
    public Image healthBarFilled;

    public static int HitToggle = 1;
    int ZombieTurnToggle = 1;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentHp = ZombieHp;
        healthBarFilled.fillAmount = 1f;
        //healthBarBackground.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(HitToggle==0)
        {
            ZombieHit(10);
            HitToggle = 1;
        }
    }

    public void ZombieTurn()
    {
        GameObject Play = GameObject.FindGameObjectWithTag("Player");
        //ZombieTurnToggle = 0;
        /*if (Input.GetKeyDown(KeyCode.Space))
        {

        }*/

        //MoveTotarget();
        //Attack();

        /*if (target != null)
        {
            Vector2 dir = target.position - transform.position;


            if (dir.x <= 30 && dir.x >= -30)
            {
                if (dir.x <= 0)
                {
                    Debug.Log("Left Attack!!");
                    //this.transform.localScale = new Vector3(-1, 1, 1);
                    Animator ani = this.GetComponent<Animator>();
                    ani.SetTrigger("atk");
                    Play.GetComponent<Character>().PlayerHit(10);
                }
                else
                {
                    Debug.Log("Right Attack!!");
                    //this.transform.localScale = new Vector3(1, 1, 1);
                    Animator ani = this.GetComponent<Animator>();
                    ani.SetTrigger("atk");
                    Play.GetComponent<Character>().PlayerHit(10);
                }
                //Invoke("Attack", 1);
                //Attack();
            }
            else
            {
                Invoke("MoveTotarget", 0.1f);
                Invoke("MoveTotarget", 0.2f);
                Invoke("MoveTotarget", 0.3f);
                Invoke("MoveTotarget", 0.4f);
            }
        }*/

        Invoke("ZombiePlay", 0.5f);
        Invoke("ZombiePlay", 1);
        //StartGame.TurnToggle = 0;
        // Debug.Log(StartGame.TurnToggle);

    }

    public void ZombiePlay()
    {
        GameObject Play = GameObject.FindGameObjectWithTag("Player");
        //ZombieTurnToggle = 0;
        /*if (Input.GetKeyDown(KeyCode.Space))
        {

        }*/

        //MoveTotarget();
        //Attack();

        if (target != null)
        {
            Vector2 dir = target.position - transform.position;


            if (dir.x <= 30 && dir.x >= -30)
            {
                if (dir.x <= 0)
                {
                    Debug.Log("Left Attack!!");
                    //this.transform.localScale = new Vector3(-1, 1, 1);
                    Animator ani = this.GetComponent<Animator>();
                    ani.SetTrigger("atk");
                    Play.GetComponent<Character>().PlayerHit(10);
                }
                else
                {
                    Debug.Log("Right Attack!!");
                    //this.transform.localScale = new Vector3(1, 1, 1);
                    Animator ani = this.GetComponent<Animator>();
                    ani.SetTrigger("atk");
                    Play.GetComponent<Character>().PlayerHit(10);
                }
                //Invoke("Attack", 1);
                //Attack();
            }
            else
            {
                Invoke("MoveTotarget", 0.1f);
                Invoke("MoveTotarget", 0.2f);
                Invoke("MoveTotarget", 0.3f);
                Invoke("MoveTotarget", 0.4f);
            }
        }

    }

    public void ZombieHit(int x)
    {
        Debug.Log("Hit!!!!");
        currentHp = currentHp - x;
        healthBarFilled.fillAmount = (float)currentHp/ZombieHp;
        healthBarBackground.SetActive(true);
        Animator HitAni = this.GetComponent<Animator>();
        HitAni.SetTrigger("Hit");

        if(currentHp<=0)
        {
            Animator ani = this.GetComponent<Animator>();
            ani.SetTrigger("Die");
            Invoke("Die", 0.5f);
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    /*public void ClickButton()
    {
        StartGame.TurnToggle = 1;
    }*/
    public void Attack()
    {
        GameObject Play = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            Vector2 dir = target.position - transform.position;


            if (dir.x <= 0)
            {
                Debug.Log("Left Attack!!");
                //this.transform.localScale = new Vector3(-1, 1, 1);
                Animator ani = this.GetComponent<Animator>();
                ani.SetTrigger("atk");
                Play.GetComponent<Character>().PlayerHit(10);
            }
            else
            {
                Debug.Log("Right Attack!!");
                //this.transform.localScale = new Vector3(1, 1, 1);
                Animator ani = this.GetComponent<Animator>();
                ani.SetTrigger("atk");
                Play.GetComponent<Character>().PlayerHit(10);
            }

        }
    }

    public void MoveTotarget()
    {
        if(target!=null)
        {
            Vector2 dir = target.position - transform.position;
            //Debug.Log("DIR : " + dir);

           
            transform.position += (target.position - transform.position).normalized * speed;
           


            if (dir.x>=0)
            {
                /*Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;*/
                this.transform.localScale = new Vector3(-1, 1, 1);

            }else
            {
                this.transform.localScale = new Vector3(1, 1, 1);
                /*Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;*/
            }
        }
    }
}
