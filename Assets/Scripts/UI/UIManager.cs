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
    public Popup winPopup;

    public override void Initialize()
    {
        pauseMenu.Initialize();
        pauseMenu.Close();

        winPopup.btnConfirm.button.onClick.AddListener(ConfirmWin);
        winPopup.btnCancel.gameObject.SetActive(false);
        winPopup.Close();

        GameManager.Instance.OnWin += OnWin;
    }

    public override void Dispose()
    {
        GameManager.Instance.OnWin -= OnWin;
        pauseMenu.Dispose();
    }

    public void OnWin()
    {
        winPopup.Open();
    }

    private void ConfirmWin()
    {
        SceneManager.LoadScene(GameManager.Instance.globalConfig.gameScene);
    }
}
