using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField]
    private float delay;

    [SerializeField]
    private UnityEvent OnDestroy;

    void OnEnable()
    {
        StartCoroutine( Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds( delay );

        OnDestroy.Invoke();
        gameObject.SetActive(false );
    }
}
