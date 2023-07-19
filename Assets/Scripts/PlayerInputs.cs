using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
 {
    private GameInputs _inputs;
    private int _xAxis;
    private float currX;
    public Action OnShoot;
    public int Dir => (int)currX;

    public void Initialize()
    {
        _inputs = new GameInputs();
        _inputs.Enable();
        print("Init " + currX);
        //_inputs.Gameplay.Move.started += Move;
        //_inputs.Gameplay.Move.canceled += MoveCanceled;

        _inputs.Gameplay.Shoot.performed += CanShoot;
    }

    private void OnDestroy()
    {
        //_inputs.Gameplay.Move.started -= Move;
        //_inputs.Gameplay.Move.canceled -= MoveCanceled;
        
        _inputs.Gameplay.Shoot.performed -= CanShoot;
       
    }

    private void Move(InputAction.CallbackContext context)
    {

    }

    private void MoveCanceled(InputAction.CallbackContext context)
    {
        currX = 0f;
        _xAxis = 0;
    }

    public void CanShoot(InputAction.CallbackContext context)
    {
        OnShoot?.Invoke();
    }

    public void UpdateInput()
    {
        currX = _inputs.Gameplay.Move.ReadValue<float>();
        print(currX);

        //if(currX == 0f)
        //{
        //    _xAxis = 0;
        //    return;
        //}
        //_xAxis = currX > 0f ? 1 : -1;
    }
    
 }
