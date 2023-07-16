using UnityEngine;
using Utilities.Parents;

namespace Utilities
{
    //BORRAR COMENTARIOS
    public class Slider : Entity
    {
        private PlayerInputs _inputs;
        
        [SerializeField] private float speed;
        private float _currSpeed;
        [SerializeField] private GameObject center;
        [SerializeField] private GameObject left;
        [SerializeField] private GameObject right;
        public float Center => center.transform.localScale.x/2;
        private Vector2 _wallLocation;


        private void Awake()
        {
            _inputs = GetComponent<PlayerInputs>();
            _tr = transform;
            size.x = center.transform.localScale.x + right.transform.localScale.x + left.transform.localScale.x;

            print("Lo tamaño e " + size.x);
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
        void Inputs()
        {
            _inputs.UpdateDir();

            Move(_inputs.Dir);
        }

        void Move(int dir)
        {
            
            if ((PosX + SizeX >= _wallLocation.x && dir > 0) || (PosX - SizeX <= 0 && dir < 0))
            {
                return;
            }
            transform.position += transform.right * _currSpeed * dir * Time.deltaTime;
        }
        
    }
}