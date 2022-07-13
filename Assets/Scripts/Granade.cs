using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] GameObject gr;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform gr_move = Instantiate(gr.transform, gameObject.transform.position, Quaternion.identity);
            gr_move.GetComponent<Rigidbody>().AddForce(transform.forward * 1500);
        }
        
    }
}
