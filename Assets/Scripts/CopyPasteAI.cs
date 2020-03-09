using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CopyPasteAI : BaseAI
{
    
    public float maxHealth = 100;
    public float currentHealth;
    public float defense;
    public float speed;
    public float damage;
    //public HealthScript CurHealth;

    //modes the AI can switch between, with values represented as percentages
    public Mode Defensive = new Mode(.6f,.2f,.2f);
    public Mode Offensive = new Mode(.2f,.2f,.6f);
    public Mode Retreat = new Mode(.2f,.6f,.2f);

    public HealthScript healthBar;
    public HealthScript defBar;
    public HealthScript speedBar;
    public HealthScript damBar;
    
     void Start()
    {
        currentHealth = maxHealth;
//        if (healthBar != null)
//        {
//            healthBar.SetMaxHealth(maxHealth);
//            
//        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(20);
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetDefensive();
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SetOffesive();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SetRetreat();
        }
    }

    public void SetDefensive()
    {
        if (Stats != null)
        {
        Stats.SetHealth(currentHealth);
        Stats.SetNewMode(Defensive);
        healthBar.StatBars(Defensive);//this will need to be called in each "mode" function unless a checker can be created

        defense = Stats.HP;
        speed = Stats.SPD;
        damage = Stats.DMG;
        
        Debug.Log("defense: " + defense);
        Debug.Log("damage: " + damage);
        Debug.Log("speed: " + speed);
        
    }
    else {Debug.Log("Stats is null");}

    }

    public void SetOffesive()
    {
        if (Stats != null)
        {
            Stats.SetHealth(currentHealth);
            Stats.SetNewMode(Offensive);
            healthBar.StatBars(Offensive);

            currentHealth = Stats.R;
            defense = Stats.HP;
            speed = Stats.SPD;
            damage = Stats.DMG;

            Debug.Log("defense: " + defense);
            Debug.Log("damage: " + damage);
            Debug.Log("speed: " + speed);
        }
        else {Debug.Log("Stats is null");}

    }

    public void SetRetreat()
    {
        if (Stats != null)
        {
            Stats.SetHealth(currentHealth);
            Stats.SetNewMode(Retreat);
            healthBar.StatBars(Retreat);

            currentHealth = Stats.R;
            defense = Stats.HP;
            speed = Stats.SPD;
            damage = Stats.DMG;

            Debug.Log("defense: " + defense);
            Debug.Log("damage: " + damage);
            Debug.Log("speed: " + speed);
        } else {Debug.Log("FUCK");}

    }

   


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
//        if (healthBar != null)
//        {
            healthBar.SetHealth(currentHealth);
            //CurHealth.fillPer = currentHealth / 100;

        //}
    }
}

/*
    public override IEnumerator RunAI()
    {
        Debug.Log("test");
        while (true)
        {
            if (GetHealth() < 0.5f)
            {
                yield return FireFront(1);
            }
            else
            {
                yield return Ahead(2);
                yield return FireFront(1);
                yield return TurnLeft(360);
                yield return Back(4);
                yield return TurnRight(90);
            }
            if (GetHealth() <= 0.0f)
            {
                break;
            }
        }
    }

    public override void OnScannedRobot(ScannedRobotEvent e)
    {
        Debug.Log("Enemy detected: " + e.Name + " at distance: " + e.Distance);
    }
}*/
