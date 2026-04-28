using System;
using UnityEngine;
using BilliotGames;

public class AxisJumpVectorReceiver : JumpVectorReceiverBase
{
    public event Action<Vector2> OnVectorReceived;

    public override bool TryFindInput() => true;
    public override bool IsInputConnected() => true;

    protected override void RegisterReceiveEvent() {
        OnVectorReceived -= GetAxis;
        OnVectorReceived += GetAxis;
    }

    protected override void UnregisterReceiveEvent() {
        OnVectorReceived -= GetAxis;
    }

    private void Update() {
        if (Input.GetButtonDown("Jump"))
            GetAxis(Vector2.up);
        else
            GetAxis(Vector2.zero);
    }

    private void GetAxis(Vector2 vector) {
        inputVector = vector;
    }
}