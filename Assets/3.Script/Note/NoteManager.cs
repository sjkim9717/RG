using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    /*
     BPM 120 가정 => 분 : 60초
    노드 -> 4분음표(1beat)

    60(초)/120(비트) -> 0.5초에 1개씩 송출
     
     */
    [Header("BPM 설정")]
    public int BPM = 0;

    private double current_time = 0d;
    [Header("ETC")]
    [SerializeField] private GameObject notePrefabs;
    [SerializeField] private Transform noteSpawner;

    private TimeManager timemanager;

    private void Awake()
    {
        timemanager = FindObjectOfType<TimeManager>();
    }

    private void Update()
    {
        current_time += Time.deltaTime;
        if (current_time >= (60d / BPM))
        {
            GameObject note_ob = Instantiate(notePrefabs, noteSpawner.position, Quaternion.identity);
            note_ob.transform.SetParent(this.transform);
            timemanager.boxnote_List.Add(note_ob);
            current_time -= (60d / BPM);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("note"))
        {
            if (col.TryGetComponent(out Note n))
            {
                if (n.GetNoteflag())
                {
                    Debug.Log("Miss");
                }
            }
            timemanager.boxnote_List.Remove(col.gameObject);
            Destroy(col.gameObject);
        }
    }

}
