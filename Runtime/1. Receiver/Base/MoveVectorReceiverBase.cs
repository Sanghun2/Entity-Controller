using UnityEngine;

namespace BilliotGames
{
    public abstract class MoveVectorReceiverBase : VectorReceiverBase
    {
        private void Awake() {
            var receiver = GetComponent<MoveVectorReceiverBase>();
            if (receiver != null && receiver != this) {
                Destroy(receiver);
            }
            if (TryGetComponent<IVectorReceiver>(out var target)) {
                target.VectorReceiver = this;
            }
        }

        private void Reset() {
            var receiver = GetComponent<MoveVectorReceiverBase>();
            if (receiver != null && receiver != this) {
                DestroyImmediate(receiver);
            }
            if (TryGetComponent<IMoveVectorReceiver>(out var target)) {
                target.MoveVectorReceiver = this;
            }
        }
    }
}