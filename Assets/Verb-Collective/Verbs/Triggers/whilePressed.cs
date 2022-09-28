/*
* Some things happen once
* some a little at a time
* as long as this key is down
* a little works just fine
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whilePressed : Verb {




    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    [Tooltip("Type the name of the key you want to act as a trigger - example 1: a example 2: space - see https://docs.unity3d.com/ScriptReference/KeyCode.html for more options")]
    public string keyCode;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;


    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // this holds whether the verb has triggered yet
    private bool justPlayed = false;




    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update ()
	{
        if (isActive)
        {

            // when the key defined in the inspector is down AND the verb has NOT already been triggered
            if (Input.GetKeyDown(keyCode) && !justPlayed)
            {   
                Activate(triggeredVerbs);
                justPlayed = true;
            }

            // when the key defined in the inspector goes up
            else if (Input.GetKeyUp(keyCode))
            {              
                Deactivate(triggeredVerbs);
                justPlayed = false;
            }

        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
* Triggers for the duration that a key is held down. Deactivates when the key is no longer pressed. The user provides the key to be pressed
*/
