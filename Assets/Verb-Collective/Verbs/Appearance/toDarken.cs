/*
* From Twilight to Darkness
* The passing of time
* darkens the sky,
* then-- in the morning--
* returns it to light
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toDarken : Verb
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

    [Tooltip("Turn this on if you want the color to get brighter instead")]
    public bool brightenInstead = false;

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
        //This initializes the variable we created at the top
        myColor = GetComponent<Renderer>().material;
    }



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {
            // If (it is NOT set to bright instead)
            if (!brightenInstead) 
            {
                // This creates a new color using the values from the inspector and adding them to the current color 
                // then it replaces the old color with the new one 
                Color newColor = new Color(-red, -green, -blue, -alpha) + myColor.color;
                myColor.color = newColor; 
            }
            

            //if (it is set to brighten instead)
            if (brightenInstead) 
            {
                // This creates a new color using the  values from the inspector and subtracting them from the current color 
                // then it replaces the old color with the new one 
                Color newColor = new Color(red, green, blue, alpha) + myColor.color;
                myColor.color = newColor; 
            }


            isActive = false;
            Activate(triggeredVerbs);

        }
    }

}



//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb changes the color of the object it is attached to by adding or substracting to one or more of the RGBA color fields
 */
