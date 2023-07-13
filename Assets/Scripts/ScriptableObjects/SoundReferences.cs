using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundReferences", menuName = "TP/SoundReferences", order = 5)]
public class SoundReferences : ScriptableObject
{
    [Header("UI")]
    public AudioClip hoverButton;
    public AudioClip selectButton;
    public AudioClip pauseSound;
    public AudioClip mainMenu;

    [Header("Level")]
    public AudioClip playerDeath;
    public AudioClip brickDestroyed;

    [Header("Extras")]
    public AudioClip win;
    public AudioClip levelMusic;
}
