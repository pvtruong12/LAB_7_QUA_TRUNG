using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventCanVas:MonoBehaviour
{
    public Messgae msg;
    public GameObject gameObj;
    private Main main;
    void Start()
    {
        main = gameObj.GetComponent<Main>();
    }
    public void ReStar()
    {
        SceneManager.LoadScene(0);
        if(main.isMeWin())
        {
            msg.InitLose -= 5;
            msg.InitWin += 5;
        }
        Time.timeScale = 1;
    }
}
