using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJump : MonoBehaviour, IPointerClickHandler
{

    public static MobileJump Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            throw new System.Exception("There can only be one MobileJump script. It is a singleton.");
        }
    }

    public event EventHandler OnJump;

    public void OnPointerClick(PointerEventData eventData) {
        OnJump?.Invoke(this, EventArgs.Empty);
    }
    
}
