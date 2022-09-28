/*
* Peek a boo
* I see you
* 
* If can you see me
* you will see what I do
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whileVisible : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("How far can the GazingObject object see")]
    public float visibleRange = 10f;

    [Tooltip("Which object do you want to have looking for this object? A camera is a common choice.")]
    public Transform GazingObject;

    [Tooltip("Check this box if the object being gazed at is the one this component is on.")]
    public bool useMyself = true;

    [Tooltip("Check this box if the object being gazed at is the one dragged into the following field.")]
    public bool useTheWatched = false;

    [Tooltip("Which object do you want to check for if not the one this verb is attached to?")]
    public GameObject theWatched;

    [Tooltip("List of verbs you want to be triggered by this verb")]
    public Verb[] triggeredVerbs;




    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    // This holds the information about this current object once it is initialized in the start functiuon
    private GameObject myself;

    private bool justPlayed;


    private void Start()
    {
        // This initializes the myself variable to be connected to the current object.
        myself = this.gameObject;
    }




    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    void FixedUpdate()
    {
        if (isActive)
        {
            // This creates an empty holder for the raycast contact information
            RaycastHit hit;

            // If a Ray hits something (starting from the position of the Gazing Object, in its forward axis, then output the information of that hit as 'hit', as long as it is within the visible range
            if (Physics.Raycast (GazingObject.position, GazingObject.forward, out hit, visibleRange))
            {
                // If the object hit by the ray is this one AND useMyself is turned on
                // OR
                // If the object hit by the ray is the one selected in the inspector, and useTheWatched is turned on
                if (hit.collider.gameObject == myself && useMyself || hit.collider.gameObject == theWatched && useTheWatched)
                {
                    if (!justPlayed)
                    {
                        Activate(triggeredVerbs);
                        justPlayed = true;
                    }        
                }

                // Otherwise
                else
                {
                    // deactivate the verbs  
                    Deactivate(triggeredVerbs);
                    justPlayed = false;
                }
                
            }

            // Uncomment the line below to get a visual cue as to what the line of visibility looks like
             Debug.DrawRay(GazingObject.position, GazingObject.forward * visibleRange, Color.green);


        }
    }

}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
* Triggers when the object is looked at. User can provide a threshold for how central to the camera an object needs to be to be considered visible
*/
