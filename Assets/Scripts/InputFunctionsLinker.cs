using UnityEngine;
using UnityEngine.InputSystem;

public class InputFunctionsLinker : MonoBehaviour
{
    private PlayerInput playerInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        MenuManager.instance.TogglePause();
    }
}
