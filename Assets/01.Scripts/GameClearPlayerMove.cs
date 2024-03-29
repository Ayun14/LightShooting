using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameClearPlayerMove : MonoBehaviour
{
    private void Start()
    {
        UpDownMove();
    }
    private void UpDownMove()
    {
        transform.DOMoveY(0f, 1f).SetEase(Ease.Linear).SetLoops(-3, LoopType.Yoyo);
    }
}
