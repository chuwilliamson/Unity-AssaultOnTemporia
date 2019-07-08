﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    GameObject Temporary_Bullet_handler;
    public float Bullet_Forward_Force;
    public float DespawnTime;
    public string Player;
    private void Start()
    { 
    }
    public void Fire()
    {
        Temporary_Bullet_handler = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
        Temporary_Bullet_handler.GetComponent<BulletBehaviour>().shooter = Player;
        Temporary_Bullet_handler.transform.Rotate(Vector3.right, 90);
        Rigidbody Temporary_rigidbody;
        Temporary_rigidbody = Temporary_Bullet_handler.GetComponent<Rigidbody>();
        
        Temporary_rigidbody.AddForce(transform.forward * Bullet_Forward_Force);
        Destroy(Temporary_Bullet_handler, DespawnTime);
    }
    // Update is called once per frame
    void Update ()
    {
      
	}
}