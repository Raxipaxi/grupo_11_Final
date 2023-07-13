using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Panel
{
    public TMP_Text txtCurrentPoints;
    public PauseMenu pauseMenu;
    public Panel hud;
    public Popup winPopup;

    public override void Initialize()
    {
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
        txtCurrentPoints.text = currentPoints.ToString(); //TODO jess: set string format!!!
    }

    private void ConfirmWin()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameManager.Instance.globalConfig.gameScene);
    }
}
