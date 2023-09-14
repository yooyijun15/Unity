using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = -5;
    Player player; // Player.cs를 player이라는 이름으로 불러오기
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(name: "Player").GetComponent<Player>(); // Player.cs 불러오기
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0); // 시간 흐름에 따라 Wall 위치 이동
        if (transform.position.x < -17) // 일정 위치에 Wall 오브젝트 도달하면 삭제 후 player의 addScore 함수 호출하여 값 변경
        {
            Destroy(gameObject); // 오브젝트 삭제
            player.addScore(1); // Player.cs의 addScore 함수 호출
        }
    }
}
