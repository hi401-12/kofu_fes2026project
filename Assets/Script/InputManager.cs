using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            SendInput(Direction.Up);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            SendInput(Direction.Down);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SendInput(Direction.Left);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            SendInput(Direction.Right);
        }
    }

    void SendInput(Direction dir)
    {
        EnemyCommand[] enemies =
            FindObjectsByType<EnemyCommand>(
                FindObjectsSortMode.None
            );

        foreach(var enemy in enemies)
        {
            enemy.ProcessInput(dir);
        }
    }
}