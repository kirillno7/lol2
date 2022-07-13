using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [Range(0, 360)] public float ViewAngle = 90f;
    public float ViewDistance = 15f;
    public Transform EnemyEye;
    public Transform Target;

    private NavMeshAgent _agent;
    [SerializeField] Transform[] PatrolPositions;
    [SerializeField] int PatrolIndex = 0;
    [SerializeField] float Damage;
    bool isHunting = false;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        _agent.destination = PatrolPositions[PatrolIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance<_agent.stoppingDistance +0.25f && isHunting==false)
        {
            PatrolIndex = (PatrolIndex+1)% PatrolPositions.Length;
            _agent.destination = PatrolPositions[PatrolIndex].position;
        }
        if (IsInView())
        {
            isHunting = true;
            MoveToTarget();
        }
        else
        {
            isHunting = false;
        }
    }
    private bool IsInView() // true если цель видна
    {
        float realAngle = Vector3.Angle(EnemyEye.forward, Target.position - EnemyEye.position);
        RaycastHit hit;
        if (Physics.Raycast(EnemyEye.transform.position, Target.position - EnemyEye.position, out hit, ViewDistance))
        {
            if (realAngle < ViewAngle / 2f && Vector3.Distance(EnemyEye.position, Target.position) <= ViewDistance && hit.transform == Target.transform)
            {
                return true;
            }
        }
        return false;
    }
    private void MoveToTarget() // устанвливает точку движения к цели
    {
        _agent.SetDestination(Target.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<HealthController>().GetDamage(Damage);
        }
    }

}
