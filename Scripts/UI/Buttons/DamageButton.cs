using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private Player _target;

    private int _damage = 10;

    public void Click()
    {
        _target.ApplyDamage(_damage);
    }
}
