using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _healthMax;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Animator _anim;
    private float _health;
    private bool _live = true;
    [SerializeField]private UnityEvent _liveEvent;

    void Start()
    {
        _health = _healthMax;
        _healthBar.value = CalculateHealth();
    }

    void Update()
    {
        _healthBar.value = CalculateHealth();

        if (_health<=0&&_live==true)
        {
            _live = false;
            _healthBar.gameObject.SetActive(false);
            _anim.SetTrigger("Die");
            _liveEvent.Invoke();
        }
    }

    private void Damage(float dmg)
    {
        _health -= dmg;
        _anim.SetTrigger("Take Damage");
    }

    private float CalculateHealth()
    {
        return _health / _healthMax;
    }
}
