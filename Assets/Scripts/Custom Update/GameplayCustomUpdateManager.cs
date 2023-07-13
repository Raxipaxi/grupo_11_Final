
namespace CustomUpdateManagerNSP
{
    public class GameplayCustomUpdateManager : CustomUpdateManager
    {
        public static GameplayCustomUpdateManager Instance;
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
