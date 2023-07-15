using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class PauseMenu : Panel
{
    [Header("Buttons")]
    [SerializeField] private MenuButton resumeButton;
    [SerializeField] private MenuButton restartButton;
    [SerializeField] private MenuButton menuButton;
    [SerializeField] private MenuButton quitButton;

    [Header("Popup")]
    [SerializeField] private Popup warningPopup;

    private List<MenuButton> buttons = new List<MenuButton>();
    private MenuButton currentButton;
    private static GameInputs _inputs;

    public override void Initialize()
    {
        base.Initialize();

        _inputs = new GameInputs();
        _inputs.Enable();
        _inputs.UI.GoBack.started += PauseInput;

        buttons.Add(resumeButton);
        resumeButton.button.onClick.AddListener(OnClickResumeHandler);

        buttons.Add(restartButton);
        restartButton.button.onClick.AddListener(OpenRestartPopup);

        buttons.Add(menuButton);
        menuButton.button.onClick.AddListener(OpenMainMenuPopup);

        buttons.Add(quitButton);
        quitButton.button.onClick.AddListener(OpenExitPopup);

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].button.onClick.AddListener(() =>AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.selectButton));
            buttons[i].Deselect();
        }

        currentButton = resumeButton;

        warningPopup.Close();
        warningPopup.Initialize();
        warningPopup.OnClose += SetSelectedButton;
    }

    public override void Dispose()
    {
        _inputs.UI.GoBack.started -= PauseInput;

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].button.onClick.RemoveAllListeners();
        }

        if(warningPopup != null)
        {
            warningPopup.OnClose -= SetSelectedButton;

            if (warningPopup.IsOpen)
                warningPopup.Close();
        }
    }

    public override void Open()
    {
        base.Open();
        _inputs.UI.Enable();
        currentButton = resumeButton;
        SetSelectedButton();
    }

    public override void Close()
    {
        base.Close();
        _inputs.UI.Disable();
    }

    private void PauseInput(InputAction.CallbackContext cxt)
    {
        if (warningPopup.IsOpen)
        {
            warningPopup.Close();
            SetSelectedButton();
        }
        else
        {
            GameManager.Instance.Pause(false);
        }
    }

    private void SetSelectedButton()
    {
        currentButton.button.Select();
    }

    private void OpenRestartPopup()
    {
        warningPopup.SetPopupInfo(GameManager.Instance.globalConfig.restartPopup);
        warningPopup.btnConfirm.button.onClick.AddListener(OnClickRestartHandler);
        currentButton = restartButton;
        warningPopup.Open();
    }

    private void OpenMainMenuPopup()
    {
        warningPopup.SetPopupInfo(GameManager.Instance.globalConfig.mainMenuPopup);
        warningPopup.btnConfirm.button.onClick.AddListener(OnClickMenuHandler);
        currentButton = menuButton;
        warningPopup.Open();
    }

    private void OpenExitPopup()
    {
        warningPopup.SetPopupInfo(GameManager.Instance.globalConfig.exitPopup);
        warningPopup.btnConfirm.button.onClick.AddListener(OnClickQuitHandler);
        currentButton = quitButton;
        warningPopup.Open();
    }

    private void OnClickResumeHandler()
    {
        GameManager.Instance.Pause(false);
    }

    private void OnClickRestartHandler()
    {
        warningPopup.Close();
        SceneManager.LoadScene(GameManager.Instance.globalConfig.gameScene);
    }

    private void OnClickMenuHandler()
    {
        warningPopup.Close();
        SceneManager.LoadScene(GameManager.Instance.globalConfig.mainMenuScene);
    }

    private void OnClickQuitHandler()
    {
        warningPopup.Close();
        Application.Quit();
    }
}
