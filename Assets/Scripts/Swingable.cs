using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(MatchTransform))]
public class Swingable: MonoBehaviour
{
    public UnityEvent PreSwing, SwingStart, SwingPause, SwingEnd;

    private Swinger swinger;
    private void Start()
    {
        swinger = GetComponent<MatchTransform>().target.GetComponent<Swinger>();

        swinger.OnPreSwing += Swinger_OnPreSwing;
        swinger.OnSwingStart += Swinger_OnSwingStart;
        swinger.OnSwingPause += Swinger_OnSwingPause;
        swinger.OnSwingEnd += Swinger_OnSwingEnd;
    }

    private void Swinger_OnSwingEnd()
    {
        SwingEnd.Invoke();
    }

    private void Swinger_OnSwingPause()
    {
        SwingPause.Invoke();
    }

    private void Swinger_OnSwingStart()
    {
        SwingStart.Invoke();
    }

    private void Swinger_OnPreSwing()
    {
        PreSwing.Invoke();
    }
}
