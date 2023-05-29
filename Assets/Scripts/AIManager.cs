using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [SerializeField]
    private GameManager _gm;

    void Awake()
    {
        _gm = GetComponent<GameManager>();
    }

    void Start()
    {
        StartCoroutine(AIActive());
    }

    private IEnumerator AIActive()
    {
        while(true)
        {
            foreach (var bot in _gm.BotPool.Pool.Where(t=>t.gameObject.activeSelf))
            {
                bot.Do();
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
