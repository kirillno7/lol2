using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
    [SerializeField] private Transform _handPoint;
    [SerializeField] private Transform _headPoint;

    [SerializeField, Range(0f, 1f)] private float _handWeight;
    [SerializeField] private Vector3 _handOffset;
    [SerializeField, Range(0f, 1f)] private float _lookIKWeight;

    GameObject[] IntObj;
    GameObject Closest;

    private Animator _animator;

    public Vector3 MyPosition { get; private set; }
    public Vector3 IntObject { get; private set; }

    void Start()
    {
        _animator = GetComponent<Animator>();
        IntObj = GameObject.FindGameObjectsWithTag("InteractivniyObj");
    }

    GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (var go in IntObj)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance<distance)
            {
                Closest = go;
                distance = curDistance;
            }
        }
        return Closest;
    }
    private void Update()
    {
        var Closest = FindClosestEnemy();
         MyPosition = transform.position;
         IntObject = Closest.transform.position;

    }
    private void OnAnimatorIK(int layerIndex)
    {
        //if (_handPoint)
        //{
        //    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _handWeight);
        //    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _handWeight);

        //    _animator.SetIKPosition(AvatarIKGoal.LeftHand, _handPoint.position + _handOffset);
        //    _animator.SetIKRotation(AvatarIKGoal.LeftHand, _handPoint.rotation);
        //}
        if (_handPoint)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _handWeight);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _handWeight);

            _animator.SetIKPosition(AvatarIKGoal.RightHand, _handPoint.position + _handOffset);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _handPoint.rotation);
        }
        if (Vector3.Distance(MyPosition, IntObject) <2f)
        {
            _headPoint = Closest.transform;
            _animator.SetLookAtWeight(_lookIKWeight);
            _animator.SetLookAtPosition(_headPoint.position);
        }
       
    }
}
