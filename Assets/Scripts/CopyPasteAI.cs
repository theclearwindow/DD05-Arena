using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CopyPasteAI : BaseAI
{
    
    //See MaxAI for most current work from Max
    
    public float currentHealth;
    public float defense;
    public float speed;
    public float damage;


    public bool on;

    //This 2D Array contains your different modes. 
    private float[,] modes = new float[,]
    {
        /*offensive*/{.2f, .2f, .6f}, 
        /*defensive*/{.6f,.2f,.2f}, 
        /*Retreat*/{.2f,.6f,.2f}
    };

    private float[] offensive = {.2f, .2f, .6f};
    private float[] defensive = {.6f, .2f, .2f};
    private float[] retreat = {.2f,.6f,.2f};

    public int newPos = 0;//new position in the array, counting down from the top.
    public int nowPos = 0;//current position in the array, to keep the mode from updating every frame
    public float[] set;//1D array containing the current mode values only.




    public HealthScript healthBar;
    public HealthScript defBar;
    public HealthScript speedBar;
    public HealthScript damBar;

    void Start()
    {
        on = true;//is AI on or alive -- possibly unnecessary
        currentHealth = 100;

        newPos = 1;//set starting mode -- make sure this is different than "nowPos" starting variable or the mode won't set

        //set = new float[] { modes[newPos, 0], modes[newPos, 1], modes[newPos, 2] }; //set values for beginning mode

    }

    void Update()
    {

        currentHealth = Unit.currentHealth;
        /*
                if (nowPos != newPos)//if mode has changed
                {
                    set = new float[] { modes[newPos, 0], modes[newPos, 1], modes[newPos, 2] };//change current mode values
        
        
                    Stats.SetNewMode(set);//apply current mode values
                    healthBar.StatBars(set);//set statbar values
        
                    //apply current values to unit:
                    defense = Stats.HP;
                    speed = Stats.SPD;
                    damage = Stats.DMG;
                    Debug.Log("defense: " + defense);
                    Debug.Log("damage: " + damage);
                    Debug.Log("speed: " + speed);
                    nowPos = newPos;//update nowPos to stop program from crashing
        
                }
                if (Input.GetKeyDown(KeyCode.F))
                {
                    TakeDamage(20);//hurt me, daddy
                }
        
                if (Input.GetKeyDown(KeyCode.T))
                {
                    //SetDefensive();
                }
        
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    //SetOffesive();
                }
        
                if (Input.GetKeyDown(KeyCode.U))
                {
                    //SetRetreat();
                }
        
                if (on == true)//check if unit is alive
                {
        
                    if (currentHealth / 100 < 0.5f)//check health
                    {
        
        
                        newPos = 0; //change mode based on health
                        //StartCoroutine(UnderHalf());
                    }
        
                    if (currentHealth / 100 < .3f)
                    {
                        newPos = 2;
                    }
        
        
                }
        
                if (currentHealth / 100 <= 0.0f)
                {
                    on = false;
                    //die?
                }
            }
        
            void TakeDamage(int damage)
            {
                currentHealth -= damage;
        
                healthBar.SetHealth(currentHealth);
        
            }/*
        
            /*
            IEnumerator OverHalf()
            {
        
        
                if (currentHealth / 100 > 0.5f)
                {
                    yield return FireFront(1);
                }
                else
                {
        
                }
                if (currentHealth / 100 <= 0.0f)
                {
                    Debug.Log("Dead");
                }
            }
        
            IEnumerator UnderHalf()
            {//what if no coroutines? just at first?
                yield return Ahead(2);
                yield return FireFront(1);
                yield return TurnLeft(360);
                yield return Back(4);
                yield return TurnRight(90);
            }
            */
    }//this needs to be removed if the above comments are undone


    public override IEnumerator RunAI()
    {
        Debug.Log("CopyPasteAI RunAI started");
        while (true)
        {
            {

                //Scouting
                yield return DoNothing(1);
                yield return Ahead(2);
                yield return LookAtTarget(10);
                yield return FireFront();//set power in UnitController
                yield return FollowTarget(2);
                yield return TurnRight(90);


                /*
                yield return FireFront(3);
                yield return FireFront(1);
                */
                /*
                yield return Ahead(2);
                yield return FireFront(10);
                yield return SetStats(offensive, currentHealth);
                //yield return FireFront(1);
                yield return SetStats(defensive, currentHealth);
                yield return TurnLeft(360);
                yield return SetStats(retreat, currentHealth);
                yield return Back(4);
                //yield return FollowTarget(2);
                yield return TurnRight(90);
                */
            }
        }
    }
}
