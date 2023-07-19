using UnityEngine;
using Utilities.Parents;

namespace Utilities
{
    public class Slider : Entity, IUpdate
    {
        [SerializeField] PlayerInputs _inputs;
        [SerializeField] private GameObject center;
        [SerializeField] private GameObject left;
        [SerializeField] private GameObject right;
        [SerializeField, ReadOnly] private float _currSpeed;
        [SerializeField] private GameObject fakeBall;

        private bool bHasBall;
        private Entity _rWall;
        private Entity _lWall;
        private float centerOfSlider = 0f;

        public float Center => centerOfSlider;

        public override void Initialize()
        {
            base.Initialize();
            BallStock();
            _currSpeed = GameManager.Instance.globalConfig.sliderSpeed;
            size.x = center.transform.localScale.x + right.transform.localScale.x + left.transform.localScale.x;
            centerOfSlider = center.transform.localScale.x / 2;

            _inputs.Initialize();
            _inputs.OnShoot += CanShoot;

            GameManager.Instance.updateManager.fixCustomUpdater.Add(this);
        }

        public void AssignProperties(Entity lwall, Entity rwall)
        {
            _rWall = rwall;
            _lWall = lwall;
        }

        void Move(int dir)
        {
            Vector3 nextPos = _tr.position + _tr.right * _currSpeed * dir * Time.deltaTime ;
            if (!(nextPos.x- SizeX < _lWall.PosX + _lWall.SizeX || nextPos.x + SizeX > _rWall.PosX - _rWall.SizeX))
            {
                _tr.position = nextPos;
            }
        }

        private void CanShoot()
        {
            if (bHasBall)
            {
                bHasBall = false;
                fakeBall.SetActive(false);
                BallScript newBall = GameManager.Instance.mapCreation.GetBall(fakeBall.transform.position);
                newBall.Initialize();

            }
        }

        public void BallStock()
        {
            bHasBall = true;
            fakeBall.SetActive(true);
        }
        public void DoUpdate()
        {
            if (GameManager.Instance.IsPaused) return;
            _inputs.UpdateInput();
            Move(_inputs.Dir);
        }
    }
}