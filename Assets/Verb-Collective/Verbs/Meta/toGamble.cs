/*
 * It might not be poker
 * and certainly isn't roulette
 * but when you trigger this verb
 * nobody knows what you'll get
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toGamble : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Drag any prefab objects into this field and one of the objects inside the array will instantiate at random each time it is triggered")]
    public GameObject[] randomObjects;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||


    // This holds a randomly generated integer and it is then used as the index for the random object array during instantiation
    private int randomIndex;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {

            // Generate a random number between 0 and the number of objects in the random objects array
            int randomIndex = Random.Range(0, randomObjects.Length);

            // Instantiate an object, selected from the array of random objects, at the attached object's position, with it's current rotation
            Instantiate(randomObjects[randomIndex], transform.position, transform.rotation);

            isActive = false;
            Activate(triggeredVerbs);
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Generates a random object using options selected from those added to the inspector.
 */
