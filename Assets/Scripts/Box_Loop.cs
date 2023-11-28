using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Box_Loop : MonoBehaviour
{
    public GameObject[] Box;
    public GameObject A_Zone;
    public GameObject B_Zone;
    public float Speed = 5f;

    private void Start()
    {
        int a = Random.Range(0, 5);
        A_Zone = Instantiate(Box[a], new Vector3(4,-4.5f,0), transform.rotation);
    }

    void Update()
    {
        Move();
    }

    public void Make()
    {
        B_Zone = A_Zone;
        int a = Random.Range(0, 5);
        A_Zone = Instantiate(Box[a], new Vector3(30,-4.5f,0), transform.rotation);
    }

    public void Move()
    {
        A_Zone.transform.Translate(Vector3.left*Time.deltaTime*Speed, Space.World);
        B_Zone.transform.Translate(Vector3.left*Time.deltaTime*Speed, Space.World);
        if (A_Zone.transform.position.x <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(B_Zone);
        Make();
    }
}
