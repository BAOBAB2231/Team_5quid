using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform playerTransform;
    private Transform tf;

    private void Start()
    {
        tf = GetComponent<Transform>();
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        tf.position = playerTransform.position;
    }

}
