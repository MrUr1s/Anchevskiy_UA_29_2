using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotComponent : MonoBehaviour
{
    private MoveComponent _moveComponent;
    private FireComponent _fireComponent;
    [SerializeField]
    private float _timeMove, _defaultTimeMove = 3f, _distance = 1f;
    private void Awake()
    {
        ResetTimeMove();
        _moveComponent = GetComponent<MoveComponent>();
        _fireComponent = GetComponent<FireComponent>();
    }


    public void Do()
    {
        _fireComponent.OnFire();
        _moveComponent.OnMove(transform.rotation.eulerAngles.ConvertRotationToDirection());
        if (_timeMove < 0)
        {
            ResetTimeMove();
            transform.eulerAngles = ((DirectionType)Random.Range(0, 4)).ConvertDirectionToRotation();
        }
        var raycastHit = Physics2D.RaycastAll(transform.position, transform.rotation.eulerAngles.ConvertRotationToDirection().ConvertDirectionToPosition(), _distance, LayerMask.GetMask("Enemy","Player","Cell"));
        foreach (var hit in raycastHit)
        {
            if (hit.collider.TryGetComponent(out CellComponent cell)&& !cell.DestroyCell)
            {
                transform.eulerAngles = ((DirectionType)Random.Range(0, 4)).ConvertDirectionToRotation();
                break;
            }
            if (hit.collider.TryGetComponent(out ConditionComponent condition) && condition.gameObject.layer == gameObject.layer && condition != GetComponent<ConditionComponent>())
            {
                transform.eulerAngles = ((DirectionType)Random.Range(0, 4)).ConvertDirectionToRotation();
                break;
            }
        }
        _timeMove -= Time.deltaTime;
    }


    public void ResetTimeMove() => _timeMove = _defaultTimeMove;
}

