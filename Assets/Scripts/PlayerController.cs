using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D playerRb;

    PhotonView view;

    private void Start()
    {
        playerRb= GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }

    public float speed = 10;

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            playerRb.velocity = new Vector3(horizontalInput * speed, 0, 0);

        }
        
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                this.gameObject.transform.position = new Vector2(-2, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * 3000);
            }
        }
    }
}
