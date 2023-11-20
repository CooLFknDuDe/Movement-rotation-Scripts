using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace MyGameForMED3
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField][Range(0f, 10f)] private float defaultDistance = 6f;
        [SerializeField][Range(0f, 10f)] private float minimumDistance = 1f;
        [SerializeField][Range(0f, 10f)] private float maximumDistance = 10f;

        [SerializeField][Range(0f, 10f)] private float smoothing = 4f;
        [SerializeField][Range(0f, 10f)] private float zoomSensitivity = 1f;

        private CinemachineFramingTransposer framingTransposer;
        private CinemachineInputProvider InputProvider;

        private float currentTargetDistance;

        private void Awake()
        {
            framingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
            InputProvider = GetComponent<CinemachineInputProvider>();
            currentTargetDistance = defaultDistance;
            
        }
        private void Update()
        {
            Zoom();
            string logMessage = InputProvider.tag + " or " + InputProvider.name + " is " + InputProvider.isActiveAndEnabled;
            Debug.Log(logMessage);
        }
        private void Zoom()
        {
            float zoomValue = InputProvider.GetAxisValue(2) * zoomSensitivity;
            
            currentTargetDistance = Mathf.Clamp(currentTargetDistance + zoomValue,minimumDistance, maximumDistance);

            float currentDistance = framingTransposer.m_CameraDistance;

            if (currentDistance == currentTargetDistance) 
            {
                return;
            }

            float lerpedZoomValue = Mathf.Lerp(currentDistance, currentTargetDistance, smoothing * Time.deltaTime);
            framingTransposer.m_CameraDistance = lerpedZoomValue;
        }

    }
}
