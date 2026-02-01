using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public enum playerState
{
    walking,
    running,
}
public class playerControl : MonoBehaviour
{
    private PlayerInput _playerInput;
    private CharacterController _controller;

    public playerState _state;

    private float speed = 2f;
    private float runningSpeed = 3f;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _controller = GetComponent<CharacterController>();
        _state = playerState.walking;
    }

    void Update()
    {
        Vector2 movementInput = _playerInput.actions["Movement"].ReadValue<Vector2>();
        Vector3 posicion = new Vector3(movementInput.x, 0, movementInput.y);

        if (_playerInput.actions["running"].WasPressedThisFrame())
        {
            if (_state == playerState.running)
            {
                _state = playerState.walking;
            }
            else
            {
                _state = playerState.running;
            }
        }

        if (_state == playerState.walking)
        {
            _controller.Move(posicion * speed * Time.deltaTime);
        }
        else
        {
            _controller.Move(posicion * runningSpeed * Time.deltaTime);
        }
        
    }
}
