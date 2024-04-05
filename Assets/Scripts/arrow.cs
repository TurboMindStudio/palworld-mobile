using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    private Rigidbody body;

    private void Start()
    {
         body = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("environmet"))
            {
            body.isKinematic = true;
            audioManager.instance.source.PlayOneShot(audioManager.instance.arrowHit);
        }
    }
}
