using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Utilities
{
    public class Slider : MonoBehaviour
    {
        private PlayerInputs _inputs;
        
        [SerializeField] private float speed;
        private float _currSpeed;
        [SerializeField] private Vector2 size;
       public float Size => size.x/2;
        private Vector2 _wallLocation;
        private BallScript _currBall;
        private MeshRenderer _renderer;
        private Transform _tr;
        public float PosX => _tr.position.x ;

        private void Awake()
        {
            _inputs = GetComponent<PlayerInputs>();
            _renderer = GetComponent<MeshRenderer>();
            _tr = transform;

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
            _inputs.UpdateDir();
            
            Move(_inputs.Dir);
            // if (Input.GetKey(KeyCode.A) && transform.position.x - size.x >= 0)
            // {
            //     Move(-1);
            // }
            //
            // if (Input.GetKey(KeyCode.D) && transform.position.x + size.x < _wallLocation.x)
            // {
            //     Move(1);
            // }
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     // _currBall.ChangeSpeed(new Vector3(_currSpeed,_currBall.Speed.y,0));
            //     // _currBall.transform.parent = null;
            //     // _currBall.DeAttach();
            // }
        }

        void Move(int dir)
        {
            
            if ((PosX + Size >= _wallLocation.x && dir > 0) || (PosX - Size <= 0 && dir < 0))
            {
                return;
            }
            transform.position += transform.right * _currSpeed * dir * Time.deltaTime;
        }
        
    }
}