using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; //이동에 사용할 리지드바디 컴포넌트
    public float speed = 10f; //이동 속력
    public GameObject myPlayer; //내 자신을 담을 변수

    
    void Start()   
    {
        //GameObject에서 Rigidbody 컴포넌트를 찾아 PlayerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //DirectInput()

        //수평축과 수직축의 입력 값을 감지해서 저장
        float xInput = Input.GetAxis("Horizontal"); //키보드의 'A' or <- : -X(-1.0f), 키보드의 'D' or -> : +X(+1.0f)
        float zInput = Input.GetAxis("Vertical"); //키보드의 'W' or ^ : +Z(1.0f), 키보드의 'S' or V : -Z(-1.0f)

        //실제 이동 속도를 입력 값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를(xSpeed, of, zSpeed) 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed); //x, y, z

        //Rigidbody의 물리적인 힘X, 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;

    }
    void DirectInput() //PC 키보드 입력 시
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);//x,y,z
        }
        else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
    }
    public void Die()
    {
        myPlayer.SetActive(false);
        //gameObject.SetActive(false);

        //씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
