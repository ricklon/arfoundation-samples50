/*
 * You are playing a game
 * and you defeat the big boss
 * you score the maximum points
 * and never have lost
 *
 * Go to the next level
 * and see something new
 * load a new scene
 * and find something to do
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The package below is required
using UnityEngine.SceneManagement;

public class toLoad : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Carefully type the name of the scene you want to load, make sure to include that scene in your build")]
    public string nextScene;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {
           
            // this loads the scene named in the inspector
            SceneManager.LoadScene(nextScene);
            
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb will load a new scene. Scene is provided by user. Be sure to include the scene in the build settings or this will not work.
 */
