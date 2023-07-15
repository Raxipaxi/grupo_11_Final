using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class UIManager : Panel
{
    [Header("References")]
    public PauseMenu pauseMenu;
    public Panel hud;
    public Popup winPopup;
    
    [Header("HUD info")]
    public TMP_Text txtCurrentPoints;
    public TMP_Text txtCurrentLostTimes;
    public TMP_Text txtTime;

    public override void Initialize()
    {
        base.Initialize();
        pauseMenu.Initialize();
        pauseMenu.Close();

        winPopup.Close();
        winPopup.Initialize();
        winPopup.btnConfirm.button.onClick.AddListener(ConfirmWin);
        winPopup.btnCancel.gameObject.SetActive(false);

        GameManager.Instance.OnWin += OnWin;
        GameManager.Instance.OnPause += OnPause;
        GameManager.Instance.OnPointsUpdated += OnPointsUpdate;
    }

    public override void Dispose()
    {
        GameManager.Instance.OnWin -= OnWin;
        GameManager.Instance.OnPause -= OnPause;
        GameManager.Instance.OnPointsUpdated -= OnPointsUpdate;

        pauseMenu.Dispose();
    }

    public void OnWin()
    {
        winPopup.Open();
    }

    public void OnPause(bool paused)
    {
        if (paused)
        {
            hud.Close();
            pauseMenu.Open();
        }
        else
        {
            hud.Open();
            pauseMenu.Close();
        }
    }

    public void OnPointsUpdate(int currentPoints)
    {
        txtCurrentPoints.text = currentPoints.ToString(GameManager.Instance.globalConfig.pointsFormat);
    }

    public void UpdateTime(float currentTime)
    {
        txtTime.text = TimeSpan.FromSeconds(currentTime).ToString(GameManager.Instance.globalConfig.timeFormat);
    }

    public void UpdateLostTimes(int currentLostTimes)
    {
        txtCurrentLostTimes.text = currentLostTimes.ToString();
    }

    private void ConfirmWin()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameManager.Instance.globalConfig.mainMenuScene);
    }
}
