using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody; //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; //탄알 이동 속력
    void Start()
    {
        //GameObject에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();

        //Rigidbody의 속도 = 앞쪽 방향 * 이동 속력;
        bulletRigidbody.velocity = transform.forward * speed;
        //transform.forward : 나를(해당 오브젝트) 기준으로 한 앞쪽 방향

        Destroy(gameObject,3f);//Player가 일정 시간에 도달하면 사라지게 함
                               //OnCollison : 두 개 모두 IsTrigger가 체크 안 되었다면 OnCollison 사용 => Collison로 받아들임
                                //1. Enter : 나랑 충돌 체크 감지 
                                //2. Stay : 나랑 충돌중인 것을 체크
                                //3. Exit : 나랑 충돌 벗어나는 순간을 체크
                               //OnTrigger : 두 개 모두 IsTrigger가 체크되었다면 OnTrigger 사용 => Collider로 받아들임
                                //1. Enter : 나랑 충돌 체크 감지 
                                //2. Stay : 나랑 충돌중인 것을 체크
                                //3. Exit : 나랑 충돌 벗어나는 순간을 체크
    }

    //트리거 충돌 시 자동으로 실행되는 메서드
    private void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가졌나요?
        if(other.tag == "Player")
        {
            //상대방(충돌한) 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            //상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if(playerController != null)
            {
                //playerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
