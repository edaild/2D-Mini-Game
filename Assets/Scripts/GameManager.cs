using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float GameMinTime = 1;
    [SerializeField] private float GameTime;
    [SerializeField] private GameObject UICanvers;
    [SerializeField] private GameObject FnishUICanverse;
    [SerializeField] private Text PlayTime;
    [SerializeField] private Text MinPlayTime;

    public bool isUICanvers;
    public bool isFnishUICanvers;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        if (!isUICanvers || isFnishUICanvers)
            GameTime += Time.deltaTime;
        
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
        isFnishUICanvers = false;
        UICanvers.gameObject.SetActive(false);
        FnishUICanverse.gameObject.SetActive(false);
    }
    
    public void ReGameButton()
    {
        GameTime = 0;
        playerController.transform.position = playerController.player_point.position;
        PlayGameButton();

    }

    public void ExitButton()
    {
        PlayGameButton();
        SceneManager.LoadScene("LobbyScene");
    }
 
    public void CollisionCastle()
    {
        if(GameTime > GameMinTime)
        {
            GameMinTime = GameTime;
        }

        FnishUICanverse.gameObject.SetActive(true);
    }

}
