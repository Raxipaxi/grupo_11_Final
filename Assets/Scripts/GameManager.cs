using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GlobalConfig globalConfig;
    [ReadOnly] public UIManager uiManager;

    [SerializeField] [ReadOnly] private bool isPaused = false;
    [SerializeField] [ReadOnly] private int currentPoints = 0;
    private static GameInputs _inputs;
    private bool won = false;

    public event Action<bool> OnPause;
    public event Action OnWin;
    public event Action<int> OnPointsUpdated;

    public bool IsPaused => isPaused;

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
        _inputs.Gameplay.Enable();
        _inputs.Gameplay.Pause.started += PauseInput;
        _inputs.Cheats.SkipToWin.performed += ctx => WinGame();
        _inputs.Cheats.AddPoints.performed += ctx => AddPoints(100);

        Time.timeScale = 1f;

        uiManager = Instantiate(globalConfig.uiManagerPrefab);
        uiManager.Initialize();
    }

    void Start()
    {
        AudioManager.instance.PlayMusic(AudioManager.instance.soundReferences.levelMusic);
    }

    private void OnDestroy()
    {
        _inputs.Gameplay.Pause.performed -= PauseInput;
        _inputs.Cheats.SkipToWin.performed -= ctx => WinGame();
        _inputs.Cheats.AddPoints.performed -= ctx => AddPoints(100);
        uiManager.Dispose();
    }

    private void PauseInput(InputAction.CallbackContext cxt)
    {
        if (won) return;
        Pause(!isPaused);
    }

    public void Pause(bool value)
    {
        if(value)
            _inputs.Gameplay.Disable();
        else
            _inputs.Gameplay.Enable();

        isPaused = value;
        Time.timeScale = isPaused ? 0f : 1f;
        OnPause?.Invoke(isPaused);
    }

    public void WinGame()
    {
        _inputs.Gameplay.Disable();
        _inputs.UI.Enable();

        won = true;
        Time.timeScale = 0f;
        OnWin?.Invoke();
    }

    public void AddPoints(int addPoints)
    {
        currentPoints += addPoints;
        OnPointsUpdated?.Invoke(currentPoints);
    }
}
