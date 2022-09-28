/*
 * trigger this
 * and thats it,
 * there isn't any more
 * 
 * no, really
 * bye
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toQuit : Verb
{


    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {



        if (isActive)
        {
            //quits the application
            Application.Quit();
            
        }
    }
}
/*
 * Usually triggered by the escape key, this quits a built application.  I find it always helps to have a quick way to exit an application and this can attached anywhere in the scene.
 */
