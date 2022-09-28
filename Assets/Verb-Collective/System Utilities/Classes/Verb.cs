using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verb : MonoBehaviour {

    [Tooltip("These are notes for your edification, to help remember what a verb does or how you are using this particular one, also useful for sharing thoughts with collaborators in the interface view.")]
    public string NotesToSelf;

    [Tooltip("Turn this on to have the verb be active on start")]
    public bool isActive;

    //___________________________________________________    
    //___________________________________________________

    public void Activate(Verb[] verbs)
    {
        foreach (Verb item in verbs)
        {
            if (item)
            {
                item.isActive = true;
                //item.Conjugate();
            }
        }
    }

    //___________________________________________________    
    //___________________________________________________

    public void Activate(Verb verbs)
    {
                verbs.isActive = true;       
    }


    //___________________________________________________    
    //___________________________________________________

    public void Deactivate(Verb[] verbs)
    {
        foreach (Verb item in verbs)
        {
            if (item)
            {
                item.isActive = false;
            }
        }
    }

    //___________________________________________________    
    //___________________________________________________

    public virtual void EndVerb()
    {
        isActive = false;
	}


}
