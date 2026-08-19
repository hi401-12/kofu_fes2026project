using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ArrowDisplay : MonoBehaviour
{
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    public GameObject arrowPrefab;

    public void DisplayCommands(List<Direction> commands)
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        foreach(Direction dir in commands)
        {
            GameObject arrow =
                Instantiate(arrowPrefab, transform);

            Image image =
                arrow.GetComponent<Image>();

            //Debug.Log(image);

            switch(dir)
            {
                case Direction.Up:
                    image.sprite = upSprite;
                    break;

                case Direction.Down:
                    image.sprite = downSprite;
                    break;

                case Direction.Left:
                    image.sprite = leftSprite;
                    break;

                case Direction.Right:
                    image.sprite = rightSprite;
                    break;
            }
        }
    }


    public void UpdateDisplay(
        List<Direction> commands,
        int currentIndex)
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for(int i = currentIndex;
            i < commands.Count;
            i++)
        {
            GameObject arrow =
                Instantiate(arrowPrefab, transform);

            Image image =
                arrow.GetComponent<Image>();

            switch(commands[i])
            {
                case Direction.Up:
                    image.sprite = upSprite;
                    break;

                case Direction.Down:
                    image.sprite = downSprite;
                    break;

                case Direction.Left:
                    image.sprite = leftSprite;
                    break;

                case Direction.Right:
                    image.sprite = rightSprite;
                    break;
            }
        }
    }
}