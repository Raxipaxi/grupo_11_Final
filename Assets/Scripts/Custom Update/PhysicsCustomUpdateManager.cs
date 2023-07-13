
namespace CustomUpdateManagerNSP
{
    public class PhisicsCustomUpdateManager : CustomUpdateManager
    {
        public static PhisicsCustomUpdateManager Instance;
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
