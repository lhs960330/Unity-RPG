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
        // Ʋ�� ����
        // (ī�޶�������� �ϰԵǸ� ī�޶�� �÷��̾��� �밢�� ������ �����ֱ� ������ �ϴ����� �ö󰥼��� �ְ� �������� ���� ���������ְ� �ȴ�.)
        // Vector3 lookDir = Camera.main.transform.forward;
        // Vector3 rightDir = Camera.main.transform.right;
        // normalized = ����
        // magnitude = ũ��
        // sqrMagnitude �갡 ������ ���� ���ϴ� ��� ��Ȯ���� �� ������(�񱳿����Ҷ� ����ϸ� ���� ��� �񱳴���� �ѹ��� �����ּ�) 
        Vector3 forwardDir = Camera.main.transform.forward;
        forwardDir = new Vector3(forwardDir.x, 0, forwardDir.z).normalized;
        Vector3 rightDir = Camera.main.transform.right;
        rightDir = new Vector3(rightDir.x, 0, rightDir.z).normalized;

        controller.Move(forwardDir * moveDir.z * moveSpeed * Time.deltaTime);
        controller.Move(rightDir * moveDir.x * moveSpeed * Time.deltaTime);

        Vector3 lookDir = forwardDir * moveDir.z + rightDir * moveDir.x;
        // �����̴ٰ� �������� ���ʹ������� �ٶ󺸰�����
        if (lookDir.sqrMagnitude > 0) // ig(lookDir != Vector3.zero) �̰� �� ����(sqrMagnitude���¹� �˷��ַ��� ����)
        {
            // �ٶ󺸴� �������� �����̰�
            Quaternion lookRotation = Quaternion.LookRotation(lookDir);
            // ĳ������ ������ �ٷ� ȸ������ �ʰ� �ϱ����� Lerp�� ���
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