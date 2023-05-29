using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConditionComponent : ConditionComponent
{
    [SerializeField]
    private bool _immortal;
    [SerializeField]
    private float _immortalTime = 3f, _immortalSwitchVisual=0.25f;
    private Renderer _render;

    private void Awake()
    {
        _render = GetComponent<Renderer>();
    }
    public override void SetDamage(int damage)
    {
        if (_immortal) return;
        _healt -= damage;
        transform.position = GameManager.instance.CharacterSpawnPoint.position;
        StartCoroutine(OnImmortal());
        if (_healt < 0)
        {
            gameObject.SetActive(false);
            GameManager.instance.GameOver();
        }

    }
    private IEnumerator OnImmortal()
    {
        _immortal = true;
        var time = _immortalTime;
        while(time > 0)
        {
            _render.enabled=!_render.enabled;
            time -= _immortalSwitchVisual;
            yield return new WaitForSeconds(_immortalSwitchVisual);
        }
        _render.enabled = true;
        _immortal = false;

    }
}
