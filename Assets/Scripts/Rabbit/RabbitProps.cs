using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitProps : MonoBehaviour
{
    public static RabbitProps Instance { get; private set; }
    public bool isCaptured;

    public void Awake()
    {
        Instance = this;
    }

   
}
