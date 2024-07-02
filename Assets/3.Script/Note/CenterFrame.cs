using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame : MonoBehaviour
{

    /*
     ù��° ��尡 ������ �� �뷡�� �÷���
        -> ��尡 �浹������ 
            -> �浹 -> Ʈ����
     
     */

    private AudioSource source;
    private bool isStart = false;


    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isStart)
        {
            if (col.CompareTag("note"))
            {
                source.Play();
                isStart = true;
            }
        }
    }

}
