using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float speed;

    private Transform cameraTransform;

    private Vector3 offset;

    private void Awake()
    {
        cameraTransform = this.transform;

        offset = cameraTransform.position - player.position;
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        cameraTransform.DOMoveX(player.position.x + offset.x, speed * Time.deltaTime);
        cameraTransform.DOMoveZ(player.position.z + offset.z, speed * Time.deltaTime);
    }
}
