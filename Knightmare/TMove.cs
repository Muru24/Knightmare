using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMove : MonoBehaviour
{

    public float speed;      // 캐릭터 이동 속도
    public float jumpSpeed;  // 캐릭터 점프 힘
    public float gravity;    // 캐릭터에게 적용할 중력

    private CharacterController controller; // 캐릭터 컨트롤러
    private Vector3 MoveDir;                // 캐릭터 이동 방향

    void Start()
    {
        speed = 6.0f;
        jumpSpeed = 8.0f;
        gravity = 20.0f;

        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 땅에 있을 때 이동과 점프 입력 처리
        if (controller.isGrounded)
        {
            // 이동 방향 설정
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // 로컬 방향을 월드 방향으로 변환
            MoveDir = transform.TransformDirection(MoveDir);

            // 이동 속도 적용
            MoveDir *= speed;

            // 점프
            if (Input.GetButton("Jump"))
                MoveDir.y = jumpSpeed;

        }

        // 중력 적용
        MoveDir.y -= gravity * Time.deltaTime;

        // 캐릭터 이동
        controller.Move(MoveDir * Time.deltaTime);
    }
}
