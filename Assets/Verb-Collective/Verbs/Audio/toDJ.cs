/*
 * I found a box of records
 * and decided to play one
 * after that another
 * and I started having fun
 * 
 * I close my eyes and grab
 * the closest one at hand
 * the order doesn't matter
 * Im the DJ not the band
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toDJ : Verb
{

    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Just a heads up, so you know what this Verb needs in order to work")]
    public string requirement = "You need to have an AudioSource on this object or it won't work.";

    [Tooltip("Drag Audio Clips here in order to add them to your playlist")]
    public AudioClip[] myClips;

    [Tooltip("If you want the clips to keep randomly playing check this box, otherwise it will only play one clip at random")]
    public bool looping = true;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // this is used internally to know if the script has just been run or not
    private bool justPlayed = false;

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
        // check to see if the Verb is active
        if (isActive)
        {

            // (The audio is NOT playing) AND (the Verb has NOT played yet)
            if (!myAudio.isPlaying && !justPlayed)
            {
                //call the DJ function to shuffle and then play the songs
                DJ();

                // set the justPlayed value so that we know the Verb has just played
                justPlayed = true;
            }

            // (The audio is NOT playing) AND (the Verb is supposed to loop) AND (the Verb has just played)
            if (!myAudio.isPlaying && looping && justPlayed)
            {
                //call the DJ function to shuffle and then play the songs
                DJ();
            }

            // (The audio is NOT playing) AND (the Verb is NOT supposed to loop) AND (the Verb has just played)
            if (!myAudio.isPlaying && !looping && justPlayed)
            {
                // this turns off the verb
                isActive = false;
            }

        // (the Verb is NOT active) && (the Verb has just played)
        } else if (!isActive && justPlayed) {

            // Stop the audio playing, reset the verb, activate any verbs in the triggered verbs field
            myAudio.Stop();
            justPlayed = false;
            Activate(triggeredVerbs);

        }
    }



    //     The custom 'DJ' Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void DJ()
    {
        //creates a random integer for the myClips array using Random.Range, then adds it to the audio source
        myAudio.clip = myClips[Random.Range(0, myClips.Length)] as AudioClip;
        //plays the audio source
        myAudio.Play();
    }
}


//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This script plays a selection of audio clips in random order. If it is set to loop it will keep playing a random clip from the array, otherwise it will just play once.
 */
