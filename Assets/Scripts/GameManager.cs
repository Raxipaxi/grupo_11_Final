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
    private static GameInputs _inputs;
    private bool won = false;

    public event Action<bool> OnPause;
    public event Action OnWin;

    public bool IsPaused => isPaused;
    public GameInputs Inputs => _inputs;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        _inputs = new GameInputs();
        _inputs.Enable();
        _inputs.UI.PauseToggle.started += ctx => Pause();

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
        if (won) return;
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        OnPause?.Invoke(isPaused);
    }

    public void WinGame()
    {
        won = true;
        Time.timeScale = 0f;
        OnWin?.Invoke();
    }
}
