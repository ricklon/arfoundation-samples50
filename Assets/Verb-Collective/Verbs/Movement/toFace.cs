/*
 * Wherever you go,
 * I will find you.
 * Everything you do,
 * I can see.
 * Its not that I am creepy
 * but that something triggered me
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toFace : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Choose how quickly you want the object to turn")]
    public float speed = 1.0f;

    [Tooltip("Drag the gameobject you want to face another object here.  It will default to this object if left blank.")]
    public Transform observer;

    [Tooltip("Drag the gameobject you want to turn towards here. It will also default to this object if left blank.")]
    public Transform theObserved;

    [Tooltip("Turn this on if you want to effect to be perpetual rather than having it stop when successfully looking at the object")]
    public bool constant;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // Holds whether the verb has just played or not
    private bool justPlayed = false;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    void Start()
    {
        // If the Object to rotate field was left blank
        if (observer == null)
        {
            // Make this object the object to rotate
            observer = this.gameObject.transform;
        }

        // If the object to be observed field was left blank
        if (theObserved == null)
        {
            // Make this object the object to rotate
            theObserved = this.gameObject.transform;
        }
    }



    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void FixedUpdate () {

		if(isActive)
		{

            // Time.deltaTime converts speed from per frame to per time. Makeing the motion smooth.
            var step = Time.deltaTime * speed;
            
            //Finds the normalized difference between object and target object position.
			Vector3 targetRot = Vector3.Normalize(theObserved.position - observer.transform.position);
            
            //Sets the necessary rotation speed to keep focus on target object
			Vector3 newDir = Vector3.RotateTowards(observer.forward, targetRot, step, 0.0f);
            
            //Keeps the object from rotating beyond the scope of the target object
			observer.rotation = Quaternion.LookRotation(newDir);

            justPlayed = true;

            // If the verbs does NOT constantly run AND the observer is looking exactly at the observed
            if (!constant && Vector3.Dot(observer.forward, targetRot) >= 1.0f)
            {
                isActive = false;
                Activate(triggeredVerbs);
            }

            // If the verb is NOT active AND it has just played
            if (!isActive && justPlayed)
            {
                justPlayed = false;
                Activate(triggeredVerbs);
            }          
		}
	}
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * The object will have one object rotate to face another object. The speed at which the object rotates is set by the user. The user can also choose if this happens once or continuously.
 */
