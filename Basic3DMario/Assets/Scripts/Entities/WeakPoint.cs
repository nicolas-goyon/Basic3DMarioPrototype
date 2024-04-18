using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    
    public event EventHandler<Collision> OnWeakPointTouched;

    private void OnCollisionEnter(Collision collision) {
        OnWeakPointTouched?.Invoke(this, collision);
    }
}
