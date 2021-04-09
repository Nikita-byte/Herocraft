using UnityEngine;
using System;


public class CheckPoint : MonoBehaviour
{
    [SerializeField] private bool _isInScore;
    [SerializeField] private float Tpos;
    [SerializeField] private bool _isEnd;

    public Action<float, bool, bool> CheckPointHandler = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        CheckPointHandler.Invoke(Tpos, _isInScore, _isEnd);
    }
}
