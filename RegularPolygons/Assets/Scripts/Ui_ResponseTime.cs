using RegularPolygons.Core;
using TMPro;
using UnityEngine;

namespace RegularPolygons.Ui
{
    public class Ui_ResponseTime : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        TextMeshProUGUI label;

        [SerializeField]
        [TextArea]
        string unformattedText = "Your response time: {0}ms";

        float previousClickTime = 0f;

        private void OnEnable()
        {
            DoubleClickManager.OnPolygonShapeDoubleClicked += DoubleClickManager_OnPolygonShapeDoubleClicked;
        }
        private void OnDisable()
        {
            DoubleClickManager.OnPolygonShapeDoubleClicked -= DoubleClickManager_OnPolygonShapeDoubleClicked;
        }

        private void DoubleClickManager_OnPolygonShapeDoubleClicked(PolygonShape obj)
        {
            float timeDifference = Time.time - previousClickTime;
            previousClickTime = Time.time;
            string timeInMilliseconds = (timeDifference * 1000f).ToString("F0");
            label?.SetText(string.Format(unformattedText, timeInMilliseconds));
        }     
    }
}