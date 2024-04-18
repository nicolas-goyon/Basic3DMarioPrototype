using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected string enemyName = "Enemy";

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == Player.Instance.gameObject) { 
            GameManager.Instance.GameOver("You were killed by " + enemyName);
        }
    }
}
