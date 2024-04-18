using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private FinishLineCollider finishLineCollider;

    private void Start() {
        finishLineCollider.OnFinishLineTouched += OnFinishLineTouched;
    }

    private void OnFinishLineTouched(object sender, System.EventArgs e) { 
        GameManager.Instance.GameOver("You win!");
    }

}
