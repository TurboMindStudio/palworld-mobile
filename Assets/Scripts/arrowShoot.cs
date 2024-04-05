using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class arrowShoot : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public float ArrowSpeed;
    public Transform ArrowPos;
    public Button button;

    private float fireRate = 0;
    public float fireTime;
    private RaycastHit hit;
    private Ray ray;

   public List<GameObject> ArrowList = new List<GameObject>();
    GameObject arrow;

    
    [SerializeField] TextMeshProUGUI arrowTimer;
    private void Start()
    {
        SpwanArrow();
        // button = GetComponent<Button>();
        button.onClick.AddListener(ShootArrow);
        
    }

    private void Update()
    {
        fireRate -= Time.deltaTime;
        int fireRateToInt = Mathf.FloorToInt(fireRate);
        if (fireRate < 0)
        {
            button.interactable = true;
            arrowTimer.text = string.Empty;
        }
        else
        {
            button.interactable = false;
            arrowTimer.text = fireRateToInt.ToString();
        }
    }

    void SpwanArrow()
    {
        arrow =Instantiate(ArrowPrefab, ArrowPos);
    }

    void ShootArrow()
    {
        if (fireRate <= 0)
        {
            InstantiateArrow();
            fireRate = fireTime;
        }
    }

    void InstantiateArrow()
    {
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            audioManager.instance.source.PlayOneShot(audioManager.instance.pokeballThrow);
            Rigidbody rb = arrow.GetComponent<Rigidbody>();

            if (rb != null)
            {
                //efx
                audioManager.instance.source.PlayOneShot(audioManager.instance.arrowShoot);
                arrow.GetComponent<TrailRenderer>().enabled = true;
                //physics
                Vector3 direction = hit.point - Camera.main.transform.position;
                rb.isKinematic = false;
                rb.AddForce(direction.normalized * ArrowSpeed, ForceMode.Impulse);
                Destroy(arrow, 5f);
                arrow.transform.SetParent(null);
                SpwanArrow();

            }
        }
    }


}
