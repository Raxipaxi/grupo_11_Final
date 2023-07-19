
namespace CustomUpdateManagerNSP
{
    public class PhysicsCustomUpdateManager : CustomUpdateManager
    {
        public static PhysicsCustomUpdateManager Instance;
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
