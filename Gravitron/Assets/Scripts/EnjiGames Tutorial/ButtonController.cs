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

    private GameObject pauseManager;
    //private GameObject player;

    private void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = CanvasManager.GetInstance();

        pauseManager = GameObject.Find("PauseSystem");
        //player = GameObject.Find("Player");
        //currentPlayerHealth = playerHealth.currentPlayerHealth;
        //}
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
                Debug.Log("Quit");
                break;
            case ButtonType.GAMEOVERMENU_BUTTON:
                GameManager.Manager.gameOverScreen.SetActive(false);
                SceneManager.LoadScene("MainMenu");
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                break;
            case ButtonType.PAUSEMENU_BUTTON:
                pauseManager.GetComponent<PauseManager>().ResumeGame();
                SceneManager.LoadScene("MainMenu");
                canvasManager.SwitchCanvas(CanvasType.MainMenu);
                break;
            case ButtonType.RESTART_BUTTON:
                canvasManager.SwitchCanvas(CanvasType.GameUI);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            default:
                break;
        }
    }
}