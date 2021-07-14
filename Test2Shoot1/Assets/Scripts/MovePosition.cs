using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePosition : MonoBehaviour
{

    private NavMeshAgent _agent;
    private int i = 0;

    [SerializeField] private List<GameObject> _targets;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        _agent.destination = _targets[i].transform.position;
    }
    public void MoveNextPoint()
    {
        i++;
    }

}
