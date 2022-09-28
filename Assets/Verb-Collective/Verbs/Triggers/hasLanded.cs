/*
 * Sure you have landed
 * but if not on the ground
 * bad luck buddy,
 * you're still falling down
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hasLanded : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||

    [Tooltip("If checked, any collision will activate triggered verb, otherwise, only the objects in the Ground Objects field will work ")]
    public bool useAnyCollision = true;

    [Tooltip("Drag GameObjects here to have them set as 'ground' objects")]
    public GameObject[] groundObjects;

    [Tooltip("Verbs dragged into this field will trigger when a collision with the 'ground' occurs")]
    public Verb[] triggeredVerbs;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {


        /*  This foreach loop uses 3 parameters 
         * 'GameObject' states that we are looking for that kind of thing
         * 'ground' is a stand in variable for the function
         * 'groundObjects' states the Array we will use
         *  --> For every object in the groundObjects array run the following script
         */ 
        
        foreach (GameObject ground in groundObjects)
        {
            //add a script called 'checker' to each object in the array
            ground.AddComponent<checker>();
        }
    }



    //     The OnCollisionEnter Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This function is called whenever there is a collision 
    // 'thisCollision' is a variable that holds info on the object collided with.
    void OnCollisionEnter(Collision thisCollision)
    {
        // if (it is active) AND (use any collision is turned on)
        if (isActive && useAnyCollision)
        {
            isActive = false;
            Activate(triggeredVerbs);
            
        }

        // if (it is active) AND (useAnyCollison is turned off) AND (the boolean (isGround) is set to true) 
        if (isActive && !useAnyCollision && thisCollision.gameObject.GetComponent<checker>().isGround == true)
        {

            isActive = false;
            Activate(triggeredVerbs);
            
        }
    }

    
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Very often we need to see if a game object has landed.  Such as a player jumping and checking to see if they landed on the ground, where other types of collision are possible.  This can also be used for all kinds of instances where you want to have different collisions generate different results.
 */

