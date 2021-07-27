using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private float _maxHp;
    private float _currentHp;

    private void Start()
    {
        _currentHp = _maxHp;
        _hpSlider.value = 1;
    }

    private void TakeDmg(float dmg)
    {
        _currentHp -= dmg;
        _hpSlider.value = (_currentHp / _maxHp);
    }

    private void OnTriggerEnter(Collider other)
    {
        Weapon weapon;

        if(other.TryGetComponent<Weapon>(out weapon))
        {
            TakeDmg(weapon.DealDmg());
        }
    }
}
