using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] parkPlaces;
    public GameObject[] activeGameObjects;
    private CameraFollow cameraFollow;
    public bool gameOver;
    // Start is called before the first frame update
    public void StartGame()
    {
        cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        gameOver = false;

        int randomNumForParkPlaces = Random.Range(0, parkPlaces.Length);
        parkPlaces[randomNumForParkPlaces].SetActive(true);
        activeGameObjects[0].SetActive(true);
        activeGameObjects[1].SetActive(true);
        cameraFollow.StartGame();
    }


}
