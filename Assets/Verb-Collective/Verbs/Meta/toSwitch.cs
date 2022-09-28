/*
 * Take an object (s)
 * Make it go
 * Take another object (s)
 * Make it show
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toSwitch : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
     



    [Tooltip("Any gameobjects that you drag into this field will be disactivated")]
    public GameObject[] remove;

    [Tooltip("Any gameobjects that you drag into this field will be activated")]
    public GameObject[] replace;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Update()
    {

        if (isActive)
        {

            // For every 'item' in the remove array, take that item and set it to false, deactivating it
            foreach (GameObject item in remove)
            {

                item.SetActive(false);
            }

            // For every 'item' in the replace array, take that item and set it to true, activating it
            foreach (GameObject item in replace)
            {
                item.SetActive(true);
            }

            //this will end this condition once it passes through a single time
            isActive = false;
            Activate(triggeredVerbs);

        }
    }
}

//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb switches out objects by turning an array of objects off and then turning a second array of objects on.
 */
