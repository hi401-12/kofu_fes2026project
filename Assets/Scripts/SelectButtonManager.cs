using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ma : MonoBehaviour
{
    public RectTransform[] menuItems;
    public RectTransform cursor;
    public float moveSpeed = 10f;

    public GameObject firstButton;

    private int selected = 0;
    private Vector2 cursorTarget;

    private void Start()
    {
        selected = 0;

        if (cursor != null)
        {
            cursor.position = menuItems[selected].position;
            cursorTarget = cursor.position;
        }

        if (EventSystem.current != null && firstButton != null)
        {
            EventSystem.current.SetSelectedGameObject(firstButton);
        }
    }

    private void Update()
    {
        if (cursor != null)
        {
            cursor.position = Vector3.Lerp(
                cursor.position,
                cursorTarget,
                moveSpeed * Time.deltaTime
            );
        }
    }

    private void SelectNext()
    {
        selected++;

        if (selected >= menuItems.Length)
        {
            selected = 0;
        }

        UpdateCursorTarget();
    }

    private void SelectPrevious()
    {
        selected--;

        if (selected < 0)
        {
            selected = menuItems.Length - 1;
        }

        UpdateCursorTarget();
    }

    private void UpdateCursorTarget()
    {
        if (cursor != null)
        {
            cursorTarget = menuItems[selected].position;
        }
    }

    private void Select()
    {
       if (selected < 0 || selected >= menuItems.Length)
        return;

        Button button = menuItems[selected].GetComponent<Button>();

        if (button != null)
        {
            button.onClick.Invoke();
        }
    }

    public void OnUp(InputValue value)
    {
        if (value.isPressed)
        {
            SelectPrevious();
        }
    }

    public void OnDown(InputValue value)
    {
        if (value.isPressed)
        {
            SelectNext();
        }
    }

    public void OnSubmit(InputValue value)
    {
        //Debug.Log("Submit: " + value.isPressed);
        if (value.isPressed)
        {
            //Debug.Log("Submt: " + value.isPressed);
            Select();
        }
    }
}