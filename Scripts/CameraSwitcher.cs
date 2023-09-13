using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]private CinemachineVirtualCamera _cam;
private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cam.Priority = 11;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cam.Priority = 0;
        }
    }
}
