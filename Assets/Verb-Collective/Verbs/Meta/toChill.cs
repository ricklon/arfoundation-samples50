/*
 * Please don't go away forever
 * or die or even leave at all
 * just, like, I dont know
 * chill out for a while
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toChill : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("these verbs will turn off when this is activated")]
    public Verb[] verbsToChill;

    [Tooltip("these verbs will trigger when this is activated")]
    public Verb[] triggeredVerbs;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {
            // Deactivate the verbs to chill and activate the triggered verbs
            Deactivate(verbsToChill);
            isActive = false;
            Activate(triggeredVerbs);
            
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Turns off verbs in the verbsToChill array.  This is one of the more useful verbs that allows you to have more control over what is happening in the scene.
 */
