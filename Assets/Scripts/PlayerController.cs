using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D playerRb;
    private SpriteRenderer playerRenderer;

    public float jumpForce;

    PhotonView view;

    private void Start()
    {
        playerRb= GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    public float speed = 10;

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            playerRb.velocity = new Vector3(horizontalInput * speed, playerRb.velocity.y, 0);
        }
        
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                this.gameObject.transform.position = new Vector2(-2, 0);
                playerRb.velocity = new Vector3(0, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * jumpForce);
            }
        }
        else
        {
            playerRb.simulated = false;
        }

    }

}
