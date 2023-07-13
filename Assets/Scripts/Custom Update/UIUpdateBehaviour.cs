namespace CustomUpdateManagerNSP
{
    public class UIUpdateBehaviour : CustomUpdateBehavior
    {
        protected override void SuscribeToManager()
        {
            UIUpdateManager.Instance.AddScript(this);
        }
    }
}