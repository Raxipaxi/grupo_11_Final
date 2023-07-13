using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GlobalConfig globalConfig;
    [ReadOnly] public UIManager uiManager;

    [SerializeField] [ReadOnly] private bool isPaused;
    //private static MenuesInputs _inputs; // TODO jess: implement new input system

    public event Action<bool> OnPause;
    public event Action OnWin;

    public bool IsPaused => isPaused;

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

        isPaused = false;
        uiManager = Instantiate(globalConfig.uiManagerPrefab);
        uiManager.Initialize();
    }

    private void OnDestroy()
    {
        uiManager.Dispose();
    }

    public void Pause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        OnPause?.Invoke(isPaused);
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        OnWin?.Invoke();
    }
}
