using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireComponent : MonoBehaviour
{
    [SerializeField]
    private bool _canFire = true;
    [SerializeField]
    private float _delayFire = 0.25f;
    [SerializeField]
    private ProjectilePool _projectilePool;
    [SerializeField]
    private SideType _side;

    public SideType Side => _side;

    private void OnEnable()
    {
        _canFire = true;
    }

    public void OnFire()
    {
        if (!_canFire) return;
        var projectile= GameManager.instance.ProjectilePool.Spawn(transform.position, transform.eulerAngles);
        projectile.SetLayer(gameObject.layer);
        StartCoroutine(OnDelay());
    }

    private IEnumerator OnDelay()
    {
        _canFire = false;
            yield return new WaitForSeconds(_delayFire);
        _canFire = true;


    }
}

