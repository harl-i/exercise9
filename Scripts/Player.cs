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

    public event UnityAction<int, int> HealthChanged;

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
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
        _animator.SetTrigger(AnimatorPlayerController.Params.Damage);
    }

    public void ApplyHeal(int heal)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + heal, 0, _maxHealth);

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
