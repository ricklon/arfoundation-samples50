/*
 * What do you know,
 * you can't remember that night,
 * it was so long ago 
 * so maybe I'm right
 * this will prove Im your child
 * and then you will see
 * wherever you go
 * there I will be 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toAdopt : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||  



    [Tooltip("Drag a gameobject here and it will become a child of the parent object, leaving it blank will default to the current object")]
    public Transform adoptedChild;

    [Tooltip("Drag a gameobject here to make it the parent of the other object in the hierarchy")]
    public Transform newParent;

    [Tooltip("List of verbs you want to be triggered by this verb")]
    public Verb[] triggeredVerbs;





    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    private void Start()
    {
        // If the adopted child field is left blank, this will make the current object become the adopted child
        if (adoptedChild == null)
        {
            adoptedChild = this.gameObject.transform;
        }
    }



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Update()
    {
        if (isActive)
        {
            
           
            //places the adopted child below the new parent object in the hierarchy of the scene
            adoptedChild.SetParent(newParent);

           
            isActive = false;
            Activate(triggeredVerbs);
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * The adopted child will be attached to a new parent object by making it a child of the parent in the scene's hierarchy. Making this Verb useful for combining objects
 */
