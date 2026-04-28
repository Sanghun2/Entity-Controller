using UnityEngine;

namespace BilliotGames
{
    public abstract class JumpVectorReceiverBase : VectorReceiverBase
    {
        private void Awake() {
            var receiver = GetComponent<JumpVectorReceiverBase>();
            if (receiver != null && receiver != this) {
                Destroy(receiver);
            }
            if (TryGetComponent<IVectorReceiver>(out var target)) {
                target.VectorReceiver = this;
            }
        }

        private void Reset() {
            var receiver = GetComponent<JumpVectorReceiverBase>();
            if (receiver != null && receiver != this) {
                DestroyImmediate(receiver);
            }
            if (TryGetComponent<IJumpVectorReceiver>(out var target)) {
                target.JumpVectorReceiver = this;
            }
        }
    }
}