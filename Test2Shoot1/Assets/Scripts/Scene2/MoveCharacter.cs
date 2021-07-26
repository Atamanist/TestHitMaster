using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCharacter : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Vector3 _point;
    private Animator _anim;
    private bool _move=false;
    [SerializeField] private GameObject _panel;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if(_move)
        {
            _agent.destination = _point;
            if(Vector3.Distance(transform.position,_agent.destination)<0.5f)
            {
                _move = false;
                _anim.SetBool("Run Forward", _move);
                _panel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void MoveToPoint(Vector3 point)
    {
        _point = point;
        _move = true;
        _anim.SetBool("Run Forward", _move);

    }

}
