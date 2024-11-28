using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject gameObjEgg;
    public Messgae msg;
    private bool isFlipX =false;
    public float speed = 2f;
    public int Diem = 0;
    public int Miss = 0;
    private int num = 0;
    public int numMax = 100;
    public int step = 5;
    public TMP_Text textScore;
    public TMP_Text textMiss;
    public TMP_Text WinorLose;
    public GameObject Panel;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void FlipX()
    {
        isFlipX = !isFlipX;
        Vector3 vc = transform.localScale;
        vc.x = vc.x * -1;
        transform.localScale = vc;
    }
    public bool isMeWin()
    {
        return Diem >= msg.InitWin;
    }
    public bool isMeLose()
    {
        return Miss >= msg.InitLose;
    }
    void FixedUpdate()
    {
        if(isMeWin() || isMeLose())
        {
            Time.timeScale = 0;
            Panel.SetActive(true);
            WinorLose.text = isMeWin() ? "You Win" : "You Lose";
        }
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = Vector2.Lerp(rb.velocity,new Vector2(x * speed, 0), 0.1f);
        if(x > 0 && isFlipX)
        {
            FlipX();
        }
        else if(x < 0 && !isFlipX)
        {
            FlipX();
        }
        
        num++;
        if(num >= numMax)
        {
            num = 0;
            if (numMax > 5)
                numMax -= step;
            else
                numMax = 5;
            Instantiate(gameObjEgg, new Vector2(Random.Range(-2f, 2.5f), 6),Quaternion.identity);
            return;
        }
    }
}
