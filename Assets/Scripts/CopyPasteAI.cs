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
        
        
        if (currentHealth < GetStats())
        {
            HealthChange();
            currentHealth = GetStats();
        } else HealthChange();

    }

    bool HealthChange()
    {

        bool itDid = false;

        if (currentHealth < GetStats())
        {

            //currentHealth = GetStats();
            itDid = true;
        }

        return itDid;
    }


    public override IEnumerator RunAI()
    {
//        Debug.Log("CopyPasteAI RunAI started");
        while (true)
        {
            float healthMod = currentHealth / 100;
            float[] currentMode = {1,1,1};
            float[] changeMode = offensive;//start with default mode
            

                //Scouting
            yield return DoNothing(1);
                //yield return Ahead(2);
                //yield return LookAtTarget(10);
                //yield return FireFront();//set power in UnitController
                //yield return FollowTarget(2);
            yield return FireFront();
                //yield return TurnRight(90);


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
                if (HealthChange())
                {
                    
                    


                        if (GetStats() <= .7f && GetStats() > .4f)
                        {
                            Debug.Log("Defensive");
                            
                            
                                changeMode = defensive;
                            

                            //yield return SetStats(currentMode, healthMod);
                        }
                        else if (GetStats() <= .4f)
                        {
                            Debug.Log("Retreat");
                            changeMode = retreat;
                            //yield return SetStats(currentMode, healthMod);
                        }
                        else
                        {
                            Debug.Log("default(offensive)");
                            // Debug.Log(GetStats());
                            changeMode = offensive;

                            //default mode
                        }

                        if(currentMode != changeMode)
                        {
                            currentMode = changeMode;
                            yield return SetStats(currentMode, healthMod);
                        }
                    


                }

                
        }
    }
}
    

