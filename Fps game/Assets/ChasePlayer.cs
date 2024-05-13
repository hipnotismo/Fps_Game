using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform player;

    /// <summary>
    /// Gets current nav mesh in the game object
    /// </summary>
    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Moves game object to the player transform
    /// </summary>
    private void Update()
    {
        enemy.SetDestination(player.position);
    }

}
