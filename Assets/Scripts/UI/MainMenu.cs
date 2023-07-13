//using CustomUpdateManagerNSP;
using TMPro;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Windows;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public GlobalConfig globalConfig;

    [Header("Screens")]
    public Panel menu;
    public Panel credits;

    [Header("Skip")]
    public KeyCode skipKey = KeyCode.F1;
    public TextMeshProUGUI skipText;

    [Header("Buttons")]
    public MenuButton playButton;
    public MenuButton creditsButton;
    public MenuButton quitButton;
    public MenuButton goBackButton;
    public KeyCode goBackKey = KeyCode.Escape;

    private MenuButton currentSelectedButton;
    private List<MenuButton> buttons = new List<MenuButton>();
    //private static MenuesInputs _inputs;

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

        skipText.text = $"{skipKey} to skip";

        //_inputs = new MenuesInputs();
        //_inputs.Enable();
        //_inputs.Game.Pause.performed += GoBack;
        //_inputs.Game.SkipMenu.performed += SkipMenu;
    }

    private void Start()
    {
        //AudioManager.instance.PlayMusic(AudioManager.instance.soundReferences.mainMenu);

        currentSelectedButton = playButton;
        GoBack();
    }

    //private void SkipMenu(InputAction.CallbackContext cxt)
    //{
    //    OnClickPlayHandler();
    //}

    //private void GoBack(InputAction.CallbackContext cxt)
    //{
    //    if (!credits.IsOpen) return;
    //    GoBack();
    //}

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

        //_inputs.Game.Pause.performed -= GoBack;
        //_inputs.Game.SkipMenu.performed -= SkipMenu;
    }
}