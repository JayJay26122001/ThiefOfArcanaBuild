using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController controller;
    public UIController uiController;
    public float[] lanes = new float[3] { -3.5f, 0f, 3.5f };
    public int currentPoints;
    public int totalPoints;

    void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddPoints(int value)
    {
        currentPoints += value;
        totalPoints += value;
    }

    public void ResetPoints()
    {
        currentPoints = 0;
    }

    public void ResetTotalPoints()
    {
        totalPoints = 0;
    }

    public int TotalPoints()
    {
        return totalPoints;
    }
}
