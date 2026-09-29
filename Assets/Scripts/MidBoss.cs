using UnityEngine;

public class MidBoss : MonoBehaviour
{
    public int hp = 4;

    public void TakeDamage()
    {
        hp--;

        //Debug.Log("Boss HP : " + hp);

        if(hp <= 0)
        {
            EnemySpawner.Instance.bossBattle = false;

            Destroy(gameObject);
        }
    }
}