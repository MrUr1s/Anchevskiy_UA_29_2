using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellComponent : MonoBehaviour
{
    [SerializeField]
    private bool _destroyProjectile, _destroyCell;

    public bool DestroyProjectile  => _destroyProjectile; 
    public bool DestroyCell  => _destroyCell;
}
