using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComponent : MonoBehaviour
{
    [SerializeField]
    private Sprite _fullBase,_destroyBase;
    [SerializeField]
    private SpriteRenderer _renderer;
    private void Awake()
    {
        _renderer=GetComponent<SpriteRenderer>();
        _renderer.sprite = _fullBase;
    }
    public void Destroy()
    {
        _renderer.sprite = _destroyBase;
        GameManager.instance.GameOver();
    }
}
