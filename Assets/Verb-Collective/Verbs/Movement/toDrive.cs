/*
 * I tend move 
 * as fast as I can
 * but if it weren't for this script
 * there would be no gas in the can
 */

using UnityEngine;


public class toDrive : Verb
{




    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [SerializeField]
    [Tooltip("This is just to let you know of any valid requirements")]
    private string Requirement = "This uses a rigidbody and physics, adjust drag, angular drag, and mass to get the right feel";

    [Tooltip("Multiplied by the forward direction to determine velocity")]
    public float speed = 1.0f;

    [Tooltip("Multiplied by angle of rotation to determine how fast you turn")]
    public float turnSpeed = 1.0f;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This holds the values coming from Unity's input system for making things move left and right
    private float horizontalInput;

    // This holds the values coming from Unity's input system for making things move forward and backwards
    private float verticalInput;

    // This holds information about whether the verb has recently played or not
    private bool justPlayed = false;

    // This holds the rigid body information after getting initialized in the start function
    private Rigidbody myRigidBody;




    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {
        // This initializes the myRigidBody variable so that it can be used to affect this object
        myRigidBody = GetComponent<Rigidbody>();

    }



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {

            // Both of these declarations connect the two variables, horizontalInput and verticalInput, to Unity's input system.  This means they will return a value between -1 and 1, that transitions smoothly, based on a variety of key presses or controller inputs
            // These are in the update function rather than the fixed update function because we want the inputs to get a response before the physics are updated.
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
    }



    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void FixedUpdate()
    {

        if (isActive)
        {

            //This make the object move forward relative to the speed variable and the vertical input variable, time.deltatime is used to make it reference seconds rather than frames
            myRigidBody.AddForce(transform.forward * Time.deltaTime * speed * verticalInput, ForceMode.Impulse);

            //This make the object rotate in the Y axis relative to the speed variable and the horizontal input variable, time.deltatime is used to make it reference seconds rather than frames
            myRigidBody.AddTorque(transform.up * Time.deltaTime * turnSpeed * horizontalInput, ForceMode.Impulse);

            justPlayed = true;

        }

        if (!isActive && justPlayed)
        {
            justPlayed = false;
            Activate(triggeredVerbs);
        }

    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This is really just a generic controller device for moving an object the way that a car drives.  Created for the demo it contains helpful code for using the input system.
 */
