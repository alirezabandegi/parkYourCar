using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkPlaces : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PVT"))
        {
            gameObject.SetActive(false);
            gameManager.gameOver = true;
        }
    }
}
