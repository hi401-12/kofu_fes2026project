using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEditor;

public class EnemyCommand : MonoBehaviour
{
    public TMP_Text commandText;

    public List<Direction> commands = new();

    private int currentIndex = 0;

    private ArrowDisplay arrowDisplay;

    public GameObject hitEffect;

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
        commands.Clear();

        MidBoss boss = GetComponent<MidBoss>();

        int length;

        if(boss != null)
        {
            length = Random.Range(6, 9);
        }
        else
        {
            length = 3 + (ScoreManager.Instance.score / 60);
        }

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

            arrowDisplay.UpdateDisplay(
                commands,
                currentIndex
            );
            if(currentIndex >= commands.Count)
            {
                ScoreManager.Instance.AddScore(1);

                Instantiate(
                    hitEffect,
                    transform.position,
                    Quaternion.identity
                );

                MidBoss boss =
                 GetComponent<MidBoss>();

                if(boss != null)
                {
                    boss.TakeDamage();

                    GenerateCommand();

                    currentIndex = 0;

                    arrowDisplay.DisplayCommands(commands);

                    return;
                }

                Destroy(gameObject);
            }
        }

        if(currentIndex >= commands.Count)
            return;
    }

    /*Vector2 command;
    void GetCommand(InputAction.CallbackContext context)
    {
       command = context.ReadValue<Vector2>();  

       if(context.started)
        {
            MoveGrid(command);
        }      
    }

    void MoveGrid(Vector2 command)
    {
        Debug.Log(command);
    }
*/
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