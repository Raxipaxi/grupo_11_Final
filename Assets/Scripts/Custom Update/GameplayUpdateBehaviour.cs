namespace CustomUpdateManagerNSP
{
    public class GameplayUpdateBehaviour : CustomUpdateBehavior
    {

        protected override void SuscribeToManager()
        {
            SetManager(GameplayCustomUpdateManager.Instance);
            _manager.AddScript(this);
        }
    }
}