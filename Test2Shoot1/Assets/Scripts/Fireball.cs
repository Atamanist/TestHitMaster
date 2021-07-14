using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _power;
    [SerializeField] private float _time;
    [SerializeField] private float _speed;
    private Vector3 _target;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("Damage", _power);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        _time -= Time.deltaTime;
        if(_time<0)
        {
            Destroy(this.gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed*Time.deltaTime);
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }
}
