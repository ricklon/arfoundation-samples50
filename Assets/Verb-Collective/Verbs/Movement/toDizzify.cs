/*
 * Left or right
 * up or down
 * Im looking for a direction
 * that cant be found
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toDizzify : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||

    [Tooltip("Drag here the gameobject you want to make dizzy.  It will default to this object if left blank")]
    public GameObject ObjectToMakeDizzy;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;




    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    void Start()
    {
        // If the Object to make dizzy field was left blank
        if (ObjectToMakeDizzy == null)
        {
            // Make this object the object to dizzify
            ObjectToMakeDizzy = this.gameObject;
        }
    }




    //     The FixedUpdate Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void FixedUpdate()
    {
        if (isActive)
        {
            // Sets the object object to have a random rotation
            ObjectToMakeDizzy.transform.rotation = Random.rotation;

            isActive = false;
            Activate(triggeredVerbs);
            
        }

    }

}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Rotates attached object in a random direction.
 */
