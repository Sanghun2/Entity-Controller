using UnityEngine;

namespace BilliotGames
{
    public class JoystickMoveVectorReceiver : MoveVectorReceiverBase
    {
        [SerializeField] JoystickBase joystickBase;

        public override bool TryFindInput() {
            if (joystickBase == null) {
                joystickBase = GameObject.FindAnyObjectByType<JoystickBase>();
            }

            return joystickBase != null;
        }
        protected override void RegisterReceiveEvent() {
            joystickBase.OnDirectionChanged -= RecieveNormalizedVector;
            joystickBase.OnDirectionChanged += RecieveNormalizedVector;
        }
        protected override void UnregisterReceiveEvent() {
            joystickBase.OnDirectionChanged -= RecieveNormalizedVector;
        }

        public override bool IsInputConnected() {
            return joystickBase != null;
        }
    }
}