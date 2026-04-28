using UnityEngine;


public abstract class EntityMoveController : MonoBehaviour
{
#pragma warning disable CS0414
    [SerializeField] protected float moveSpeed = 5f;
#pragma warning restore CS0414

    protected virtual bool CanMove() => true;
    protected abstract void ApplyMove();


    private void Update() {
        if (CanMove()) {
            ApplyMove();
        }
    }

    //protected void ApplyGravity() {
    //    _isGrounded = _controller.isGrounded;
    //    if (_isGrounded && _velocity.y < 0f)
    //        _velocity.y = -2f;
    //}
    //protected void MoveByWorldDir(Vector3 worldDir) {
    //    if (worldDir.sqrMagnitude < 0.01f) return;

    //    _controller.Move(worldDir * moveSpeed * Time.deltaTime);

    //    transform.rotation = Quaternion.Slerp(
    //        transform.rotation,
    //        Quaternion.LookRotation(worldDir),
    //        Time.deltaTime * 10f
    //    );
    //}
}
