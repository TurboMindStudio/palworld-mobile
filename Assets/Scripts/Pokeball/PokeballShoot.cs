using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PokeballShoot : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed;
    public Transform shootPoint;
    public Button button;

    private float fireRate = 0;
    public float fireTime;
    private RaycastHit hit;
    private Ray ray;

    [SerializeField] Image pokeballImg;
    [SerializeField] TextMeshProUGUI pokeTimer;
    private void Start()
    {
       // button = GetComponent<Button>();
        button.onClick.AddListener(ShootFireball);
    }

    private void Update()
    {
        fireRate -= Time.deltaTime;
        int fireRateToInt=Mathf.FloorToInt(fireRate);
        if( fireRate < 0)
        {
            pokeballImg.color = Color.white;
            pokeTimer.text = string.Empty;
        }
        else
        {
            pokeballImg.color = Color.gray;
            pokeTimer.text = fireRateToInt.ToString();
        }

    }

    void ShootFireball()
    {
        if (fireRate <= 0)
        {
            InstantiateFireball();
            fireRate = fireTime;
        }
    }

    void InstantiateFireball()
    {
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            audioManager.instance.source.PlayOneShot(audioManager.instance.pokeballThrow);
            GameObject fireball = Instantiate(fireballPrefab, shootPoint.position, Quaternion.identity);
            Rigidbody rb = fireball.GetComponent<Rigidbody>();

            if (rb != null)
            {

                Vector3 direction = hit.point - Camera.main.transform.position;
                rb.AddForce(direction.normalized * fireballSpeed,ForceMode.Impulse);

            }
        }
    }
}
