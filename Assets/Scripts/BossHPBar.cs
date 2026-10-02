using UnityEngine;

public class BossHPBar : MonoBehaviour
{
    public static BossHPBar Instance;

    public RectTransform fillBar;

    public GameObject background;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        background.SetActive(true);
    }

    public void Hide()
    {
        background.SetActive(false);
    }

    public void SetHP(int currentHP, int maxHP)
    {
        float ratio = (float)currentHP / maxHP;

        fillBar.localScale =
            new Vector3(ratio, 1f, 1f);
    }
}