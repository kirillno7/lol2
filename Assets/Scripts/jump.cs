using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    [SerializeField] float Visota = 500;
    public bool isGrounded;

    private void OnCollisionEnter()
    {
        isGrounded = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded=false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, Visota, 0));
        }
    }
}
