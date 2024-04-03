using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;
    public int pokeBallCount;
    public TextMeshProUGUI pokeBallCountText;
    public void Awake()
    {
         Instance = this;
    }
}
