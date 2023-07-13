using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : Panel
{
    [Header("Buttons")]
    [SerializeField] private MenuButton resumeButton;
    [SerializeField] private MenuButton restartButton;
    [SerializeField] private MenuButton menuButton;
    [SerializeField] private MenuButton quitButton;

    [Header("Popup")]
    [SerializeField] private Popup warningPopup;

    public override void Initialize()
    {
        resumeButton.button.onClick.AddListener(OnClickResumeHandler);
        restartButton.button.onClick.AddListener(OnClickRestartHandler);
        menuButton.button.onClick.AddListener(OnClickMenuHandler);
        quitButton.button.onClick.AddListener(OnClickQuitHandler);

        warningPopup.Close();
    }

    public override void Open()
    {
        base.Open();
        resumeButton.button.Select();
    }

    public override void Close()
    {
        base.Close();

        if(warningPopup.IsOpen)
            warningPopup.Close();
    }

    public override void Dispose()
    {
        resumeButton.button.onClick.RemoveAllListeners();
        menuButton.button.onClick.RemoveAllListeners();
        quitButton.button.onClick.RemoveAllListeners();
    }

    private void OnClickResumeHandler()
    {
        GameManager.Instance.Pause();
    }

    private void OnClickRestartHandler()
    {
        SceneManager.LoadScene(GameManager.Instance.globalConfig.gameScene);
    }

    private void OnClickMenuHandler()
    {
        SceneManager.LoadScene(GameManager.Instance.globalConfig.mainMenuScene);
    }

    private void OnClickQuitHandler()
    {
        Application.Quit();
    }
}