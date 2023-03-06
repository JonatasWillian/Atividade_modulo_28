using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnter : MonoBehaviour
{
    [Header("EventEnter")]
    public UnityEvent eventEnter;

    [Header("EventExit")]
    public UnityEvent eventExit;

    /*[Header("Triggers")]
    public GameObject enemies;
    public GameObject brigdes;*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //enemies.gameObject.SetActive(true);
            //brigdes.gameObject.SetActive(false);
            eventEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            eventExit?.Invoke();
        }
    }
}

