using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalendarController : MonoBehaviour
{
    [SerializeField] private TMP_Text textDays;
    [SerializeField] private TMP_Text textMonth;
    [SerializeField] private TMP_Text textYears;

    public enum CalendarType
    {
        Days,
        Months,
        Years
    }

    public Dictionary<CalendarType, int> calendar = new Dictionary<CalendarType, int>()
    {
        {CalendarType.Days, 1},
        {CalendarType.Months, 1},
        {CalendarType.Years, 2123}
    };
    
    public static CalendarController Instance;
    
    public CalendarController()
    {
        Instance = this;
    }

    public void DaysControl()
    {
        UpdateCalendar();
        
        if (calendar[CalendarType.Days] >= 31)
        {
            calendar[CalendarType.Months]++;
        }

        if (calendar[CalendarType.Months] >= 12)
        {
            calendar[CalendarType.Years]++;
        }
        
        calendar[CalendarType.Days]++;
    }

    public void UpdateCalendar()
    {
        textDays.text = calendar[CalendarType.Days].ToString();
        textMonth.text = calendar[CalendarType.Months].ToString();
        textYears.text = calendar[CalendarType.Years].ToString();
    }
}
