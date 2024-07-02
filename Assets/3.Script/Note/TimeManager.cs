using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Timing -> 노드 판정 -> 노드의 현재 position의 기준으로 판정을 내림
    [Header("Perfect -> Cool -> Good -> Bad")]
    [SerializeField] private RectTransform[] timingRect;
    private Vector2[] TimeBox;// 판정 범위의 최솟값과 최댓값을 구하기 위해서
    [SerializeField] private RectTransform Center;

    public List<GameObject> boxnote_List = new List<GameObject>();

    private void Start()
    {
        TimeBox = new Vector2[timingRect.Length];
        // 최솟값과 최댓값
        // 이미지의 중심 +- (이미지 너비 / 2)
        for (int i = 0; i < timingRect.Length; i++)
        {
            TimeBox[i].Set
                (
                     Center.localPosition.x - (timingRect[i].rect.width / 2),
                     Center.localPosition.x + (timingRect[i].rect.width / 2)
                );
        }

    }

    public bool check_Timing()
    {//확인이 안 될 경우(box범위 넘어간 경우)를 알기위해서
        for(int i=0;i<boxnote_List.Count;i++)
        {
            float notePos_x = boxnote_List[i].transform.localPosition.x;
            for (int j = 0; j < TimeBox.Length; j++)
            {
                if(TimeBox[j].x<=notePos_x&&notePos_x<=TimeBox[j].y)
                {
                    if (boxnote_List[i].transform.TryGetComponent(out Note n))
                    {
                        n.HideNote();
                    }
                    // 현재 timebox의 범위 안에 있을 경우 판정이 난 상황
                    Debug.Log(Debug_Note(j));
                    return true;
                }
            }
        }
        return false;

    }

    public string Debug_Note(int x)
    {
        switch (x)
        {
            case 0:
                return "Perfect";

            case 1:
                return "Cool";

            case 2:
                return "Good";

            case 3:
                return "Bad";

            default:
                return string.Empty;
        }
    }

}
