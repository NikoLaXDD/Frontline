using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusBarController : MonoBehaviour
{
    [SerializeField] private TMP_Text textMoney;
    [SerializeField] private TMP_Text textSup;
    [SerializeField] private TMP_Text textManpower;
    [SerializeField] private TMP_Text textAmmo;

    public static StatusBarController Instance;

    public StatusBarController()
    {
        Instance = this;
    }
    
    public void UpdateStatusBar()
    {
        textMoney.text = StatusController.Instance.statsDictionaty[StatusController.StatusType.Money].ToString();
        textSup.text = StatusController.Instance.statsDictionaty[StatusController.StatusType.Sup].ToString();
        textManpower.text = StatusController.Instance.statsDictionaty[StatusController.StatusType.Manpower].ToString();
        textAmmo.text = StatusController.Instance.statsDictionaty[StatusController.StatusType.Ammo].ToString();
    }
}
