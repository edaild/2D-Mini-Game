using UnityEngine;
using UnityEngine.UIElements;

public class viewManager : MonoBehaviour 
{

    private static viewManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Camera.main.backgroundColor = Color.black;

        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    private void Update()
    {
        if(Screen.width != 1920  && Screen.height != 1080 && Screen.fullScreenMode != FullScreenMode.Windowed)
        {
            Screen.SetResolution(1920,  1080, FullScreenMode.Windowed);
        }
    }
}
