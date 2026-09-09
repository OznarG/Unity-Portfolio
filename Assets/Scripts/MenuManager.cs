using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public PlayerInput input;
    public bool isPaused;
    public GameObject selectedMenu;
    public GameObject pauseMenu;
    public GameObject healthStatsMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        input = GameManager.instance._playerObj.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePause()
    {       
        if (!isPaused)
        {
            selectedMenu = pauseMenu;
            selectedMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            Cursor.visible = true;
            isPaused = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            selectedMenu.SetActive(false);
            selectedMenu = null;            
            isPaused = false;
            
        }
    }
    public void OpenHealthStats()
    {
        if(isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            selectedMenu.SetActive(false);
            selectedMenu = null;
            isPaused = false;
        }
        else
        {
            selectedMenu = healthStatsMenu;
            selectedMenu.SetActive(true);
            Time.timeScale = 0;          
            isPaused = true;
        }
    }
}
