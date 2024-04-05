using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeballprop : MonoBehaviour
{
    [SerializeField] GameObject captureParticle;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pals"))
        {
            Debug.Log("capture");
            Destroy(other.gameObject);
            audioManager.instance.source.PlayOneShot(audioManager.instance.pokeballElectricCap);
            audioManager.instance.source.PlayOneShot(audioManager.instance.pokeballCapture);
            Instantiate(captureParticle,transform.position, Quaternion.identity);
        }
    }
}
