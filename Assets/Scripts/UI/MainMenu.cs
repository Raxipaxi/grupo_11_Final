//using CustomUpdateManagerNSP;
using TMPro;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Windows;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public GlobalConfig globalConfig;
    public AudioManager audioManager;

    [Header("Screens")]
    public Panel menu;
    public Panel credits;

    [Header("Skip")]
    public TextMeshProUGUI skipText;

    [Header("Buttons")]
    public MenuButton playButton;
    public MenuButton creditsButton;
    public MenuButton quitButton;
    public MenuButton goBackButton;

    private MenuButton currentSelectedButton;
    private List<MenuButton> buttons = new List<MenuButton>();
    private static GameInputs _inputs;

    void Awake()
    {
        buttons.Add(playButton);
        buttons.Add(creditsButton);
        buttons.Add(quitButton);
        buttons.Add(goBackButton);

        for (int i = 0; i < buttons.Count; i++)
        {
            //buttons[i].button.onClick.AddListener(SelectButtonSound);
            buttons[i].Deselect();
        }

        playButton.button.onClick.AddListener(OnClickPlayHandler);
        creditsButton.button.onClick.AddListener(OnClickCreditsHandler);
        quitButton.button.onClick.AddListener(OnClickQuitHandler);
        goBackButton.button.onClick.AddListener(OnClickGoBackHandler);

        _inputs = new GameInputs();
        _inputs.Enable();
        _inputs.Menu.SkipMenu.performed += SkipMenu;
        _inputs.Menu.GoBack.performed += GoBack;

        skipText.text = $"{_inputs.Menu.SkipMenu.GetBindingDisplayString()} to skip";
    }

    private void Start()
    {
        AudioManager.instance.PlayMusic(AudioManager.instance.soundReferences.mainMenu);
        currentSelectedButton = playButton;
        GoBack();
    }

    private void SkipMenu(InputAction.CallbackContext cxt)
    {
        OnClickPlayHandler();
    }

    private void GoBack(InputAction.CallbackContext cxt)
    {
        if (!credits.IsOpen) return;
        GoBack();
    }

    private void GoBack()
    {
        menu.Open();
        credits.Close();
        SelectButton(currentSelectedButton);
    }

    //private void SelectButtonSound()
    //{
    //    AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.selectButton);
    //}

    private void OnClickPlayHandler()
    {
        SceneManager.LoadScene(globalConfig.gameScene);
    }

    private void OnClickCreditsHandler()
    {
        currentSelectedButton = creditsButton;
        menu.Close();
        credits.Open();
        SelectButton(goBackButton);
    }

    private void SelectButton(MenuButton button)
    {
        button.button.Select();
    }

    private void OnClickGoBackHandler()
    {
        GoBack();
    }

    private void OnClickQuitHandler()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].button.onClick.RemoveAllListeners();
        }

        _inputs.Menu.GoBack.performed -= GoBack;
        _inputs.Menu.SkipMenu.performed -= SkipMenu;
    }
}