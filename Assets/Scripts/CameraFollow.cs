using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float minDistance = 20f; // Jarak minimum untuk zoom out
    public float maxDistance = 40f; // Jarak maksimum untuk zoom in
    public float zoomSpeed = 5f; // Kecepatan zoom

    private Vector3 targetPosition;
    private float initialDistance;

    void Start()
    {
        if (player1 != null && player2 != null)
        {
            // Set initial distance between players
            initialDistance = Vector3.Distance(player1.position, player2.position);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player1 != null && player2 != null)
        {
            // Hitung rata-rata posisi pemain
            targetPosition = (player1.position + player2.position) / 2f;

            // Hitung jarak antara pemain saat ini
            float currentDistance = Vector3.Distance(player1.position, player2.position);

            // Sesuaikan jarak kamera berdasarkan jarak antara pemain
            float targetDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
            float zoomFactor = Mathf.Lerp(1f, initialDistance / currentDistance, zoomSpeed * Time.deltaTime);
            targetDistance = Mathf.Lerp(transform.position.z, -targetDistance, zoomFactor);

            // Update posisi kamera berdasarkan posisi rata-rata pemain dan jarak yang disesuaikan
            transform.position = targetPosition + new Vector3(0f, 5f, targetDistance);

            // Sesuaikan rotasi kamera agar selalu menghadap ke rata-rata posisi pemain
            transform.LookAt(targetPosition);
        }
    }
}