using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private Animator _animator;
    private int _currentHealth;

    public event UnityAction<int, int> HealthChange;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChange.Invoke(_currentHealth, _health);
        _animator.SetTrigger(AnimatorPlayerController.Params.Damage);

        if (_currentHealth <= 0)
            _currentHealth = 0;
    }

    public void ApplyHeal(int heal)
    {
        _currentHealth += heal;
        HealthChange.Invoke(_currentHealth, _health);

        if (_currentHealth >= _health)
            _currentHealth = _health;
    }
}
