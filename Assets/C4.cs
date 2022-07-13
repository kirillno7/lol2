using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4 : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] float radius;
    [SerializeField] float force;
    [SerializeField] AudioSource Audio;
    [SerializeField] ParticleSystem _particleSystem;
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<HealthController>().GetDamage(Damage);
            Audio.Play();
            _particleSystem.Play();
            Collider[] overlappedColliders = Physics.OverlapSphere(transform.position,radius);
            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
                if (rigidbody != null)
                {
                    rigidbody.AddForce(transform.forward * force);
                }
            }
            //gameObject.SetActive(false);
        }
    }
    
}
