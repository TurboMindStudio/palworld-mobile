using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeballprop : MonoBehaviour
{
    [SerializeField] float throwSpeed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.AddForce(transform.right*throwSpeed*Time.deltaTime);
    }
}
