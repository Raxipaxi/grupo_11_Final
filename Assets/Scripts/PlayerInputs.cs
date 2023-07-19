using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
 {
    private GameInputs _inputs;
    private int _xAxis;
    private float currX;
    public int Dir => _xAxis;

    public void Initialize()
    {
        _inputs = new GameInputs();
        _inputs.Enable();

        _inputs.Gameplay.Move.started += Move;
        _inputs.Gameplay.Move.canceled += MoveCanceled;
    }

    private void OnDestroy()
    {
        _inputs.Gameplay.Move.started -= Move;
        _inputs.Gameplay.Move.canceled -= MoveCanceled;
    }

    private void Move(InputAction.CallbackContext context)
    {
        currX = context.ReadValue<float>();
    }

    private void MoveCanceled(InputAction.CallbackContext context)
    {
        currX = 0f;
        _xAxis = 0;
    }

    public void UpdateDir()
    {
        if (currX == 0f) return;

        _xAxis = currX > 0f ? 1 : -1;
    }
 }
