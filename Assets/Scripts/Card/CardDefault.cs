using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDefault : Card
{
    public override void AnswerYes()
    {
        base.AnswerYes();
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Manpower] += GameManager.Instance.CurrentEvent.ManpowerPlus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Money] += GameManager.Instance.CurrentEvent.MoneyPlus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Sup] += GameManager.Instance.CurrentEvent.SupPlus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Ammo] += GameManager.Instance.CurrentEvent.AmmoPlus;
    }

    public override void AnswerNo()
    {
        base.AnswerNo();
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Manpower] += GameManager.Instance.CurrentEvent.ManpowerMinus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Money] += GameManager.Instance.CurrentEvent.MoneyMinus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Sup] += GameManager.Instance.CurrentEvent.SupMinus;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Ammo] += GameManager.Instance.CurrentEvent.AmmoMinus;
    }
}
