using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform playerTransform; // 플레이어 프리팹의 트랜스폼

    private Transform tf; //카메라 컨테이너의 트랜스폼 
    private Transform cameraTf; //카메라의 트랜스폼

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform; //인스턴스 생성시 플레이어 캐싱 
        tf = GetComponent<Transform>();
        cameraTf = FindObjectOfType<Camera>().transform;
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 currentPos = cameraTf.localPosition;
        float targetY;

        if (playerTransform.position.y >= 4f)
        {
            targetY = 9f;
        }
        else
        {
            targetY = 5f;
        }


        float smoothY = Mathf.Lerp(currentPos.y, targetY, 0.1f);

        cameraTf.localPosition = new Vector3(0, smoothY, -5f);


        Vector3 playerPosition = new Vector3(0, 0, playerTransform.position.z); //z축만 추적 


        tf.position = playerPosition;
    }
}