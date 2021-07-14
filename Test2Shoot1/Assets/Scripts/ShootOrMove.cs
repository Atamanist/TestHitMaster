using UnityEngine;


public class ShootOrMove : MonoBehaviour
{
    private bool _move = true;
    private bool _shoot = false;
    [SerializeField] private MovePosition _canMove;
    [SerializeField] private GunShoot _gun;
    [SerializeField] private Animator _anim;

    private void Start()
    {
        _anim.SetBool("Run Forward", true);

    }

    void Update()
    {
        if(Input.touchCount>0)
        {
            if(_move)
            {
                _canMove.MoveNextPoint();
                _move = false;
                _anim.SetBool("Run Forward", true);
            }
            if (_shoot)
            {
                Touch touch = Input.GetTouch(0);
                Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out RaycastHit hit);
                _gun.ShootBullet(hit.point);
            }
        }
    }

    public void CanMove()
    {
        _move = true;
    }

    public void CanShoot()
    {
        _shoot = !_shoot;
    }

    public void Idle()
    {
        _anim.SetBool("Run Forward", false);
    }

}
