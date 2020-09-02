using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchLocation 
{
    public int touchID;
    public GameObject planet;

    public touchLocation(int ID, GameObject pl)
    {
        touchID = ID;
        planet = pl;
    }
}
