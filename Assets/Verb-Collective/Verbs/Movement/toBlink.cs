/*
 * here
 * there
 * maybe there
 * or there
 * or maybe here
 * or there
 * 
 * Like a raindrop, 
 * you never know 
 * where it will fall
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toBlink : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("this determines the low random range in the X axis")]
    public float xRangeLow = 0.0f;

    [Tooltip("this determines the high random range in the X axis")]
    public float xRangeHigh = 0.0f;

    [Tooltip("this determines the low random range in the Y axis")]
    public float yRangeLow = 0.0f;

    [Tooltip("this determines the high random range in the Y axis")]
    public float yRangeHigh = 0.0f;

    [Tooltip("this determines the low random range in the Z axis")]
    public float zRangeLow = 0.0f;

    [Tooltip("this determines the high random range in the Z axis")]
    public float zRangeHigh = 0.0f;

    [Tooltip("If you want the random distance moved to be relative to an object check this box")]
    public bool relativeToReferenceObject;

    [Tooltip("Drag your reference gameObject into this field")]
    public Transform referenceObject;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;





    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {

            // The following lines of code create a value in each of the x, y, and z coordiantes, using a range of possible values selected in the inspector
            float xValue = Random.Range(xRangeLow, xRangeHigh);
            float yValue = Random.Range(yRangeLow, yRangeHigh);
            float zValue = Random.Range(zRangeLow, zRangeHigh);

            // If you are choosing a random position relative to a reference object
            if (relativeToReferenceObject)
            {
                // Your current position will be that objects current position added to the random values just created above
                transform.position = new Vector3(xValue + referenceObject.position.x, yValue + referenceObject.position.y, zValue + referenceObject.position.z);
            } 
            // If you are not using a reference object
            else if (!relativeToReferenceObject)
            {
                // Your current position will be moved directly to the coordinates randomly generated above
                transform.position = new Vector3(xValue, yValue, zValue);
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
 * This randomly teleports the object to a position relative to an existing object or to a specific set of world coordinates.  Users can select the possible ranges for each coordinate.
 */