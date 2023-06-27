using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public Vector2 spawnPos = new Vector2(0, 0);

    private void Start()
    {
        PhotonNetwork.Instantiate(ballPrefab.name, spawnPos, Quaternion.identity);
    }
}
