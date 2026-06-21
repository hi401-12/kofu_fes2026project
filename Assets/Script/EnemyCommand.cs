using System.Collections.Generic;
using UnityEngine;
using TMpro;

public class EnemyCommand : MonoBehaviour
{
    public List<Direction> commands = new();

    private int currentIndex = 0;

    private void Start()
    {
        GenerateCommand();

        Debug.Log(string.Join(",", commands));
    }

    void GenerateCommand()
    {
        int length = 3;

        for(int i = 0; i < length; i++)
        {
            commands.Add(
                (Direction)Random.Range(0, 4)
            );
        }
    }

    public void ProcessInput(Direction input)
    {
        if(currentIndex >= commands.Count)
            return;

        if(input == commands[currentIndex])
        {
            currentIndex++;

            if(currentIndex >= commands.Count)
            {
                Destroy(gameObject);
            }
        }
    }

    public string GetCommandText()
    {
        string result = "";

        foreach(Direction dir in commands)
        {
            switch(dir)
            {
                case Direction.Up:
                    result += "↑";
                break;

                case Direction.Down:
                    result += "↓";
                break;

                case Direction.Left:
                    result += "←";
                break;

                case Direction.Right:
                    result += "→";
                break;
            }
        }

        return result;
    }
}