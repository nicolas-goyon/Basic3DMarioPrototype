using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{
    public event EventHandler OnFinishLineTouched;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == Player.Instance.gameObject) { 
            OnFinishLineTouched?.Invoke(this, EventArgs.Empty);
        }
    }
}
