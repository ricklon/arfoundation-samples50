/*
 * Sometimes you want things to happen
 * one at a time, first this
 * then that, then the other
 * then again, over and over
 * 
 * You can make it random
 * or use it in a line
 * you can have it grow
 * then shrink the next time
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toSequence : Verb

{




    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
     


    
    [Tooltip("Turn this on to determine if sequence should be random, otherwise it will run the scripts in order")]
    public bool randomize;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    //SerializeField is just making this private variable, below, visible in the Unity Editor.

    [SerializeField]
    [Tooltip("this is just to make current number visible in the inspector for trouble shooting")]
    private int currentNumber = 0;




    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {

        if (isActive)
        {

            // If randomize was NOT selected
            if (!randomize)
            {    
                // Activate the first verb in the array [0], and then add 1, so that next time it will trigger the following verb 
                Activate(triggeredVerbs[currentNumber]);
                currentNumber = currentNumber + 1;

                // If the current number is higher than the number of verbs in the array
                if (currentNumber >= triggeredVerbs.Length)
                {
                    // restart the sequence to zero
                    currentNumber = 0;
                }
            }


            // If randomize was selected
            if (randomize)
            {
                // The index used to select the triggered verb in the array is a random number between 0 and the length of the array
                Activate(triggeredVerbs[Random.Range(0, triggeredVerbs.Length)]);
            }


            isActive = false;

        }




    }

}


//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb is a sequencer that lets you choose an array of verbs to either trigger in order or else trigger at random.  
 */
