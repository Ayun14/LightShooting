using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    void Update() => MoveBackground();

    void MoveBackground()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -24f)
        {
            transform.position = new Vector3(32, 0, 0);
        }
    }
}