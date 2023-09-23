using System;
using UnityEngine;

public class CardFlipping : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    
    private Vector2 _cursor;

    private Vector3 _lastPos;

    private void Update()
    {
        MouseCheck();
        
        if (Input.GetMouseButton(0))
        {
            MouseDown();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
    }

    private void MouseDown()
    {
        transform.position = new Vector2(_cursor.x, 0);
    }

    private void MouseUp()
    {
        _lastPos = transform.position;
        transform.position = startPosition;
        CardDestroy();
    }

    private void MouseCheck()
    {
        _cursor = Input.mousePosition;
        _cursor = Camera.main.ScreenToWorldPoint(_cursor);
    }

    private void CardDestroy()
    {
        if (_lastPos.x >= 2)
        {
            GameOver.Instance.CheckForNextStep();
            Destroy(gameObject);
            GameManager.Instance.AnswerYesAction?.Invoke();
            if (!GameOver.Instance.IsGameOver)
            {
                GameManager.Instance.InstantiateCard();
            }
        }
        else if(_lastPos.x <= -2)
        {
            GameOver.Instance.CheckForNextStep();
            Destroy(gameObject);
            GameManager.Instance.AnswerNoAction?.Invoke();
            if (!GameOver.Instance.IsGameOver)
            {
                GameManager.Instance.InstantiateCard();
            }
        }
    }
}
