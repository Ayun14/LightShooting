using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBackgroundMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -18f)
        {
            transform.position = new Vector3(20, 0, 0);
        }
    }
}
