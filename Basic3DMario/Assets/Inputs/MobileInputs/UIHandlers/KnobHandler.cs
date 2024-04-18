using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KnobHandler : MonoBehaviour
{
    // Personalized Variables


    [Header("Knob Settings")]
    [SerializeField] private Sprite knobSprite;
    [SerializeField] private Color knobSpriteColor = Color.white;
    [SerializeField] private float knobSize = 50f;

    [Header("Knob Icon Settings")]
    [SerializeField] private Sprite iconSprite;
    [SerializeField] private Color iconColor = Color.white;
    [SerializeField] private float iconScale = 0.9f;

    [Header("Knob Area Settings")]
    [SerializeField] private Sprite areaSprite;
    [SerializeField] private Color areaColor = new(0, 0, 0, 0.5f);
    [SerializeField] private float areaScale = 3f;
    [SerializeField] private bool displayArea = true;


    // Components

    [Header("Components")]
    private KnobButton knob;
    private Image knobArea;


    public Vector2 Value { get; private set; }


    // ***** MonoBehaviour *****

    private void Start() {
        CreateComponents();
    }

    private void Update() {
        if (knob.isPressed) {
            HandlePressed();
        }else {
            Value = Vector2.zero;
        }
        UpdateKnobPosition();
    }



    private void HandlePressed() {
        Vector3 baseInput = (Input.mousePosition - transform.position);
        float maxDistance = areaScale * knobSize / 4;
        Value = (Vector2)baseInput / maxDistance;
        Value = Vector2.ClampMagnitude(Value, 1);
    }

    private void UpdateKnobPosition() {
        float maxDistance = areaScale * knobSize / 4;
        Vector2 newPosition = Value * maxDistance;

        knob.transform.position = transform.position + (Vector3)newPosition;
    }







    // ***** Gizmos *****

    private bool isChanged = true;

    private void OnValidate() {
        isChanged = true;
    }




    private void OnDrawGizmos() {
        if (isChanged) {
            CreateGizmos();
        }
    }



    // ***** Private Methods *****

    private void ClearChildrenGizmos() {
        foreach (Transform child in transform) {
            DestroyImmediate(child.gameObject);
        }
    }

    private void CleanGizmos() {
        foreach (Transform child in transform) {
            if (child.gameObject == knob.gameObject) {
                continue;
            }
            if (displayArea && child.gameObject == knobArea.gameObject) { 
                continue;
            }
            DestroyImmediate(child.gameObject);
        }
    }

    private void ClearChildren() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

    private void CreateComponents() {
        ClearChildren();
        if (displayArea)
            knobArea = CreateKnobArea();
        knob = CreateKnob(transform);
    }

    private void CreateGizmos() {
        ClearChildrenGizmos();
        if (displayArea)
            knobArea = CreateKnobArea();
        knob = CreateKnob(transform);
        isChanged = false;
        CleanGizmos();
    }




    private KnobButton CreateKnob(Transform parent) {
        GameObject knobGO = new("Knob");
        knobGO.transform.parent = parent;
        knobGO.transform.localPosition = new Vector3(0, 0, 0);
        knobGO.transform.localScale = Vector3.one;
        knobGO.AddComponent<RectTransform>().sizeDelta = new Vector2(knobSize, knobSize);
        knobGO.AddComponent<Image>().sprite = knobSprite;
        knobGO.GetComponent<Image>().color = knobSpriteColor;
        knobGO.AddComponent<KnobButton>();
        knobGO.AddComponent<GraphicRaycaster>();
        CreateKnobIcon(knobGO.transform);


        return knobGO.GetComponent<KnobButton>();
    }

    private Image CreateKnobIcon(Transform parent) {
        
        GameObject knobIconGO = new("Knob Icon");
        knobIconGO.transform.parent = parent;
        knobIconGO.transform.localPosition = Vector3.zero;
        knobIconGO.transform.localScale = Vector3.one;
        knobIconGO.AddComponent<RectTransform>().sizeDelta = new Vector2(iconScale * knobSize, iconScale * knobSize);
        knobIconGO.AddComponent<Image>().sprite = iconSprite;
        knobIconGO.GetComponent<Image>().color = iconColor;
        return knobIconGO.GetComponent<Image>();
    }


    private Image CreateKnobArea() {
        GameObject knobAreaGO = new("Knob Area");
        knobAreaGO.transform.parent = transform;
        knobAreaGO.transform.localPosition = new Vector3(0, 0, -1);
        knobAreaGO.transform.localScale = Vector3.one;
        knobAreaGO.AddComponent<RectTransform>().sizeDelta = new Vector2(areaScale * knobSize, areaScale * knobSize);
        knobAreaGO.AddComponent<Image>().color = areaColor;
        knobAreaGO.GetComponent<Image>().sprite = areaSprite;
        return knobAreaGO.GetComponent<Image>();
    }

}
