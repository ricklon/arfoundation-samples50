/*
* Roses are Red 
* Violets are Blue
* The color this turns
* is up to you
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toColor : Verb
{
    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Range(0, 1)]
    [Tooltip("Use this to set a value for the amount of red between 1 and 0")]
    public float red = 0f;

    [Range(0, 1)]
    [Tooltip("Use this to set a value for the amount of green between 1 and 0")]
    public float green = 0f;

    [Range(0, 1)]
    [Tooltip("Use this to set a value for the amount of blue between 1 and 0")]
    public float blue = 0f;

    [Range(0, 1)]
    [Tooltip("Use this to set a value for the alpha, or transparency, between 1 and 0")]
    public float alpha = 0f;

    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private Material myColor;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {
        //This initializes the material that we named above, so that we can make changes to it
        myColor = GetComponent<Renderer>().material;
    }



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        // if (the variable isActive has been set to true)
        if (isActive)
        {
            // This creates a color using the values set in the inspector
            // It then initialize a renderer with the created material 
            Color newColor = new Color(red, green, blue, alpha);
            GetComponent<Renderer>().material.color = newColor;

            //The new color is now used in our object
            myColor.color = newColor;

            // Turns the Verb off and activates any verbs in the Triggered Verbs array.
            isActive = false;
            Activate(triggeredVerbs);
            
        }
    }

}



//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb changes the color of the object it is attached to 
 */
