using UnityEngine;
//using UnityEditor.Search;


public class MidBoss : MonoBehaviour
{
    public int hp = 10;

    private int maxHp;

    public void TakeDamage()
    {
        hp--;

        BossHPBar.Instance.SetHP(hp, maxHp);

        if(hp > 0)
        {
            Teleport();
        }

        if(hp <= 0)
        {
            BossHPBar.Instance.Hide();

            GameManager.Instance.Clear();

            Destroy(gameObject);
        }
    }
    private void Teleport()
    {
        Vector2 pos;

        do
        {
            pos = new Vector2(
                Random.Range(-6f, 6f),
                Random.Range(-4f, 4f)
            );
        }
        while(pos.magnitude < 2.5f);

        transform.position = pos;
    }

    private void Start()
    {
        maxHp = hp;

        BossHPBar.Instance.Show();

        BossHPBar.Instance.SetHP(hp, maxHp);
    }
}