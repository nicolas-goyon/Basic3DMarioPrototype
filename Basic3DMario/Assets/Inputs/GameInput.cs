using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    public static GameInput Instance { get; private set; }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            throw new System.Exception("There can only be one GameInput script. It is a singleton.");
        }
    }

    public event EventHandler OnJump;

    private PlayerInputs playerInputs;
    private MobileMovements mobileMovements;
    private MobileJump mobileJump;





    private void Start() {
        mobileMovements = MobileMovements.Instance;
        mobileJump = MobileJump.Instance;

        playerInputs = new();
        playerInputs.Player.Enable();

        playerInputs.Player.Jump.performed += ctx => OnJump?.Invoke(this, EventArgs.Empty);
        mobileJump.OnJump += (sender, e) => OnJump?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetPlayerMovements() {
        Vector2 mobileInputs = mobileMovements.GetValue();
        if (mobileInputs != Vector2.zero) {
            return mobileInputs;
        }

        return playerInputs.Player.PlaneMovements.ReadValue<Vector2>();
    }

    public void SetPlayerMovements(Vector2 movements) {
    }

}
