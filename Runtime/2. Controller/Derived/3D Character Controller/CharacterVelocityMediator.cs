using System.Collections.Generic;
using UnityEngine;

public interface IVelocityContributor
{
    Vector3 GetVelocityDelta();
}

public class CharacterVelocityMediator : MonoBehaviour
{
    private CharacterController characterController;
    private readonly List<IVelocityContributor> contributors = new();

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        // 같은 GameObject에서 자동 수집
        GetComponents(contributors);
    }

    private void LateUpdate() // 모든 컨트롤러 Update 이후에 합산
    {
        Vector3 totalVelocity = Vector3.zero;
        foreach (var c in contributors)
            totalVelocity += c.GetVelocityDelta();

        characterController.Move(totalVelocity * Time.deltaTime);
    }
}
