using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MoveComponent),typeof(FireComponent))]
public class InputComponent : MonoBehaviour
{
    private PlayerControler _inputs;
    [SerializeField]
    private InputAction _actionMove;
    private MoveComponent _moveComponent;
    private FireComponent _fireComponent;
    private void Awake()
    {
        _inputs = new PlayerControler();
        _moveComponent=GetComponent<MoveComponent>();
        _fireComponent=GetComponent<FireComponent>();
    }
    private void OnEnable()
    {
        _inputs.Player.Enable();
        _inputs.Player.Fire.performed += Fire_performed;
        _actionMove = _inputs.Player.Move;
    }

    private void OnDisable()
    {
        _inputs.Player.Disable();
        _inputs.Player.Fire.performed -= Fire_performed;
        _actionMove = null;
    }
    private void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _fireComponent.OnFire();
    }

    private void Update()
    {
        Move(_actionMove);
    }

    private void Move(InputAction actionMove)
    {
        if (_actionMove == null) return;
        var pos=actionMove.ReadValue<Vector2>();
        if(pos!=Vector2.zero)
            _moveComponent.OnMove(pos.ConvertPositionToDirection());

    }
}
