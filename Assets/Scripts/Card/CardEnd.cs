using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardEnd : Card
{
    public override void AnswerNo()
    {
        base.AnswerNo();
        SceneManager.LoadScene(0);
    }

    public override void AnswerYes()
    {
        base.AnswerYes();
        SceneManager.LoadScene(0);
    }
}