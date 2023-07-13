using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Panel
{
    public TMP_Text currentPoints;
    public PauseMenu pauseMenu;
    public GameObject hud;
    public Popup winPopup;

    public override void Initialize()
    {
        pauseMenu.Initialize();
        pauseMenu.Close();

        winPopup.btnConfirm.button.onClick.AddListener(ConfirmWin);
        winPopup.btnCancel.gameObject.SetActive(false);
        winPopup.Close();

        GameManager.Instance.OnWin += OnWin;
        GameManager.Instance.OnPause += OnPause;
    }

    public override void Dispose()
    {
        GameManager.Instance.OnWin -= OnWin;
        GameManager.Instance.OnPause -= OnPause;
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
            pauseMenu.Open();
            hud.SetActive(false);
        }
        else
        {
            pauseMenu.Close();
            hud.SetActive(true);
        }
    }

    private void ConfirmWin()
    {
        //TODO jess: disable gameplay inputs and pause inputs here, only Enter should work
        SceneManager.LoadScene(GameManager.Instance.globalConfig.gameScene);
    }
}
