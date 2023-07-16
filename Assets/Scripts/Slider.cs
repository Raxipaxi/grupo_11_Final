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
        private Entity _rWall;
        private Entity _lWall;

        protected override void Awake()
        {
            base.Awake();
            _inputs = GetComponent<PlayerInputs>();
            size.x = center.transform.localScale.x + right.transform.localScale.x + left.transform.localScale.x;

        }

        protected override void Start()
        {
            base.Start();
            _currSpeed = speed;
        }

        protected override void UpdateItems()
        {
            base.UpdateItems();
            Inputs();
        }

        public void AssignProperties(Entity lwall, Entity rwall)
        {
            _rWall = rwall;
            _lWall = lwall;
        }
        void Inputs()
        {
            _inputs.UpdateDir();

            Move(_inputs.Dir);
        }
        void Move(int dir)
        {
            Vector3 nextPos = _tr.position + _tr.right * _currSpeed * dir * Time.deltaTime ;
            if (!(nextPos.x- SizeX < _lWall.PosX + _lWall.SizeX || nextPos.x + SizeX > _rWall.PosX - _rWall.SizeX))
            {
                _tr.position = nextPos;
            }
        }
        
    }
}