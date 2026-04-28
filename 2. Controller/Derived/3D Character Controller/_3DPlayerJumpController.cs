using BilliotGames;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterVelocityMediator))]
public class _3DPlayerJumpController : EntityJumpController, IJumpVectorReceiver, IVelocityContributor
{
    public JumpVectorReceiverBase JumpVectorReceiver
    {
        get => jumpReceiver;
        set => jumpReceiver = value;
    }

    [SerializeField] JumpVectorReceiverBase jumpReceiver;

    private CharacterController characterController;
    private float verticalVelocity;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }
    private void Reset() {
        if (jumpReceiver == null) {
            var receiver = GetComponent<AxisJumpVectorReceiver>();
            if (receiver == null) {
                jumpReceiver = gameObject.AddComponent<AxisJumpVectorReceiver>();
            }
        }
    }

    public Vector3 GetVelocityDelta() => new Vector3(0f, verticalVelocity, 0f);

    protected override bool CanJump() => jumpReceiver != null;

    protected override void ApplyJump() {
        // 중력 누적
        if (characterController.isGrounded && verticalVelocity < 0f)
            verticalVelocity = -2f;
        else
            verticalVelocity += Physics.gravity.y * Time.deltaTime;

        // 점프 입력 감지
        Vector2 jumpDir = jumpReceiver.InputVector;
        if (characterController.isGrounded && jumpDir != Vector2.zero)
            verticalVelocity = Mathf.Sqrt(jumpPower * -2f * Physics.gravity.y);
    }
}