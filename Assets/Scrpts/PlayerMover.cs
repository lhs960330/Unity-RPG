using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Animator animator;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    private float ySpeed;
    private Vector3 moveDir;



    private void Update()
    {
        Move();
        ySpeed += Physics.gravity.y * Time.deltaTime;
        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void Move()
    {
        // 틀린 예시
        // (카메라기준으로 하게되면 카메라는 플레이어의 대각선 방향을 보고있기 때문에 하늘위로 올라갈수도 있고 땅쪽으로 보내 버릴수도있게 된다.)
        // Vector3 lookDir = Camera.main.transform.forward;
        // Vector3 rightDir = Camera.main.transform.right;
        // normalized = 벡터
        // magnitude = 크기
        // sqrMagnitude 얘가 연산을 많이 안하는 대신 정확성이 좀 떨어짐(비교연산할때 사용하면 좋음 대신 비교대상을 한번더 곱해주셈) 
        Vector3 forwardDir = Camera.main.transform.forward;
        forwardDir = new Vector3(forwardDir.x, 0, forwardDir.z).normalized;
        Vector3 rightDir = Camera.main.transform.right;
        rightDir = new Vector3(rightDir.x, 0, rightDir.z).normalized;

        controller.Move(forwardDir * moveDir.z * moveSpeed * Time.deltaTime);
        controller.Move(rightDir * moveDir.x * moveSpeed * Time.deltaTime);

        Vector3 lookDir = forwardDir * moveDir.z + rightDir * moveDir.x;
        // 움직이다가 놓았을때 그쪽방향으로 바라보게해줌
        if (lookDir.sqrMagnitude > 0) // ig(lookDir != Vector3.zero) 이게 더 빠름(sqrMagnitude쓰는법 알려주려고 쓰심)
        {
            // 바라보는 방향으로 움직이게
            Quaternion lookRotation = Quaternion.LookRotation(lookDir);
            // 캐릭터의 방향이 바로 회전하지 않게 하기위해 Lerp를 사용
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10);
        }
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            ySpeed = jumpSpeed;
            controller.Move(Vector3.up * jumpSpeed * Time.deltaTime);
        }
    }
    private void OnJump(InputValue value)
    {
        Jump();
    }
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDir.x = input.x;
        moveDir.z = input.y;

        animator.SetFloat("MoveSpeed", moveDir.magnitude);
    }
}