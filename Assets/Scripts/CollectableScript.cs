using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{

public AudioClip collectedClip;
Rigidbody2D rigidbody2d;

void Start()
{
    rigidbody2d = GetComponent<Rigidbody2D>();
}

void OnTriggerEnter2D(Collider2D other)
{
    CloakController controller = other.GetComponent<CloakController>();

    if (controller != null)
    {
        //put a score changer in here like controller.ChangeHealth(1);
        controller.Collect();
        controller.ChangeScore(1);
        Destroy(gameObject);
        controller.PlaySound(collectedClip);
    }
}
}