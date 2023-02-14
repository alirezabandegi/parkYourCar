using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 gameOverCameraPos = new Vector3(-10, 5, -4);
    private Vector3 gameOverCameraRotation = new Vector3(27, 26, 0);

    public void StartGame()
    {
        target = GameObject.Find("PVT").transform;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gameManager.gameOver == false)
        {
            target.transform.Rotate(0, -180, 0);
        }

        //if (gameManager.gameOver == true)
        //{
        //    transform.position = gameOverCameraPos;
        //    transform.rotation = Quaternion.Euler(gameOverCameraRotation);
        //}
    }

    private void FixedUpdate()
    {
        if (gameManager.gameOver == false)
        {
            HandleTranslation();
            HandleRotation();
        } 
    }

    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}