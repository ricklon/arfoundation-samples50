/*
 * Language is lovely
 * special and fine
 * but I can do more
 * when the letters are mine
 * 
 * Whatever you type
 * any letter will do
 * changes the world
 * I do that for you
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenTyped : Verb {




    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Type the name of the key you want to act as a trigger - example 1: a example 2: space - see https://docs.unity3d.com/ScriptReference/KeyCode.html for more options")]
    public string keyCode;

    [Tooltip("Use this if you only want the effect to happen once")]
    public bool useOnce = false;
    
    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;




    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    void Update ()
	{

        if (isActive)
        {
            // If the key named in the inspector in pressed down
            if (Input.GetKeyDown(keyCode))
            {           
                Activate(triggeredVerbs);

                // If you selected to use the verb once
                if (useOnce)
                {
                    isActive = false;
                }
            }
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Triggers when the user types a key whose keycode has been typed in the inspector
 */
