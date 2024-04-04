using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PokeballShoot : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed;
    public Transform shootPoint;
    public Button button;

    private float fireRate;

    private void Start()
    {
       // button = GetComponent<Button>();
        button.onClick.AddListener(ShootFireball);
    }

    private void Update()
    {
        fireRate -= Time.deltaTime;
    }

    void ShootFireball()
    {
        if (fireRate <= 0)
        {
            InstantiateFireball();
            fireRate = 2;
        }
    }

    void InstantiateFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * fireballSpeed,ForceMode.Impulse);

        }
    }
}
