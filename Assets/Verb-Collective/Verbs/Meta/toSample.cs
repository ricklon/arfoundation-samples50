/*
 * Copy and paste this for quick verb making
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toSample : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Any verbs added to this array will trigger when this is activated")]
    public Verb[] triggeredVerbs;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {
        //Initialize variables here if required
    }
    


    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



   private void Update()
    {
        if (isActive)
        {

            //Debugging message
            Debug.Log("I am");

            //Remove comments below to enable a conditional statement for ending the verb
            // if ()
            //{         
            isActive = false;
            Activate(triggeredVerbs);
            //}
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Copy and paste this verb for quick verb making
 */
