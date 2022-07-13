using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool Doorkey = false;
    public void TakeKey()
    {
        Doorkey = true;
    }
    public bool CompareKey()
    {
        return Doorkey;
    }
    
}
