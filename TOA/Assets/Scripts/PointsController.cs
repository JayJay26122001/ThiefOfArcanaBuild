using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsController : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void AttPoints(int newPoints)
    {
        pointsText.text = "Points : " + newPoints.ToString();
    }
}
