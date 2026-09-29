using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
    if (!context.performed) return;

    Vector2 input = context.ReadValue<Vector2>();

    if (input.y > 0.5f)
        SendInput(Direction.Up);
    else if (input.y < -0.5f)
        SendInput(Direction.Down);
    else if (input.x > 0.5f)
        SendInput(Direction.Right);
    else if (input.x < -0.5f)
        SendInput(Direction.Left);
    }

    void SendInput(Direction dir)
    {
        EnemyCommand[] enemies =
            FindObjectsByType<EnemyCommand>(
                FindObjectsSortMode.None
            );

        foreach (var enemy in enemies)
        {
            enemy.ProcessInput(dir);
        }
    }
}