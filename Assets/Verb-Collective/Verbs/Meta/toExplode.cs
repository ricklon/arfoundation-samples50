/*
 * Explode is the wrong word
 * but it's better than sparkles
 * You can use this verb
 * to activate particles
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toExplode : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
     


    [Tooltip("Drag the particle system that you want to activate into this field")]
    public ParticleSystem myParticles;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This holds info about whether the verb has just played or not
    private bool justPlayed = false;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        // if the verb is active AND has NOT just played
        if (isActive && !justPlayed)
        {
            // Turn on the particles and set justPlayed to true
            myParticles.Play();
            justPlayed = true;
        } 


        // If the verb is active AND the particle system is NOT playing AND justPlayed is still set to true
        // This basically resets the verb is the particle stops playing on its own, but it will wait till the last particles disappear.
        if (isActive && !myParticles.isPlaying && justPlayed)
        {

            // Stop the particles from playing and set justPlayed back to false.  Then resolve the verb
            myParticles.Stop();
            justPlayed = false;
            Activate(triggeredVerbs);
            isActive = false;
        }

        // If the verb is NOT active AND the particle system is still playing
        if (!isActive && myParticles.isPlaying)
        {

            // Stop the particles from playing and set justPlayed back to false.  Then resolve the verb
            myParticles.Stop();
            justPlayed = false;
            Activate(triggeredVerbs);
            isActive = false;
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This script simply connects to a particle system that you add in the inspector and turns it on.  You can turn off the particle system by chilling or deactivating the verb.
 */
