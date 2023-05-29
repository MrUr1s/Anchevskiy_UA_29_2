using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveComponent))]
public class Projectile : MonoBehaviour
{
    private MoveComponent _moveComponet;
    [SerializeField]
    private SideType _side;
    [SerializeField]
    private DirectionType _direction;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _lifeTime = 3f;
    private int _Layer;

    public float LifeTime  => _lifeTime; 

    private void Awake()
    {
        _moveComponet = GetComponent<MoveComponent>();
    }

    public void SetLayer(int layer)
    {
        _Layer = layer;
    }
    private void OnEnable()
    {
        StartCoroutine(Move());
    }
    private void OnDisable()
    {
        StopCoroutine(Move());
    }
    public void SetParams(Vector3 position, DirectionType direction, SideType side)
    {
        (transform.position, _side, _direction) = (position, side, direction);
    }
    IEnumerator Move()
    {
        var time = LifeTime;
        while (time>=0)
        {
            time-=Time.deltaTime;
            _moveComponet.OnMove(transform.eulerAngles.ConvertRotationToDirection());
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ConditionComponent condition) && condition.gameObject.layer != _Layer)     
        {            
            condition.SetDamage(_damage);
            if(condition.gameObject.layer==LayerMask.NameToLayer("Enemy"))
            {
                if(transform.eulerAngles!=Vector3.zero)
                    condition.transform.eulerAngles = -transform.eulerAngles;
                else
                    condition.transform.eulerAngles = DirectionType.Down.ConvertDirectionToRotation();

            }
            gameObject.SetActive(false);
            return;
        }
        if(other.TryGetComponent(out BaseComponent baseComponent))
        {
            baseComponent.Destroy();
            return;
        }
        if (other.TryGetComponent(out CellComponent cell))
        {
            if (cell.DestroyCell) Destroy(cell.gameObject);
            if (cell.DestroyProjectile) gameObject.SetActive(false);            
            return;
        }
    }
}
