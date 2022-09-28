/*
 * Please don't die
 * but do go away
 * come back if I need you
 * on some other day 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toDisable : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Drag the gameobjects you want to disable here")]
    public GameObject[] objectsToDisable;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Update()
    {
       
        if (isActive)
        {
            // for every item in objectsToDisable array set the object active status to false
            foreach (GameObject myObject in objectsToDisable)
            {
                // Set each of the objects in the array to deactivate.  We use isActive a lot in the Verb Colective but this does not refer to a variable within a component, but to the entire game object.
                myObject.SetActive(false);
            }
   
            Activate(triggeredVerbs);
            isActive = false;

        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb will deactivate a target object.
 * Deactivated objects are still present in the scene but are invisible and inactive while deactivated.
 */
