using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPoint : MonoBehaviour
{
    private MoveCharacter _player;

    private void Start()
    {
        _player = GetComponent<MoveCharacter>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);

            _player.MoveToPoint(hit.point);
        }

    }
}
