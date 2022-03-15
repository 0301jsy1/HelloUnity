using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatator : MonoBehaviour
{
    public float rotationSpeed = 60f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Chosy");
       //안녕하세요
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate 메서드는 입력 값(매개변수)으로 X, Y, Z축에 대한 회전 값을 받고
        //현재 회전 상태에서 입력된 값 만큼 상대적으로 더 회전합니다.
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
