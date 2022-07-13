using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{


    [SerializeField] GameObject obj2;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Inventory>().TakeKey();
            obj2.active = false;
        }
    }
}
