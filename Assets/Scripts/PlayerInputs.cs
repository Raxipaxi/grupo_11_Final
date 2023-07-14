using System;
using UnityEngine;
 public class PlayerInputs : MonoBehaviour
 {
     private GameInputs _inputs;
     private int _xAxis;
     private float currX;
     public int Dir => _xAxis;

     private void Awake()
     {
         _inputs = new GameInputs();
         
         _inputs.Gameplay.Move.started += context => currX = context.ReadValue<float>();
         _inputs.Gameplay.Move.canceled += context => currX = 0;
     }
     public void UpdateDir()
     {
         if (currX == 0f) {_xAxis = 0;return;}
         _xAxis = currX > 0f ? 1 : -1;
     }
     private void OnEnable()
     {
         _inputs.Enable();
     }
     
 }
