/*
 * It isnt always love at first sight
 * sometimes it takes
 * one or two or even three times
 * 
 * If you want something to happen 
 * but want to make someone work
 * use this to test if they are willing to try
 * one or two or even three times
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toCount : Verb
{




    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
     


    [Tooltip("Choose how high you want to count to before the verbs trigger")]
    public int targetNumber = 5;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    //SerializeField is just making this private variable, below, visible in the Unity Editor.
    [SerializeField]
    [Tooltip("This is just here so you can see the current count in the editor view")]
    private int currentNumber = 0;




    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update () {

		if(isActive)
		{

            // Adds one to the current number
            currentNumber += 1;

            // if (the current number) is greater than (the number we are counting to)
			if(currentNumber >= targetNumber)
			{
                // trigger any verbs selected in inspector, restart the count, turn the verb off
				Activate(triggeredVerbs);
                currentNumber = 0;
				isActive = false;
                
			}

            // turns the verb off so that it only counts one number at a time.
			isActive = false;

        }
    }
}



//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb counts every time it is triggered, by setting a goal number you can trigger an effect that will occur after that many interactions.  An example would be a door opening after knocking on it twice.
 */
