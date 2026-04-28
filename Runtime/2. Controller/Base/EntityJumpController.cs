using UnityEngine;

public abstract class EntityJumpController : MonoBehaviour
{
#pragma warning disable CS0414
    [SerializeField] protected float jumpPower = 5f;
#pragma warning restore CS0414

    protected virtual bool CanJump() => true;
    protected abstract void ApplyJump();


    private void Update() {
        if (CanJump()) {
            ApplyJump();
        }
    }
}
