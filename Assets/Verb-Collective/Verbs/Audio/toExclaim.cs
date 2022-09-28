/*
 * 'Ouch' and 'Oh no' you say
 * or 'Dang' or 'Darn'
 * or 'Yowwwweee!'
 * 
 * just once
 * however loud, 
 * and then pretend 
 * it didn't hurt you
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toExclaim : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||

    [Tooltip("Just a heads up, so you know what this Verb needs in order to work")]
    public string requirement = "You need to have an AudioSource on this object or it won't work.";

    [Tooltip("Drag Audio Clips here in order to add them to your playlist")]
    public AudioClip myClip;

    [Tooltip("Set the volume your one shot audio will play at")]
    public float volume = 1.0f;

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
            // plays the selected clip from the inspector and plays it one time at the chosen volume
            myAudio.PlayOneShot(myClip, volume);

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
 * This script plays an audio clip one time at a volume of your choosing
 */

