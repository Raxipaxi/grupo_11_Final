using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

[CreateAssetMenu(fileName = "GlobalConfig", menuName = "TP/GlobalConfig", order = 1)]
public class GlobalConfig : ScriptableObject
{
    [Header("Global")]
    public float ballSpeed = 10f;
    public int playerMaxLife = 3;

    [Header("CustomUpdate Settings")]
    [Tooltip("This FrameRate is for the gameplay things that keep adding and leaving.")]
    public int gameplayFPSTarget = 60; //nothign that depends on the input system should be here

    [Tooltip("This FrameRate is for the UI")]
    public int uiFPSTarget = 30;

    [Header("Scenes")]
    public string mainMenuScene = "MainMenu";
    public string gameScene = "Game";

    [Header("Prefabs")]
    public BallScript ballPrefab;
    public UpdateManager updateManagerPrefab;
    public UIManager uiManagerPrefab;
    public MapCreation mapCreationPrefab;

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

    [Header("HUD")]
    public string pointsFormat = "00000";
    public string timeFormat = "mm':'ss";

}
