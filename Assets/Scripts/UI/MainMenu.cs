//using CustomUpdateManagerNSP;
using TMPro;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Windows;

public class MainMenu : MonoBehaviour
{
    public string LEVE_SCENE = "Level";

    [Header("Screens")]
    public GameObject menu;
    public GameObject credits;

    [Header("Skip")]
    public KeyCode skipKey = KeyCode.F1;
    public TextMeshProUGUI skipText;

    [Header("Buttons")]
    public MenuButton playButton;
    public MenuButton creditsButton;
    public MenuButton quitButton;
    public MenuButton goBackButton;
    public KeyCode goBackKey = KeyCode.Escape;

    private bool notInMainMenu;
    private MenuButton currentSelectedButton;
    //private static MenuesInputs _inputs;

    void Awake()
    {
        //playButton.button.onClick.AddListener(SelectButtonSound);
        //creditsButton.button.onClick.AddListener(SelectButtonSound);
        //quitButton.button.onClick.AddListener(SelectButtonSound);
        //goBackButton.button.onClick.AddListener(SelectButtonSound);

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
    //    if (!notInMainMenu) return;
    //    GoBack();
    //}

    private void GoBack()
    {
        menu.SetActive(true);
        credits.SetActive(false);
        notInMainMenu = false;
        SelectButton(currentSelectedButton);
    }

    //private void SelectButtonSound()
    //{
    //    AudioManager.instance.PlaySFXSound(AudioManager.instance.soundReferences.selectButton);
    //}

    private void OnClickPlayHandler()
    {
        SceneManager.LoadScene(LEVE_SCENE);
    }

    private void OnClickCreditsHandler()
    {
        currentSelectedButton = creditsButton;
        notInMainMenu = true;
        menu.SetActive(false);
        credits.SetActive(true);
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
        playButton.button.onClick.RemoveAllListeners();
        creditsButton.button.onClick.RemoveAllListeners();
        quitButton.button.onClick.RemoveAllListeners();
        goBackButton.button.onClick.RemoveAllListeners();

        //_inputs.Game.Pause.performed -= GoBack;
        //_inputs.Game.SkipMenu.performed -= SkipMenu;
    }
}