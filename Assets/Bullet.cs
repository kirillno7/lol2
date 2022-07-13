using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float BulletSpeed = 1;
    [SerializeField] float Damage;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public Vector3 TargetPos
    {
        get => _targetPos;
        set
        {
            _isShooted = true;
            _targetPos = value;
        }
    }


    private bool _isShooted = false;
    private Vector3 _targetPos;

    void Update()
    {
        if (_isShooted && Vector3.Distance(transform.position, _targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, BulletSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<HealthController>().GetDamage(Damage);
            gameObject.SetActive(false);
        }
    }
}