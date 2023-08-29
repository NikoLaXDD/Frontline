using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Destroy(gameObject);
            GameManager.Instance.AnswerYes();
            if (!GameManager.Instance.EndGame())
            {
                GameManager.Instance.InstantiateCard();
            }
        }
        else if(_lastPos.x <= -2)
        {
            Destroy(gameObject);
            GameManager.Instance.AnswerNo();
            if (!GameManager.Instance.EndGame())
            {
                GameManager.Instance.InstantiateCard();
            }
        }
    }
}
