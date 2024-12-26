using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSingle : MonoBehaviour
{
    public Transform player1;
    public float minDistance = 20f; // Jarak minimum untuk zoom out
    public float maxDistance = 40f; // Jarak maksimum untuk zoom in
    public float zoomSpeed = 5f; // Kecepatan zoom

    private Vector3 targetPosition;
    private float initialDistance;

    void Start()
    {
        if (player1 != null)
        {
            // Set initial distance between the player and some default point (e.g., camera's initial position)
            initialDistance = Vector3.Distance(player1.position, transform.position);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player1 != null)
        {
            // Hitung jarak antara pemain dan posisi kamera
            float currentDistance = Vector3.Distance(player1.position, transform.position);

            // Sesuaikan jarak kamera berdasarkan jarak antara pemain
            float targetDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
            float zoomFactor = Mathf.Lerp(1f, initialDistance / currentDistance, zoomSpeed * Time.deltaTime);
            targetDistance = Mathf.Lerp(transform.position.z, -targetDistance, zoomFactor);

            // Update posisi kamera berdasarkan posisi pemain dan jarak yang disesuaikan
            transform.position = player1.position + new Vector3(0f, 5f, targetDistance);

            // Sesuaikan rotasi kamera agar selalu menghadap ke posisi pemain
            transform.LookAt(player1.position);
        }
    }
}
