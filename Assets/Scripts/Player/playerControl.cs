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

    private float speed = 3f;
    private float runningSpeed = 5f;

    private float rSpeed = 10f;

    public GameObject objetoCerca;

    public int vida = 50;
    private int vidaMaxima = 50;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _controller = GetComponent<CharacterController>();
        _state = playerState.walking;
    }

    void Update()
    {
        MovimientoJugador();
        interactuar();
    }

    private void interactuar()
    {
        if (objetoCerca != null && _playerInput.actions["Interactuar"].WasPressedThisFrame())
        {
            objetoCerca.GetComponent<Objeto>().usar();
        }
    }

    private void MovimientoJugador()
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

        if (posicion.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(posicion);

            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                    targetRotation,
                                                    rSpeed * Time.deltaTime);
        }

        Vector3 finalMove = transform.forward * posicion.magnitude;

        if (_state == playerState.walking)
        {
            _controller.Move(finalMove * speed * Time.deltaTime);
        }
        else
        {
            _controller.Move(finalMove * runningSpeed * Time.deltaTime);
        }
    }

    public void recibirDaño(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            vida = 0;
            morir();
        }
    }

    private void morir()
    {
        Time.timeScale = 0;
        //poner pantalla de perder
    }

    public void curar(int salud)
    {
        vida += salud;
        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }
    }
}
