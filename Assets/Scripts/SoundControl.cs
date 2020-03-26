using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : BaseAI
{
    public AudioSource soundTrack;
    public AudioSource SFX;
    public AudioClip song;
    public AudioClip hurt;
    public AudioClip pew;
    public AudioClip bye;
    
    
    
    
    
    public bool songPlay;
    public bool songToggle;
    // Start is called before the first frame update
    void Start()
    {

        SFX = GetComponent<AudioSource>();

        
//        soundTrack.loop = true;
        songPlay = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (songPlay == true && songToggle == true)
        {
            
            soundTrack.Play();
            

            songToggle = false;
        }

        if (songPlay == false && songToggle == true)
        {
            
            soundTrack.Stop();

            songToggle = false;
        }
        
    }

    public void PlayerSound(GameObject guy, int option)
    {
        Debug.Log("guy: " + guy);
        
        Debug.Log("SFX called");
        /*if (option == 1)
        {
            Debug.Log("Pew");
            guy.clip = pew;
            
            guy.Play();
        }

        if (option == 2)
        {
            Debug.Log("Ow");
            guy.clip = hurt;
            guy.Play();
        }

        if (option == 3)
        {
            Debug.Log("Dead");
            guy.clip = bye;
            guy.Play();
        }
        else ;*/


    }

    
}
