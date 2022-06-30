using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0f;
    
    public Text scoreText;
    public GameObject WinTextObject;

    private Rigidbody rb;
    private AudioSource pop;
    private int count;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        pop = GetComponent<AudioSource>();
        SetScoreText();
        WinTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {  
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + count.ToString();

        if(count >= 12)
        {
            WinTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        rb.AddForce(movement*speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUps"))
        {
            pop.Play();
            other.gameObject.SetActive(false);
            count = count+1;
            
            SetScoreText();
        }
    }
}
