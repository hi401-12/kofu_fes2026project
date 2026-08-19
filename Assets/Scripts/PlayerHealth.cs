using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 5;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        //Debug.Log("HP : " + hp);

        if(hp <= 0)
        {
           // Debug.Log("GAME OVER");
           GameManager.Instance.GameOver();
        }
    }
}