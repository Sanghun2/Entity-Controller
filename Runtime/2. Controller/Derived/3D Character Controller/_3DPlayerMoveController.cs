using BilliotGames;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterVelocityMediator))]
public class _3DPlayerMoveController : EntityMoveController, IMoveVectorReceiver, IVelocityContributor
{
    public MoveVectorReceiverBase MoveVectorReceiver
    {
        get => moveReceiver;
        set => moveReceiver = value;
    }
    public Vector3 GetVelocityDelta() => horizontalVelocity;

    [Header("[  References  ]")]
    [SerializeField] Transform cameraTransform;
    [SerializeField] MoveVectorReceiverBase moveReceiver;

    private CharacterController characterController;
    private Vector3 horizontalVelocity;


    private void Awake() {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }
    private void Reset() {
        if (moveReceiver == null) {
            var receiver = GetComponent<AxisMoveVectorReceiver>();
            if (receiver == null) {
                moveReceiver = gameObject.AddComponent<AxisMoveVectorReceiver>();
            }
        }
    }

    protected override bool CanMove() {
        return true;
    }
    protected override void ApplyMove() {
        if (moveReceiver == null || cameraTransform == null) {
            horizontalVelocity = Vector3.zero;
            return;
        }

        Vector2 input = moveReceiver.InputVector;
        var camForward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
        var camRight = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;
        horizontalVelocity = (camForward * input.y + camRight * input.x) * moveSpeed;
    }
}