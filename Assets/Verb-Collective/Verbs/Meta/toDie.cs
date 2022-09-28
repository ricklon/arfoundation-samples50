/*
 * You seem really nice
 * friendly and kind
 * so I'm sad to say it
 * but you're going to die
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toDie : Verb 
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("List of verbs you want to be triggered by this verb")]
    public Verb[] triggeredVerbs;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Update()
    {
        if (isActive)
        {
            Activate(triggeredVerbs);
            isActive = false;

            //destroys the game object this script is attached to
            Destroy(this.gameObject);


        }
    }
}
/*
 * The object subject to this verb will be destroyed, or removed from the scene.
 */
