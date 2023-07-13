namespace CustomUpdateManagerNSP
{
    public class PhysicsUpdateBehaviour : CustomUpdateBehavior
    {
        protected override void SuscribeToManager()
        {
            UIUpdateManager.Instance.AddScript(this);
        }
    }
}