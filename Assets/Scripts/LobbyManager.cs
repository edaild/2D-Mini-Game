using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public GameObject TutoUI;

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Tuto()
    {
        TutoUI.SetActive(true);
    }

    public void TutoExit()
    {
        TutoUI.gameObject.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
