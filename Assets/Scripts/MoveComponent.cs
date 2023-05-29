using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField]
    private float _speed=1f;

    public void OnMove(DirectionType direction)
    {
        transform.position += direction.ConvertDirectionToPosition()*Time.deltaTime*_speed;
        transform.eulerAngles = direction.ConvertDirectionToRotation();
    }

    
}
