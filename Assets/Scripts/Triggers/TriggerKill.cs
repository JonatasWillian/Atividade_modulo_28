using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerKill : MonoBehaviour
{
    [Header("Events")]
    //public UnityEvent triggerKill;

    private HealthBase healthBase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //healthBase.Kill();
            healthBase.Damage();
        }
    }
}
