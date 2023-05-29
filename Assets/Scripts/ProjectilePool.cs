using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectilePool:APool<Projectile>
{
    public ProjectilePool(Projectile prefab, Transform parent, int count =1) : base(prefab, parent)
    {
        Init(count);
    }


    protected override Projectile GetCreated()
    {
        var projectile= Object.Instantiate(_prefab);

        return projectile;
    }
}