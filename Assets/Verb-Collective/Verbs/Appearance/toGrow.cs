/*
 * Like a seed in the ground
 * watered by rain
 * whatever this controls
 * gets bigger by day
 * 
 * (it can shrink things too!)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toGrow : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
     


    [Tooltip("Select how much you want the object to grow.  A value between 0 and 1, such as .5, will shrink it instead")]
    public float growMultiplier = 2.0f;

    [Tooltip("Choose how long you want the growth to take")]
    public float duration = 3.0f;

    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||


  
    // This variable holds the amount of time that has passed
	private float timePassed;
    // This holds the initial scale of the object
	private Vector3 StartScale;
    // This holds the desired scale of the object
	private Vector3 FinalScale;
    // This notes whether the verb has been conjugated or not
    // this is used for verbs that evolve over time 
    private bool conjugated;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update () {

		if(isActive)
		{
            //If the verb has NOT been conjugated 
            if (!conjugated)
            {
                // This calls the conjugate function to initialize the transformation
                Conjugate();
            }

            //This will set the scale of the object to a given point between start and final scales
            transform.localScale = Vector3.Lerp(StartScale, FinalScale, timePassed);
			timePassed += Time.deltaTime / duration;


            // if the timePassed variable is greater than 1, that means the transformation is complete 
            if (timePassed >= 1.0f)
			{

                // Reset the transformations and end the verb
                conjugated = false;
                isActive = false;
                Activate(triggeredVerbs);
			}
		}
	}



    //     The custom Conjugate Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



 public void Conjugate () {
        /*
         * Takes the private variables of StartScale and FinalScale and resets them. 
         * This is useful because it allows the object to continue growing from whatever size it was when the verb triggered.
         */
		StartScale = this.transform.localScale;
		FinalScale = StartScale * growMultiplier;
		timePassed = 0.0f;
        conjugated = true;
        
	}

}



//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * The object will grow at a variable rate/multiplier for a duration of time, the user sets the rate and duration in the inspector.
 */
