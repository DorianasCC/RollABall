using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Respawn : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private int lives;

    public TextMeshProUGUI livesText;
    public GameObject gameoverTextObject;

    void Start()
    {
        lives = 3;

        SetLivesText();
        gameoverTextObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;

        lives = lives - 1;

        SetLivesText();
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();

        if(lives <= 0)
        {
            gameoverTextObject.SetActive(true);
        }
    }
}
