/*
 * if you just want a sound 
 * to play on command
 * please use this script
 * it is high in demand
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toPlay : Verb
{

    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Just a heads up, so you know what this Verb needs in order to work")]
    public string requirement = "You need to have an AudioSource on this object or it won't work.";

    [Tooltip("Drag Audio Clips here in order to add them to your playlist")]
    public AudioClip myClip;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // this is an audiosource that we can use to access our gameobject's audiosource after we initialize it
    private AudioSource myAudio;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {
        // This initializes the audiosource of the game object so that you can access it using the variable 'myAudio'
        myAudio = GetComponent<AudioSource>();

    }



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {

            // Sets the audio clip to be the one placed in the inspector and the next line activates the play function for the audio clip
            myAudio.clip = myClip;
            myAudio.Play();


            // turns the Verb off and activates any verbs in the Triggered Verbs array
            isActive = false;
            Activate(triggeredVerbs);
            
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb plays a selected audio clip using the audiosource for the game object
 */
