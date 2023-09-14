using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour // Player: 스크립트명
{
    // 변수 생성 및 값 지정
    public float jumpPower = 5;
    public float jumpBoost = 1.2f;
    public float lowWarn = -5;
    float size = 0.05f;
    int score = 0;
    TextMesh scoreOutput; // TextMesh를 scoreOutput이라는 이름으로 불러오기
    // Start is called before the first frame update
    void Start() // 시작 구성
    {
        scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>(); // TextMesh 불러오기
    }

    // Update is called once per frame
    void Update() // 실행 중 구성
    {
        transform.position += new Vector3(size * Time.deltaTime, 0, 0); // 시간 흐름에 따라 Player 위치 이동
        transform.localScale += new Vector3(0, size * Time.deltaTime, 0); // 시간 흐름에 따라 Player 크기 변경
        if (Input.GetButtonDown("Jump"))
        {
            if (transform.position.y < lowWarn){
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower * jumpBoost, 0);
            } // Player 위치가 일정 위치보다 낮아지면 실행
            else{
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
                // GetComponent<Rigidbody>(): 게임 개체에 연결된 Rigidbody 구성 요소 불러오기
                // .velocity: 속도
            }
        }
    }
    private void OnCollisionEnter(Collision collision) // 다른 오브젝트와 충돌할 때 자동으로 호출되는 Unity 이벤트 메서드
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 장면 재로드
        // SceneManager: 게임 장면을 관리하는 Unity 클래스
        // SceneManager.GetActiveScene(): 현재 활성 장면 검색
        // .name: 현재 활성화된 장면 이름
    }

    public void addScore(int s) // addScore 함수 생성
    {
        score += s;
        scoreOutput.text = "점수 : " + score;
    }
}
