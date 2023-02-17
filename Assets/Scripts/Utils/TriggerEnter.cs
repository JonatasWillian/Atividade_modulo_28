using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    public GameObject enemies;
    public GameObject brigdes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            enemies.gameObject.SetActive(true);
            brigdes.gameObject.SetActive(false);
        }
    }
}
