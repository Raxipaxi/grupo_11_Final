
using System.Collections.Generic;
using UnityEngine;

namespace CustomUpdateManagerNSP
{
    public abstract class CustomUpdateManager : MonoBehaviour
    {
        private float currentTime;
        public float framerate = 60f;
        private List<CustomUpdateBehavior> customUpdateMonoList = new List<CustomUpdateBehavior>();
        public List<CustomUpdateBehavior> CurrentMonoList => customUpdateMonoList;
        [SerializeField]protected bool printFramerateActualization;
        [SerializeField]private bool checkForUpdates = true;
        void Update()
        {
            if (!checkForUpdates && customUpdateMonoList.Count < 0 && !CheckForPause())
            {
                return;
            }



            ;
            //currentframesDisplayed++;
            var count = customUpdateMonoList.Count;

            for (int i = count - 1; i >= 0; i--)
            {
                if (customUpdateMonoList[i].NeedsUpdate)
                    if (CheckForPause())
                    {
                        if (printFramerateActualization)
                        {
                            print("Update");
                        }
                        customUpdateMonoList[i].UpdateMe();
                    }
            }

        }
        bool CheckForPause()
        {
            currentTime += Time.deltaTime * framerate;
            if (currentTime >= 1)
            {
                currentTime = 0;
                return true;
            }

            return false;
        }
        public void AddScript(CustomUpdateBehavior reference)
        {
            this.customUpdateMonoList.Add(reference);
        }

        public void RemoveScript(CustomUpdateBehavior reference)
        {
            if (!this.customUpdateMonoList.Contains(reference))
                return;

            this.customUpdateMonoList.Remove(reference);
        }

        private void ChangeUpdateMode(bool state)
        {
            checkForUpdates = state;
        }
        
    }

}