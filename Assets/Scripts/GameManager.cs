using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GlobalConfig globalConfig;

    public UIManager uiManager;
    public event Action<bool> OnPause;
    public event Action OnWin;
    //private static MenuesInputs _inputs; // TODO jess: implement new input system

    [field: SerializeField] public bool IsPaused { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        //if (_inputs == null)
        //{
        //    _inputs = new MenuesInputs();
        //    _inputs.Enable();
        //    _inputs.Game.Pause.started += ctx => Pause();
        //}

        IsPaused = false;
        uiManager = Instantiate(globalConfig.uiManagerPrefab);
        uiManager.Initialize();
    }

    public void Pause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
        OnPause?.Invoke(IsPaused);
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        OnWin?.Invoke();
    }
}
