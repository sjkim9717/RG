using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Timing -> ��� ���� -> ����� ���� position�� �������� ������ ����
    [Header("Perfect -> Cool -> Good -> Bad")]
    [SerializeField] private RectTransform[] timingRect;
    private Vector2[] TimeBox;// ���� ������ �ּڰ��� �ִ��� ���ϱ� ���ؼ�
    [SerializeField] private RectTransform Center;

    public List<GameObject> boxnote_List = new List<GameObject>();

    private void Start()
    {
        TimeBox = new Vector2[timingRect.Length];
        // �ּڰ��� �ִ�
        // �̹����� �߽� +- (�̹��� �ʺ� / 2)
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
    {//Ȯ���� �� �� ���(box���� �Ѿ ���)�� �˱����ؼ�
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
                    // ���� timebox�� ���� �ȿ� ���� ��� ������ �� ��Ȳ
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
