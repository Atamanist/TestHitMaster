using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _delta;
    [SerializeField] private Animator _anim;
    private bool _shoot;
    private float _timer;
    [SerializeField] private float _timerSet;

    private void Start()
    {
        _timer = _timerSet;
    }

    public void ShootBullet(Vector3 target)
    {
        if(_shoot==true)
        {
            _anim.SetTrigger("Attack 01");
            _shoot = false;
            Instantiate(_bullet, transform.position, Quaternion.identity)
                .GetComponent<Fireball>()
                .SetTarget(target);
            _timer = _timerSet;
        }
    }

    private void Update()
    {
        if(_timer>0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _shoot = true;
        }
    }
}
