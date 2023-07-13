using System;
using UnityEngine;

namespace Utilities
{
    public class Slider : MonoBehaviour
    {

        [SerializeField] private float speed;
        private float _currSpeed;
        [SerializeField] private Vector2 size;
        [SerializeField] public Vector2 Size => size;
        private Vector2 _wallLocation;
        private BallScript _currBall;
        private MeshRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            size = _renderer.bounds.size / 2;
        }

        private void Start()
        {
            _currSpeed = speed;
        }

        private void Update()
        {
            Inputs();
        }

        public void GetRange()
        {
            
        }

        public void AssignProperties(Vector2 wallLocation)
        {
            _wallLocation = wallLocation;
        }

        public void Attach(BallScript currBall)
        {
            _currBall = currBall;
            currBall.transform.parent = transform;
        }
        void Inputs()
        {
            if (Input.GetKey(KeyCode.A) && transform.position.x - size.x >= 0)
            {
                Move(-1);
            }
            
            if (Input.GetKey(KeyCode.D) && transform.position.x + size.x < _wallLocation.x)
            {
                Move(1);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // _currBall.ChangeSpeed(new Vector3(_currSpeed,_currBall.Speed.y,0));
                // _currBall.transform.parent = null;
                // _currBall.DeAttach();
            }
        }

        void Move(float dirMultiplier)
        {
            transform.position += transform.right * _currSpeed * dirMultiplier * Time.deltaTime;
        }
        
    }
}