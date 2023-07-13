using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalConfig", menuName = "GlobalConfig", order = 1)]
public class GlobalConfig : ScriptableObject
{
    [Header("Scenes")]
    public string mainMenuScene = "MainMenu";
    public string gameScene = "Game";

    [Header("Prefabs")]
    public UIManager uiManagerPrefab;
}
