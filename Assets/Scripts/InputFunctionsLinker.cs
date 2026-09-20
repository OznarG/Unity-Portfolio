using UnityEngine;
using UnityEngine.InputSystem;

public class InputFunctionsLinker : MonoBehaviour
{
    private PlayerInput playerInput;
    //This calls the menus functions with the inputs so is not mixed with the player's
    //buttons here call the menu manager, Anything controlling Menus have to be here
    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        MenuManager.instance.TogglePause();
    }
    public void OnToggleHealtStats(InputAction.CallbackContext ctx)
    { 
        if (!ctx.performed) return;
        MenuManager.instance.OpenHealthStats();
    }
}
