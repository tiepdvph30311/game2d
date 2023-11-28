using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    void OnRestartButtonClick()
    {
        Debug.Log("Nút Restart được nhấn!");
        FindObjectOfType<tuontac>().RestartGame();
    }
}
