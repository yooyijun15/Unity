using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] wallPrefab; // 프리팹 불러오기, [] 배열을 사용하여 여러개의 오브젝트 불러오기
    public GameObject[] dropPrefab;
    public float interval = 1.5f;
    public float range = 3;
    float term; // 간격
    // Start is called before the first frame update
    void Start()
    {
        term = interval;
    }

    // Update is called once per frame
    void Update()
    {
        term += Time.deltaTime;
        if (term >= interval)
        {
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range); 
            int wallType = Random.Range(0, wallPrefab.Length);
            Instantiate(wallPrefab[wallType], pos, transform.rotation);
            int dropType = Random.Range(0, dropPrefab.Length);
            if (Random.Range(0, 2) == 0)
                Instantiate(dropPrefab[dropType]);
            term -= interval;
        }
    }
}
