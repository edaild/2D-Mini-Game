using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float GameMinTime;
    [SerializeField] private float GameTime;
    [SerializeField] private GameObject UICanvers;
    [SerializeField] private GameObject FnishUICanverse;
    [SerializeField] private Text PlayTime;
    [SerializeField] private Text FnishPlayTime;
    [SerializeField] private Text MinPlayTime;

    public bool isUICanvers;

    private PlayerController playerController;

    private int minutes;
    private int seconds;

    private int minTimeminutes;
    private int minTimehseconds;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        if (!isUICanvers)
            GameTime += Time.deltaTime;

        // 분과 초 계산
        minutes = (int)(GameTime / 60f);
        seconds = (int)(GameTime % 60f);

        minTimeminutes = (int)(GameMinTime / 60f);
        minTimehseconds = (int)(GameMinTime % 60f);

        PlayTime.text = ($"{minutes} : {seconds}");

    }


    public void CollisionCastle()
    {
        isUICanvers = true;
        if (GameTime < GameMinTime || GameMinTime == 0)
        {
            GameMinTime = GameTime;
        }
        PlayTime.gameObject.SetActive(false);
        FnishUICanverse.gameObject.SetActive(true);
        FnishPlayTime.text = ($"클리어 시간 : {minutes} : {seconds}");
        MinPlayTime.text = ($"최고 기로 : {minTimeminutes} : {minTimehseconds}");
    }

    public void MenuButton()
    {
        if (!isUICanvers)
        {
            isUICanvers = true;
            UICanvers.gameObject.SetActive(true);
        }
        else
        {
            isUICanvers = false;
            UICanvers.gameObject.SetActive(false);
        }
    }



    public void PlayGameButton()
    {
        isUICanvers = false;
        UICanvers.gameObject.SetActive(false);
        FnishUICanverse.gameObject.SetActive(false);
        PlayTime.gameObject.SetActive(true);
    }

    public void ReGameButton()
    {
        GameTime = 0;
        playerController.transform.position = playerController.player_point.position;
        PlayGameButton();

    }

    public void EnxitGame()
    {
        SceneManager.LoadScene("LobbyScene");
    }

}
