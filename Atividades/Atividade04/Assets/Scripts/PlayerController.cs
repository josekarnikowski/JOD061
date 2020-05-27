﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed = 0.1f;
    public float moveRotation = 10;
    public GameObject projetilPrefab;
    public Transform projetilPosition;

    // Start is called before the first frame update
    void Start()
    {
        Material material = GetComponent<Renderer>().material;
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed);
        transform.Rotate(0, Input.GetAxis("Horizontal") * moveRotation, 0);

        if (Input.GetKeyUp(KeyCode.Space))
            CmdAtirar();
    }
    [Command]
    void CmdAtirar()
    {
        GameObject projetil = Instantiate(projetilPrefab, projetilPosition.position, transform.rotation);
        NetworkServer.Spawn(projetil);
    }
}
