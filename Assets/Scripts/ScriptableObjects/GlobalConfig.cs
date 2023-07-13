using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalConfig", menuName = "TP/GlobalConfig", order = 1)]
public class GlobalConfig : ScriptableObject
{
    [Header("Scenes")]
    public string mainMenuScene = "MainMenu";
    public string gameScene = "Game";

    [Header("Prefabs")]
    public UIManager uiManagerPrefab;

    [Serializable]
    public class PopupInfo
    {
        public string title;
        [TextArea] public string description;
    }

    [Header("Texts")]
    public PopupInfo restartPopup;
    public PopupInfo mainMenuPopup;
    public PopupInfo exitPopup;

}
