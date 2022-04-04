using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum ButtonType
{
    START_GAME,
    OPTIONS_BUTTON,
    BACK_BUTTON,
    QUIT_BUTTON,
    GAMEOVERMENU_BUTTON,
    PAUSEMENU_BUTTON,
    RESTART_BUTTON
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
                //Call other code that is necessary to start the game like levelManager.StartGame()
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
                break;
            case ButtonType.GAMEOVERMENU_BUTTON:
                GameManager.Manager.gameOver = false;
                GameManager.Manager.gameOverScreen.SetActive(false);
                SceneManager.LoadScene("MainMenu");
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                break;
            case ButtonType.PAUSEMENU_BUTTON:
                PauseManager.paused = false;
                GameManager.Manager.gameOverScreen.SetActive(false);
                SceneManager.LoadScene("MainMenu");
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                break;
            case ButtonType.RESTART_BUTTON:
                SceneManager.GetActiveScene();
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                break;
            default:
                break;
        }
    }
}