using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private ProjectilePool _projectilePool;
    private BotPool _botPool;

    [SerializeField]
    private Transform _projectilePoolTransform;
    [SerializeField]
    private Transform _botPoolTransform;
    [SerializeField]
    private PlayerConditionComponent _prefabPlayer;
    [SerializeField] 
    private Transform _characterSpawnPoint;
    [SerializeField]
    private Transform[] _botSpawnPoint;
    [SerializeField]
    private  int _botCountLevel=10,_botCountIsLife=5;
    [SerializeField]
    private float _delaySpawnBot = 1f;
    public ProjectilePool ProjectilePool => _projectilePool;

    public BotPool BotPool => _botPool;

    public Transform CharacterSpawnPoint  => _characterSpawnPoint; 

    private void Awake()
    {
        instance = this;
        SpawnPlayer();
        InstantiatePoolEnemyes();
        InstantiatePoolProjectile();
    }


    private void InstantiatePoolProjectile()
    {
        _projectilePool=new(Resources.Load<Projectile>("Projectile"), _projectilePoolTransform.transform, 10);
    }

    private void InstantiatePoolEnemyes()
    {
        _botPool = new(Resources.Load<BotComponent>("Bot"), _botPoolTransform.transform, _botSpawnPoint, _botCountLevel);
        StartCoroutine(SpawnBot());
    }

    private IEnumerator SpawnBot()
    {
        int botcount = 0;
        while (true)
        {
            if (_botCountIsLife > _botPool.Pool.Count(t => t.gameObject.activeSelf))
            {
                if (botcount < _botCountLevel)
                {
                    _botPool.Spawn(_botSpawnPoint[UnityEngine.Random.Range(0, _botSpawnPoint.Length)].position);
                    botcount++;
                }
            }
            yield return new WaitForSeconds(_delaySpawnBot);
        }
    }

    private void SpawnPlayer()
    {
        _prefabPlayer = Instantiate(_prefabPlayer, _characterSpawnPoint.position, _characterSpawnPoint.rotation);
    }
    public void GameOver()
    {
        EditorApplication.isPaused = true;
    }
}
