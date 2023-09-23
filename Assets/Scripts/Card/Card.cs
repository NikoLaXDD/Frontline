using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Card : MonoBehaviour
{
    [SerializeField] private string cardId;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text characterName;

    private void Awake()
    {
        GameManager.Instance.AnswerNoAction += AnswerNo;
        GameManager.Instance.AnswerYesAction += AnswerYes;
    }

    private void OnDestroy()
    {
        GameManager.Instance.AnswerNoAction -= AnswerNo;
        GameManager.Instance.AnswerYesAction -= AnswerYes;
    }

    public void SetData(CardObject cardOData)
    {
        icon.sprite = cardOData.Sprite;
        characterName.text = cardOData.PrefabName;
    }

    public virtual void AnswerNo()
    {
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Manpower] += GameManager.Instance.CurrentEvent.ManpowerMinus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Money] += GameManager.Instance.CurrentEvent.MoneyMinus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Sup] += GameManager.Instance.CurrentEvent.SupMinus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Ammo] += GameManager.Instance.CurrentEvent.AmmoMinus;
    }

    public virtual void AnswerYes()
    {
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Manpower] += GameManager.Instance.CurrentEvent.ManpowerMinus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Money] += GameManager.Instance.CurrentEvent.MoneyMinus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Sup] += GameManager.Instance.CurrentEvent.SupMinus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Ammo] += GameManager.Instance.CurrentEvent.AmmoMinus;
    }
}