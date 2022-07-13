using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject obj5;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var check =other.gameObject.GetComponent<Inventory>().CompareKey();
            if (check == true)
            {
                SceneManager.LoadScene(2);
                obj5.active = false;
            }
            else
            {
                Debug.Log("You dont have key");
            }
            
        }
    }
}
