/*
 * What is not dead
 * but is not alive?
 * What has weight 
 * but weighs nothing
 * has color 
 * but cannot be seen?
 * 
 * answer: 
 * The object that was disabled
 * before you triggered this verb
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toEnable : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Drag the gameobject you want to enable here")]
    public GameObject[] objectsToEnable;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Update()
    {
        if (isActive)
        {


           //for every item in the objectsToEnable array
            foreach (GameObject myObject in objectsToEnable)
            {
                //set the active status of the object to true
                myObject.SetActive(true);
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
 * This verb will make the target object active.
 */
