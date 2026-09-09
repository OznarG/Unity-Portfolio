using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public PlayerInput input;
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

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        Debug.Log("PauseWasPressed");
    }
}
