using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ButtonType
{
    START_GAME,
    OPTIONS_BUTTON,
    BACK_BUTTON,
    QUIT_BUTTON,
    GAMEOVER_MENU_BUTTON,
    PAUSE_MENU_BUTTON,
    RESTART_BUTTON,
    RESUME
}

[RequireComponent(typeof(Button))]
public class ButtonController : MonoBehaviour
{
    public ButtonType buttonType;

    CanvasManager canvasManager;
    Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();
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
                break;
            case ButtonType.BACK_BUTTON:
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
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
                break;
            case ButtonType.RESTART_BUTTON:
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            case ButtonType.GAMEOVER_MENU_BUTTON:
                SceneManager.LoadScene("MainMenu");
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                break;
            default:
                break;
        }
    }
}