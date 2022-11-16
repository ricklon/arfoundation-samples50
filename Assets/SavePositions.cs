using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePositions : MonoBehaviour
{

    //List of GameObjects
    [SerializeField] private List<GameObject> gobjects = new List<GameObject>();

    //List of positions
    [SerializeField] private List<Vector3> positions = new List<Vector3>();

    void Start()
    {
        //Add all objects to the list
        AddChildren();
        //save positions of the objects
        foreach (GameObject obj in gobjects)
        {
            positions.Add(obj.transform.position);
        }
    
    }

   //Reset the positions of the objects
    public void ResetPositions()
    {
        for (int i = 0; i < gobjects.Count; i++)
        {
            gobjects[i].transform.position = positions[i];
        }
    }

    //Random Move the objects to a new random position by a certain amount
    public void RandomMove(float amount)
    {
        foreach (GameObject obj in gobjects)
        {
            obj.transform.position = new Vector3(obj.transform.position.x + Random.Range(-amount, amount), obj.transform.position.y + Random.Range(-amount, amount), obj.transform.position.z + Random.Range(-amount, amount));
        }
    }
    

    //Add all children of the object to the list objects
    private void AddChildren()
    {
        foreach (Transform child in transform)
        {
           gobjects.Add(child.gameObject);
        }
    }

    

}
