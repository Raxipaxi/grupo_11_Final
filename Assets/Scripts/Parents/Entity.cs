using System;
using CustomUpdateManagerNSP;
using UnityEngine;

namespace Utilities.Parents
{
    public class Entity : GameplayUpdateBehaviour
    {
        protected Transform _tr;
        public float PosX => _tr.position.x ;
        public float PosY => _tr.position.y ;
        public float SizeX => size.x/2;
        public float SizeY => size.y/2;

        protected Vector2 size;

        protected virtual void Awake()
        {
            size = transform.localScale;
            _tr = transform;
        }
    }
}