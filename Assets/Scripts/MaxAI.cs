using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAI : BaseAI
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    public float defense;
    public float speed;
    public float damage;
    public bool basic = true;

    //public HealthScript CurHealth;

    //modes the AI can switch between, with values represented as percentages
    public Mode Defensive = new Mode(.6f,.2f,.2f);
    public Mode Offensive = new Mode(.2f,.2f,.6f);
    public Mode Retreat = new Mode(.2f,.6f,.2f);

    public HealthScript healthBar;
    public HealthScript defBar;
    public HealthScript speedBar;
    public HealthScript damBar;



    private void Start()
    {
        Debug.Log(currentHealth + "health");
        healthBar.SetHealth(maxHealth);
        Debug.Log(currentHealth + "health");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(10);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetDefensive();
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetOffesive();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SetRetreat();
        }

        if (basic == true)
        {
            RunAI();
        } else basic = false;


    }

    public override IEnumerator RunAI()
    {
        Debug.Log("MaxAI RunAI started");
        while (true)
        {
            if (currentHealth < 50f)
            {
                yield return FireFront(1);
                yield return TurnRight(90);
            }
            else
            {
                yield return Ahead(200);
                yield return FireFront(66);
                yield return TurnLeft(4);
                yield return Back(45);
                yield return TurnRight(90);
            }
            if (currentHealth <= 0.0f)
            {
                break;
            }
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
        currentHealth = currentHealth - damage;
        Debug.Log(damage + "damage");
//        if (healthBar != null)
//        {
            healthBar.SetHealth(currentHealth);
            //CurHealth.fillPer = currentHealth / 100;

        //}
    }
}

public struct Mode
{

    public float HPercent;
    public float SPercent;
    public float DPercent;

    public Mode(float HPercent, float SPercent, float DPercent)
    {

        this.HPercent = HPercent;
        this.SPercent = SPercent;
        this.DPercent = DPercent;

    }
    
}
