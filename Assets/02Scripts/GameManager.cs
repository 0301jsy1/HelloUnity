using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임 오버 시 활성화할 텍스트 게임 오브젝트
    public GameObject gameOverText;
    //생존 시간을 표시할 텍스트 컴포넌트
    public Text timeText;
    //최고 기록을 표시할 텍스트 컴포넌트
    public Text recordText;
    //실제 생존 시간
    private float surviveTime;
    //게임오버 상태
    private bool isGameOver;

    void Start()
    {
        //생존 시간과 게임 오버 상태 초기화
        surviveTime = 0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버가 아닌 동안
        if(!isGameOver)
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 timeText 컴포넌트를 이용해 표시
            timeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            //게임 오버인 상태에서 사용자가 R키를 누른다면
            if(Input.GetKeyDown(KeyCode.R))
            {
                //Level1 씬을 로드
                SceneManager.LoadScene("Level1");
            }
        }
    }
    //현재 게임을 게임 오버 상태로 변경하는 메서드
    public void EndGame()
    {
        //현재 상태를 게임 오버 상태로 전환
        isGameOver = true;
        //게임 오버 텍스트 게임 오브젝트를 활성화
        gameOverText.SetActive(true);
        //콤포턴트 비활성화시 timeText.enabled = true;

        //기록을 데이터로 저장하는 방법 => Get : 값을 읽기. / Set : 값을 저장
        //PlayerPrefs.SetInt("Money",1000);  /  PlayerPrefs.SetString("Nick","Chosy");
        //PlayerPrefs.GetInt("Money");   /    PlayerPrefs.GetString("Nick");

        //BestTime 키로 저장된 이전까지의 최고 기록을 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        //이전까지의 최고 기록(bestTime)과 현재 생존 시간(surviveTime) 비교
        if (bestTime < surviveTime)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            //변경된 최고 기록을 bestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        //최고 기록을 recordText 컴포넌트에 표시
        recordText.text = "BestTime : " + (int)bestTime;
    }

}
