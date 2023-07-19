using UnityEngine;
using Utilities.Parents;

namespace Utilities.Updates
{
    public class Upgrade : Entity, IUpdate
    {
        private Slider _slider;
        [SerializeField] private float speed;

        public override void Initialize()
        {
            base.Initialize();
            _slider = GameManager.Instance.physicsManager.Slider;
            GameManager.Instance.updateManager.gameplayCustomUpdate.Add(this);
        }

        public void DoUpdate()
        {
            DetectSliderPosition();
            Move();
        }

        private void DetectSliderPosition()
        {
            if (Bot > _slider.Top)
            {
                return;
            }

            if (Left <= _slider.Right && Right >= _slider.Left)
            {
                ApplyUpgrade();
            }

        }

        private void Move()
        {
            _tr.position += Vector3.down * speed * Time.deltaTime;
        }

        protected virtual void ApplyUpgrade()
        {
            GameManager.Instance.updateManager.gameplayCustomUpdate.Remove(this);
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
}