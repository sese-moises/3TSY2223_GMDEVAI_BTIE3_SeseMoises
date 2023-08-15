using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent _agent;
    public GameObject _player;
    public Transform _origin;
    public AgentManager _aM;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = 150f;
        _agent.angularSpeed = 500f;
        Invoke("Lifetime", 240);
    }

    private void Update()
    {
        _agent.SetDestination(_player.transform.position);
    }

    void Lifetime()
    {
        _aM._enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
