using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject EffectEgg;
    private GameObject mhCharGame;
    private Main myChar;
    void Start()
    {
        mhCharGame = GameObject.Find("Main");
        myChar = mhCharGame.GetComponent<Main>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("MatDat"))
        {
            Destroy(gameObject);
            Instantiate(EffectEgg, transform.position, Quaternion.identity);
            myChar.Miss++;
            myChar.textMiss.text = "Miss: " + myChar.Miss+"/"+myChar.msg.InitLose;
        }
        if(collision.CompareTag("GioDung"))
        {
            myChar.animator.SetTrigger("isPick");
            myChar.Diem++;
            myChar.textScore.text = "Score: " + myChar.Diem + "/" + myChar.msg.InitWin;
            Destroy(gameObject);
        }
    }
}
