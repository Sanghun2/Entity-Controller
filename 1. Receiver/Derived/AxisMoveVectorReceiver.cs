using System;
using UnityEngine;

namespace BilliotGames
{
    public class AxisMoveVectorReceiver : MoveVectorReceiverBase
    {
        public event Action<Vector2> OnVectorReceived;

        public override bool TryFindInput() {
            return true;
        }

        public override bool IsInputConnected() {
            return true;
        }

        protected override void RegisterReceiveEvent() {
            OnVectorReceived -= GetAxis;
            OnVectorReceived += GetAxis;
        }

        protected override void UnregisterReceiveEvent() {
            OnVectorReceived -= GetAxis;
        }


        private void Update() {
            GetAxis(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        private void GetAxis(Vector2 vector) {
            inputVector = vector;
        }

    }
}
