﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinger : MonoBehaviour
{
    public bool swingLeft;
    private bool swinging;

    public void DoSwing(float stretch, float arc, float speed, float pause, Action callback = null)
    {
        if (!swinging)
        {
            StartCoroutine(Swing(stretch, arc, speed, pause, callback));
        }
    }

    private IEnumerator Swing(float stretch, float arc, float speed, float pause, Action callback)
    {
        swinging = true;
        var startPos = transform.localPosition;
        var startRot = transform.localRotation;

        transform.position += transform.up * stretch;
        yield return null;

        float reach = transform.localPosition.magnitude;
        float angle = Mathf.Atan2(transform.localPosition.x, transform.localPosition.y) * Mathf.Rad2Deg;
        float targetAngle = angle + (swingLeft ? -arc : arc);
        //var target = Quaternion.AngleAxis(arc, swingLeft ? Vector3.forward : Vector3.back) * transform.localPosition;

        //while (transform.localPosition != target)
        while (angle != targetAngle) 
        {
            //float angle = Mathf.Atan2(transform.localPosition.x, transform.localPosition.y) * Mathf.Rad2Deg;

            //transform.localPosition = Vector3.RotateTowards(transform.localPosition, target, speed * Time.deltaTime, float.PositiveInfinity);

            angle = Mathf.MoveTowards(angle, targetAngle, speed * Time.deltaTime);

            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.back);
            transform.localPosition = transform.localRotation * (Vector3.up * reach);
            yield return null;
        }

        yield return new WaitForSeconds(pause);

        transform.localPosition = startPos;
        transform.localRotation = startRot;

        callback?.Invoke();

        swinging = false;
    }
}
