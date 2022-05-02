using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _player;
    [SerializeField] private float _distance;
    [SerializeField] private float _enemyDistanseRadius;
    [SerializeField] private float _enemyDistanseAttack;

    private bool _playerInRange;

    private Animator _animator;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void RunToPlayer()
    {
        _navMeshAgent.enabled = PlayerInRange();

        _navMeshAgent.SetDestination(_player.position);
        _animator.SetTrigger("Run");    
    }

    private void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    private bool ReadyToAttack()
    {
        return _enemyDistanseAttack > _distance;
    }

    private bool PlayerInRange()
    {
        return _distance < _enemyDistanseRadius;
    }

    private void StayIdle()
    {
        _animator.SetTrigger("Idle");
    }

    void Update()
    {
        _distance = Vector3.Distance(_player.position, transform.position);

        if (PlayerInRange() && !ReadyToAttack())
        {
            RunToPlayer();
        }
        else if(PlayerInRange() && ReadyToAttack())
        {
            Attack();
        }
        else
        {
            StayIdle();
        }
        
         
    }
}
