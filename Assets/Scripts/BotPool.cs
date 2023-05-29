using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPool : APool<BotComponent>
{
    Transform[] _spawnPoint;
    public BotPool(BotComponent prefab, Transform parent,Transform[] spawnPoint, int count=1) : base(prefab, parent)
    {
        _spawnPoint = spawnPoint;
        Init(count);

    }
    
    protected override BotComponent GetCreated()
    {
        BotComponent enemy = Object.Instantiate(_prefab);

        return enemy;
    }
}
