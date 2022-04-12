using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public enum ButtonType
{
    START_GAME,
    OPTIONS_BUTTON,
    BACK_BUTTON,
    QUIT_BUTTON,
    GAMEOVER_MENU_BUTTON,
    PAUSE_MENU_BUTTON,
    RESTART_BUTTON,
    RESUME,
    RESET
}

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    public ButtonType buttonType;

    CanvasManager canvasManager;
    Button menuButton;

    [SerializeField] private GameObject optionsFirstButton, optionsClosedButton, mainMenuFirstButton;
    private GameObject canvas;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();

        canvas = GameObject.Find("Canvas");
        optionsFirstButton = canvas.transform.GetChild(1).GetChild(1).gameObject;
        mainMenuFirstButton = canvas.transform.GetChild(0).GetChild(1).gameObject;
        optionsClosedButton = canvas.transform.GetChild(0).GetChild(2).gameObject;
    }

    void OnButtonClicked()
    {
        switch (buttonType)
        {
            case ButtonType.START_GAME:
                SceneManager.LoadScene("GameScene");
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            case ButtonType.OPTIONS_BUTTON:
                canvasManager.SwitchCanvas(CanvasType.OptionsMenu);

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(optionsFirstButton);
                break;
            case ButtonType.BACK_BUTTON:
                canvasManager.SwitchCanvas(CanvasType.MainMenu);

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(optionsClosedButton);
                break;
            case ButtonType.QUIT_BUTTON:
                Application.Quit();
                Debug.Log("Quit");
                break;
            case ButtonType.RESUME:
                PauseManager.pauseManagerInstance.ResumeGame();
                break;
            case ButtonType.PAUSE_MENU_BUTTON:
                PauseManager.pauseManagerInstance.ResumeGame();
                SceneManager.LoadScene("MainMenu");
                canvasManager.SwitchCanvas(CanvasType.MainMenu);

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
                break;
            case ButtonType.RESTART_BUTTON:
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case ButtonType.GAMEOVER_MENU_BUTTON:
                SceneManager.LoadScene("MainMenu");
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                ScoreManager.ScoreManagerInstance.highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0).ToString();

                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
                break;
            case ButtonType.RESET:
                PlayerPrefs.DeleteKey("highScore");
                ScoreManager.ScoreManagerInstance.highScoreText.text = "High Score: 0";
                break;
            default:
                break;
        }
    }
}