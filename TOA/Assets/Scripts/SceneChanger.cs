using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instancia;
    public int vidas = 1;

    public void Awake()
    {
        if(instancia == null)
        {
            instancia = this;
        }
    }

    public void ChangeScene(string scene)
    {
        AudioController.controller.ChangeMusic(scene);
        SceneManager.LoadScene(scene);
        GameController.controller.ResetPoints();
        GameController.controller.ResetTotalPoints();
    }

    public void PlayerDeathScene(int dano)
    {
        vidas -= dano;
        if(vidas <= 0)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial"))
            {
                AudioController.controller.ChangeMusic("Derrota");
                SceneManager.LoadScene("DerrotaTutorial");
                if (GameController.controller != null)
                {
                    GameController.controller.ResetPoints();
                }
            }
            else
            {
                AudioController.controller.ChangeMusic("Derrota");
                SceneManager.LoadScene("Derrota");
                if (GameController.controller != null)
                {
                    GameController.controller.ResetPoints();
                }
            }
        }

    }
}
