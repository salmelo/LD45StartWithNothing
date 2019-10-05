using UnityEngine;
using System.Collections;

[CreateAssetMenu()]
public class HandItem: ScriptableObject
{
    public MatchTransform itemPrefab;
    public float swingStretch, swingArc, swingTime, swingPause;

    public MatchTransform SpawnItem(Transform hand)
    {
        var item = Instantiate(itemPrefab, hand.position, hand.rotation);
        item.target = hand;
        return item;
    }

    public void DoSwing(Swinger swinger, System.Action callback = null)
    {
        swinger.DoSwing(swingStretch, swingArc, swingTime, swingPause, callback);
    }
}
