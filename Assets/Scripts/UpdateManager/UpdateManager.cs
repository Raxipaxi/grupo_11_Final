using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    [ReadOnly] public CustomUpdate fixCustomUpdater;
    [ReadOnly] public CustomUpdate gameplayCustomUpdate;
    [ReadOnly] public CustomUpdate uiCustomUpdate;

    private float currentTimeGameplay; //we have the timer here as it should not be affected by the max fps on gameplay or UI
    public float CurrentTimeGameplay => currentTimeGameplay;

    public void Initialize()
    {
        //there are two gameplayList because the second one can constantly change as the bullets and enemies come and go.
        //Meanwhile the fixed one are the ones that don't have a set frame, they update all the frames as we want don't want to limit the frame check as they depend on the craprichious input system.

        fixCustomUpdater = gameObject.AddComponent<CustomUpdate>();
        fixCustomUpdater.Initialize(0, "Managers");

        gameplayCustomUpdate = gameObject.AddComponent<CustomUpdate>();
        gameplayCustomUpdate.Initialize(GameManager.Instance.globalConfig.gameplayFPSTarget, "Gameplay");

        uiCustomUpdate = gameObject.AddComponent<CustomUpdate>();
        uiCustomUpdate.Initialize(GameManager.Instance.globalConfig.uiFPSTarget, "UI");
    }

    void Update()
    {
        if (!GameManager.Instance.IsPaused || !GameManager.Instance.Won)
        {
            currentTimeGameplay += Time.deltaTime;
        }

        //fixCustomUpdater.UpdateList();
        gameplayCustomUpdate.UpdateList();
        uiCustomUpdate.UpdateList();
    }
}
