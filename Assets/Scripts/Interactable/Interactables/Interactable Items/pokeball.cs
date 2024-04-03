using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokeball : Interactable
{
    protected override void Interact()
    {
        GameManager.Instance.pokeBallCount++;
        GameManager.Instance.pokeBallCountText.text = GameManager.Instance.pokeBallCount.ToString();
        Destroy(gameObject);
    }
}
