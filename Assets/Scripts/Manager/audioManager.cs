using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager instance;
    public AudioSource source;
    public AudioClip pokeballThrow;
    public AudioClip pokeballCapture;
    public AudioClip pokeballElectricCap;
    public AudioClip arrowShoot;
    public AudioClip arrowHit;
    public void Awake()
    {
        instance = this;
    }
}
