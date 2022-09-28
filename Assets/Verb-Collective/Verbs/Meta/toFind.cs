/*
 * No lie,
 * Not to you
 * This is just for showing
 * how finding works
 * - it's true
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toFind : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
    [Tooltip("Type the name of the game object you want found in here")]
    public string nameOfObjectToFind = "example";

    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||

    private Material foundMaterial;

    private GameObject found;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||

    void Update()
    {
        if (isActive)
        {

            
            found = GameObject.Find(nameOfObjectToFind);
            foundMaterial = found.GetComponent<Renderer>().material;
            foundMaterial.color = Color.yellow; 


            

         
            EndVerb();
            Activate(triggeredVerbs);

        }
    }
}
/*
 * Finds the a specific game object within your hierarchy. Grabs the renderer component of that object
 * and changes the material to yellow
 */
