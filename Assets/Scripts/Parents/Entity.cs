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

        public float Bot => _tr.position.y - SizeY;
        public float Top => _tr.position.y + SizeY;
        public float Right => _tr.position.x + SizeX;
        public float Left => _tr.position.x - SizeX;

        protected Vector2 size;

        protected virtual void Awake()
        {
            size = transform.localScale;
            _tr = transform;
        }
    }
}