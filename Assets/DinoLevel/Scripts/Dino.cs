using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public Rigidbody2D dino;
    public float jumpStrength;
    public bool dinoIsGrounded = false;
    private bool dinoIsAlive = true;

    void Start()
    {

    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && dinoIsAlive && dinoIsGrounded)
        {
            dino.velocity = Vector2.up * jumpStrength;
            dinoIsGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            dinoIsGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
            dinoIsAlive = false;
            Time.timeScale = 0f;
        }
    }

    public bool GetDinoIsAlive()
    {
        return dinoIsAlive;
    }
}
