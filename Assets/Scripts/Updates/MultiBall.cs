using UnityEngine;

namespace Utilities.Updates
{
    public class MultiBall : Upgrade
    {
        [SerializeField] private BallScript ball;
        private bool hasApply;
        protected override void ApplyUpgrade()
        {
            if(!hasApply)
            {
                Instantiate(ball);
                base.ApplyUpgrade();
            }

            hasApply = true;
            gameObject.SetActive(false);
        }
    }
}