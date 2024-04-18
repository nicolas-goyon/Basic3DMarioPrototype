using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovements : MonoBehaviour
{
    public static MobileMovements Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            throw new System.Exception("There can only be one KnobInput script. It is a singleton.");
        }
    }

    private KnobHandler knobHandler;

    private void Start() {
        knobHandler = GetComponent<KnobHandler>();
    }

    public Vector2 GetValue() {
        return knobHandler.Value;
    }
}
