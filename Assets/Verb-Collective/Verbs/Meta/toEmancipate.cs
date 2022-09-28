/*
 * I was young when I started 
 * my major movie career
 * and as much as I like you
 * I hold my millions more dear
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toEmancipate : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||  



    [Tooltip("Drag a gameobject here and it will be placed at the top of the hierarchy, leaving it blank will default to the current object")]
    public Transform childToFree;

    [Tooltip("List of verbs you want to be triggered by this verb")]
    public Verb[] triggeredVerbs;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    private void Start()
    {
        // If the adopted child field is left blank, this will make the current object become the adopted child
        if (childToFree == null)
        {
            childToFree = this.gameObject.transform;
        }
    }



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Update()
    {
        if (isActive)
        {
            
           
            //places the object at the top of the scene's hierarchy
            childToFree.SetParent(null);

           
            isActive = false;
            Activate(triggeredVerbs);
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * The selected game object will be moved to to the top of the hierarchy, meaning that it will not be parented to anything else in the scene.
 */
