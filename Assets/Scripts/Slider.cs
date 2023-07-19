using UnityEngine;
using Utilities.Parents;

namespace Utilities
{
    //BORRAR COMENTARIOS
    public class Slider : Entity, IUpdate
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

        public override void Initialize()
        {
            base.Initialize();

            GameManager.Instance.updateManager.fixCustomUpdater.Add(this);
            _inputs = GetComponent<PlayerInputs>();
            size.x = center.transform.localScale.x + right.transform.localScale.x + left.transform.localScale.x;
            _currSpeed = speed;
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

        public void DoUpdate()
        {
            Inputs();
        }
    }
}