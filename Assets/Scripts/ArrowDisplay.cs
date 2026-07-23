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
}