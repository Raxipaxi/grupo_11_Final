
namespace CustomUpdateManagerNSP
{
    public class UIUpdateManager : CustomUpdateManager
    {
        public static UIUpdateManager Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}