using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth.hp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}