using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointScript : MonoBehaviour
{
    private GameManager gameManager;
    public Text checkpointText;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.lastCheckpoint = transform.position;
            checkpointText.text = "Checkpoint Reached";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            checkpointText.text = "";
        }
    }
}
