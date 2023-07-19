using UnityEngine;

namespace Utilities.Updates
{
    public class MultiBall : Upgrade
    {
        protected override void ApplyUpgrade()
        {
                BallScript ball = Instantiate(GameManager.Instance.globalConfig.ballPrefab);
                ball.Initialize();
                base.ApplyUpgrade();
        }
    }
}