/*
* The world can be lonely
* the world can be dull
* if you want to make it busy
* add something new
* use this verb to add things
* no need to feel blue
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toSpawn : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Drag the gameobject you want to spawn here, you can add prefabs from your project navigation window")]
    public GameObject theCreated;

    [Tooltip("Select this to use coordinates")]
    public bool useCoordinates = false;

    [Tooltip("Select the coordinates where you want the spawned object to appear")]
    public Vector3 spawnPoint;

    [Tooltip("Select this to use another game object's position to spawn the created object")]
    public bool useTargetObject = false;

    [Tooltip("Select the coordinates where you want the spawned object to appear")]
    public Transform targetObject;

    [Tooltip("Turn this on if you want this object to die after triggering")]
    public bool destroyOnBirth;

    [Tooltip("these verbs will trigger when this is activated")]
    public Verb[] triggeredVerbs;
   


    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||


 

    private void Update()
    {
        if (isActive)
        {
          
            if (useCoordinates)
            {
                //Instantiates a clone of the object provided in the inspector at the spawn point coordinates selected.
                //Quaternion.identity is setting the rotation of the object
                Instantiate(theCreated, spawnPoint, Quaternion.identity);
            }

            else if (useTargetObject)
            {
                //Instantiates a clone of the object provided in the inspector at the location of the target object
                Instantiate(theCreated, targetObject.position, targetObject.rotation); 
            }
            
            else if (!useCoordinates && !useTargetObject)
            {
                //Instantiates a clone of the object provided in the inspector at the location of this object is neither boolean was selected
                Instantiate(theCreated, transform.position, transform.rotation); 
            }

            // If Destroy on Birth is turned on
            if (destroyOnBirth)
            {
                Destroy(gameObject);
            }

           
            isActive = false;
            Activate(triggeredVerbs);
        }

    }
}
/*
 * Object will spawn, or be created, at a target location(spawnPoint), at the location of a target object, or at this objects location if neither of those options is selected. User provides the type of object that spawns(theCreated) as well as the target location. User can also decide if the Object the verb is on will destroy at the end of this verb. Generally the spawned object(theCreated) should not be a copy of the object to spawn is attached to.
 */
