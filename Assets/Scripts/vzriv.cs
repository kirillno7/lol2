using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vzriv : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] float force;
    [SerializeField] float radius;

 

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthController>().GetDamage(Damage);
            Collider[] col = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider c in col)
            {
                c.GetComponent<Rigidbody>().AddForce(transform.forward * force);
            }
            gameObject.SetActive(false);
        }
    }
   
}
