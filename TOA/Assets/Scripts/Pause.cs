using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pause_Panel;
    public GameObject Player;
   
    void Start()
    {
        pause_Panel.SetActive(false);
        Time.timeScale = 1;
        Player = GameObject.FindWithTag("Player");
    }

   
    void Update()
    {
        
    }

    public void PauseButton()
    {
        pause_Panel.SetActive(true);
        Time.timeScale = 0;
        Player.GetComponent<Player>().enabled = false;
    }

    public void PauseLeave()
    {
        pause_Panel.SetActive(false);
        Time.timeScale = 1;
        Player.GetComponent<Player>().enabled = true;
    }
}
