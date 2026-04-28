using System;
using UnityEngine;

namespace BilliotGames
{
    public interface IVectorReceiver
    {
        public VectorReceiverBase VectorReceiver { get; set; }
    }
    public interface IMoveVectorReceiver {
        public MoveVectorReceiverBase MoveVectorReceiver { get; set; }
    }
    public interface IJumpVectorReceiver {
        public JumpVectorReceiverBase JumpVectorReceiver { get; set; }
    }

    public abstract class VectorReceiverBase : MonoBehaviour
    {
        public Vector2 InputVector => inputVector;

        protected Vector2 inputVector;


        protected void RecieveNormalizedVector(Vector2 inputVector) {
            this.inputVector = inputVector;
        }
        protected abstract void RegisterReceiveEvent();
        protected abstract void UnregisterReceiveEvent();
        public abstract bool TryFindInput();
        public abstract bool IsInputConnected();

        private void OnEnable() {
            if (TryFindInput()) {
                RegisterReceiveEvent();
            }
        }
        private void OnDisable() {
            if (IsInputConnected()) {
                UnregisterReceiveEvent();
            }
        }
    }
}