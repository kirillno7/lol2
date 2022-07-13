using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class RagDollController : MonoBehaviour
{
    private Rigidbody[] _rbs;
    private Collider[] _colliders;

    private Animator _animator;
    private NavMeshAgent _agent;
    private AICharacterControl _control;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _control = GetComponent<AICharacterControl>();

        _rbs = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        //Kill();
    }

    private void SetRagDoll(bool IsActive)
    {
        foreach (var rb in _rbs)
        {
            rb.isKinematic = !IsActive;
            if (IsActive)
                rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        foreach (var collider in _colliders)
        {
            collider.enabled = IsActive;
        }
        _rbs[0].isKinematic = IsActive;
        _colliders[0].enabled = !IsActive;
    }
   public void Kill()
    {
        SetRagDoll(true);
        _animator.enabled = false;
        //_agent.enabled = false;
        //_control.enabled = false;
    }
    public void Revive()
    {
        SetRagDoll(false);
        _animator.enabled = true;
        //_agent.enabled = true;
        //_control.enabled = true;
    }
}
