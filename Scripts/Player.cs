using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private Animator _animator;
    private int _currentHealth;

    public event UnityAction<int, int> HealthChange;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChange.Invoke(_currentHealth, _maxHealth);
        _animator.SetTrigger(AnimatorPlayerController.Params.Damage);

        if (_currentHealth <= 0)
            _currentHealth = 0;
    }

    public void ApplyHeal(int heal)
    {
        _currentHealth += heal;
        HealthChange.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;
    }
}
