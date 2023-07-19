using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Utilities;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GlobalConfig globalConfig;
    [ReadOnly] public UIManager uiManager;
    [ReadOnly] public MapCreation mapCreation;
    [ReadOnly] public PhysicsManager physicsManager;
    [ReadOnly] public UpdateManager updateManager;

    [SerializeField, ReadOnly] private bool isPaused = false;
    [SerializeField, ReadOnly] private int currentPoints = 0;
    [ReadOnly, SerializeField] private int lifes;

    private static GameInputs _inputs;
    private bool won = false;
    private int currentBallsInGame;
    private int currentBricksInGame;
    private MapCreation _mapCreation;

    public Action<bool> OnPause;
    public Action<int> OnTakeDamage;
    public Action OnWin;
    public Action OnGameOver;
    public Action<int> OnPointsUpdated;

    public bool Won => won;
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
        _inputs.Cheats.SkipToWin.performed += ctx => Win();
        _inputs.Cheats.AddPoints.performed += ctx => AddPoints(100);

        Time.timeScale = 1f;

        updateManager = Instantiate(globalConfig.updateManagerPrefab);
        updateManager.Initialize();

        uiManager = Instantiate(globalConfig.uiManagerPrefab);
        uiManager.Initialize();
        uiManager.UpdateLives(globalConfig.playerMaxLife);

        physicsManager = gameObject.AddComponent<PhysicsManager>();

        mapCreation = Instantiate(globalConfig.mapCreationPrefab);
        mapCreation.Initialize(physicsManager);
    }

    void Start()
    {
        AudioManager.instance.PlayMusic(AudioManager.instance.soundReferences.levelMusic);
    }

    private void OnDestroy()
    {
        _inputs.Gameplay.Pause.performed -= PauseInput;
        _inputs.Cheats.SkipToWin.performed -= ctx => Win();
        _inputs.Cheats.AddPoints.performed -= ctx => AddPoints(100);
        uiManager.Dispose();
    }

    private void PauseInput(InputAction.CallbackContext cxt)
    {
        if (won) return;
        Pause(!isPaused);
    }

    public void AssignMap(MapCreation creation)
    {
        _mapCreation = creation;
    }

    public void ModifyCurrentBalls(int quantityToModify)
    {
        currentBallsInGame += quantityToModify;
        if (currentBallsInGame <= 0)
        {
            lifes++;
            OnTakeDamage?.Invoke(lifes);

            if (lifes > globalConfig.playerMaxLife)
            {
                Defeat();
                return;
            }

            _mapCreation.Restart();
        }
    }
    public void ModifyCurrentBricks(int quantityToModify)
    {
        currentBricksInGame += quantityToModify;
        if (currentBricksInGame <= 0)
        {
            Win();
        }
    }

    private void Defeat()
    {
        _inputs.Gameplay.Disable();
        _inputs.UI.Enable();

        won = true;
        Time.timeScale = 0f;
        OnGameOver?.Invoke();
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

    public void Win()
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
