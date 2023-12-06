using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TelaFinal : MonoBehaviour
{
    public TextMeshProUGUI totalPointsText;

    void Start()
    {
        ShowTotalPoints();
    }

    void OnDisable()
    {
        ResetTotPoints();
    }

    public void ShowTotalPoints()
    {
        if(GameController.controller != null)
        {
            int finalPoints = GameController.controller.TotalPoints();
            totalPointsText.text = finalPoints.ToString();
        }
    }

    public void ResetTotPoints()
    {
        if(GameController.controller != null)
        {
            GameController.controller.ResetTotalPoints();
        }
    }
}
