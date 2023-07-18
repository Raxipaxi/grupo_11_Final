using CustomUpdateManagerNSP;
using UnityEngine;
using Utilities.Parents;

namespace Utilities.Updates
{
    public class Upgrade : Entity
    {
        private Slider _slider;
        [SerializeField] private float speed;
        protected override void Start()
        {
            base.Start();
            _slider = PhysicsManager.Instance.Slider;

        }

        protected override void UpdateItems()
        {
            base.UpdateItems();
            DetectSliderPosition();
            Move();
        }

        private void DetectSliderPosition()
        {
            if (Bot > _slider.Top)
            {
                return;
            }

            if (Left >= _slider.Left && Right <= _slider.Right)
            {
                ApplyUpgrade();
            }
            // if (Top <= _slider.Top || Bot >= _slider.Bot)
            // {
            //     if (Left <= _slider.Right && Right <= _slider.Left)
            //     {
            //         //ApplyUpgrade();
            //     }
            // }
        }

        private void Move()
        {
            _tr.position += Vector3.down * speed * Time.deltaTime;
        }

        protected virtual void ApplyUpgrade()
        {
            Destroy(gameObject);
            //Se aplica el ugrade deseado overraideado.
            
        }
    }
}