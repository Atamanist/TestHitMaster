using System.Collections.Generic;
using UnityEngine;

public class PointShoot : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    private ShootOrMove _shoot;
    private int _enemyCount;

    private void Start()
    {
        _enemyCount = _enemies.Count;
    }

    public void EnemyDie()
    {
        _enemyCount--;
    }

    private void Update()
    {
        if(_enemyCount==0&&_shoot!=null)
        {
            _shoot.CanShoot();
            _shoot.CanMove();
            _shoot = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.TryGetComponent<ShootOrMove>(out ShootOrMove shoot))
        {
            _shoot = shoot;
            _shoot.CanShoot();
            _shoot.Idle();
        }
    }

}
