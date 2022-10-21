using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private Player _target;

    private int _heal = 10;

    public void Click()
    {
        _target.ApplyHeal(_heal);
    }
}
