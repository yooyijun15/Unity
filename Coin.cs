using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 Player 오브젝트인지 확인
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player 스크립트의 addScore 함수 호출하여 점수 추가
            player.addScore(1);

            // Coin 프리팹 인스턴스 삭제
            Destroy(gameObject);
        }
    }
}
