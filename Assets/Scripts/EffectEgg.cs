using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectEgg : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Animator());
        Destroy(gameObject, 1f);
    }
    public IEnumerator Animator()
    {
        yield return new WaitForSeconds(0.8f);
        transform.localScale += new Vector3(4, 4, 4);
    }

}
