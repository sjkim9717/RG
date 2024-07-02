using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private TimeManager timemanager;
    private void Start()
    {
        timemanager = FindObjectOfType<TimeManager>();
    }

    private void Update()
    {
        //입력 했을 경우 타이밍 판정
        if(Input.GetKeyDown(KeyCode.Space))
        { 
            timemanager.check_Timing();        
        }
    }

}
