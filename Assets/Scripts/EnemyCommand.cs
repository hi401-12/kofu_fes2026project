using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCommand : MonoBehaviour
{
    public TMP_Text commandText;

    public List<Direction> commands = new();

    private int currentIndex = 0;

    private ArrowDisplay arrowDisplay;

    private void Start()
    {
        GenerateCommand();

        //commandText.text = GetCommandText();

        arrowDisplay = GetComponentInChildren<ArrowDisplay>();

        if(arrowDisplay != null){
            arrowDisplay.DisplayCommands(commands);
        }


        //Debug.Log(string.Join(",", commands));
    }

    void GenerateCommand()
    {
        int length = 3 + (ScoreManager.Instance.score / 60);

        for(int i = 0; i < length; i++)
        {
            commands.Add(
                (Direction)Random.Range(0, 4)
            );
        }
    }

    public void ProcessInput(Direction input)
    {

        if(input == commands[currentIndex])
        {
            currentIndex++;

            arrowDisplay.UpdateDisplay(
                commands,
                currentIndex
            );

            if(currentIndex >= commands.Count)
            {
                ScoreManager.Instance.AddScore(1);
                
                Destroy(gameObject);
            }
        }

        if(currentIndex >= commands.Count)
            return;
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