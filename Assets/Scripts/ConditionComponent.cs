using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionComponent : MonoBehaviour
{
    [SerializeField]
    protected int _healt = 3, _healtdefault = 3;

    private void OnEnable()
    {
        _healt = _healtdefault;
    }

    public virtual void SetDamage(int damage)
    {
        _healt-=damage;
        if(_healt < 0)
            gameObject.SetActive(false);
    }
}
