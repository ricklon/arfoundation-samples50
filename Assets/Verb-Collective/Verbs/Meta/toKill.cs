/*
 * It isn't nice to murder, 
 * that is obviously true,
 * but with roaches and weeds
 * don't stop till you're through 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toKill : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Drag the Object(s) to kill into this field")]
    public GameObject[] victims;

    [Tooltip("If this is turned on the verb will kill any object with the appropriate tag")]
    public bool useTags = false;

    [Tooltip("provide the name of a tag to target")]
    public string tagToKill;

    [Tooltip("If this is turned on the verb will kill an object with the appropriate name")]
    public bool useName = false;

    [Tooltip("Provide the name of the object to target")]
    public string nameToKill;

    [Tooltip("List of verbs you want to be triggered by this verb")]
    public Verb[] triggeredVerbs;

    

    //     Private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||

    // This holds the object named in the inspector so that it can be destroyed
    private GameObject victimByName;

    // This holds the objects with the tag defined in the inspector so that they can be destroyed
    private GameObject[] victimsByTag;





    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Update()
    {
        if (isActive)
        {

            // If the victims array is NOT empty
            if (victims != null)
            {
                //for every item in the victims array, with unfortunateOne being a placeholder variable
                foreach (GameObject unfortunateOne in victims)
                {
                    //destroy those items
                    Destroy(unfortunateOne);
                } 
            }

            // If use tags has been selected
            if (useTags)
            {

                //for every item in the victims array, with unfortunateOne being a placeholder variable
                victimsByTag = GameObject.FindGameObjectsWithTag(tagToKill); 

                //for every item in the victimsByTag array, with unfortunateOne being a placeholder variable
                foreach (GameObject unfortunateOne in victimsByTag)
                {
                    //destroy those items
                    Destroy(unfortunateOne);
                } 
            }

            // If use name has been selected
            if (useName)
            {
                // This finds an object with correct name and connects it to the variable victimByName
                victimByName = GameObject.Find(nameToKill);

                    //destroy that item
                    Destroy(victimByName);
 
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
 * The objects in the victims field will all be killed, or removed from the scene.  You can also use this to kill all objects with the same name or the same tag. Note that when killing by name it will only kill one object, even if multiple ones in the scene have the same name.
 */
