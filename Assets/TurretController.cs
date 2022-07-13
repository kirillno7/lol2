using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TurretController : MonoBehaviour
{
    [SerializeField] float VisionRadius = 10;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float CooldownTime;
    [SerializeField] Transform Joint;
    [SerializeField] Transform AmmoHead;
    [SerializeField] float RotationSpeed = 1;


    private SphereCollider _visionCollider;
    private Transform _playerPos;
    private float _currentTime;
    void Awake()
    {
        _visionCollider = GetComponent<SphereCollider>();
    }

    void Start()
    {
        _visionCollider.radius = VisionRadius;
        _currentTime = CooldownTime;
    }

    void Update()
    {
        if (_playerPos != null)
        {
            _currentTime += Time.deltaTime;
            var rotDirection = _playerPos.position - Joint.position;
            var targetRotation = Quaternion.LookRotation(rotDirection.normalized);
            Joint.rotation = Quaternion.Lerp(Joint.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
        Debug.DrawRay(AmmoHead.position, AmmoHead.forward * 100, Color.red);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerPos = other.gameObject.transform;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _currentTime >= CooldownTime)
        {
            var bullet = Instantiate(BulletPrefab, AmmoHead.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().TargetPos = _playerPos.position;
            _currentTime = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerPos = null;
        }
    }
}
    
