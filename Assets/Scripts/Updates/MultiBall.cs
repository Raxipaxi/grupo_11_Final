using UnityEngine;

namespace Utilities.Updates
{
    public class MultiBall : Upgrade
    {
        private bool hasApply;

        protected override void ApplyUpgrade()
        {
            if(!hasApply)
            {
                BallScript ball = Instantiate(GameManager.Instance.globalConfig.ballPrefab);
                ball.Initialize();
                base.ApplyUpgrade();
            }

            hasApply = true;
            base.ApplyUpgrade();
        }
    }
}