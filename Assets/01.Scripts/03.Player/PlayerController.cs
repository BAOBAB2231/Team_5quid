using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{

    void FixedUpdate()
    {
        //게임 상태가 Waiting 앞으로 가지 않게
        if (GameManager.Instance.gameState == GameState.Waiting) return;

        Run();
        if (!IsGrounded())
        {
            if (rb.velocity.y < 0)
            {
                isJumping = false;
                anim.Anim_SetJump(isJumping);
                isFalling = true;
                anim.Anim_SetSuddenDrop(isFalling);
            }
        }
        else if (IsGrounded())
        {
            isJumping = false;
            anim.Anim_SetJump(isJumping);
            isFalling = false;
            anim.Anim_SetSuddenDrop(isFalling);
        }
    }

    void Run()
    {
        //부하가 많이 걸리므로 스타트로 
        /*if (rb == null)
        {
            return;
        }*/

        //Vector3 run = rb.velocity;
        //run.z = RunSpeed;

        //rb.velocity = run;

        //transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, Time.deltaTime * runSpeed);

        rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * runSpeed);
    }

    private bool isSideStep;

    public void OnSideStep(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == GameState.Waiting||GameManager.Instance.gameState == GameState.GameOver) return;

        if (context.phase == InputActionPhase.Started && !isSideStep)
        {
            if (context.control.name == "leftArrow")
            {
                if (tf.position.x <= -maxDistance)
                {
                    return;
                }

                anim.Anim_TriggerLeftsideStep();
                sfx.PlayClip(SFX.SideStep);
                IEnumerator sideStep = LerpSideSetp(-sideStepDistance);
                StartCoroutine(sideStep);
                /*tf.position -= new Vector3(sideStepDistance, 0, 0);*/
            }
            else if (context.control.name == "rightArrow")
            {
                if (tf.position.x >= maxDistance)
                {
                    return;
                }

                anim.Anim_TriggerRightsideStep();
                sfx.PlayClip(SFX.SideStep);
                IEnumerator sideStep = LerpSideSetp(+sideStepDistance);
                StartCoroutine(sideStep);
                /*tf.position += new Vector3(sideStepDistance, 0, 0);*/
            }
        }
    }

    private IEnumerator LerpSideSetp(float sideStepDistance)
    {
        isSideStep = true;
        float elapsed = 0f;

        Vector3 start = transform.position;
        Vector3 end = start + new Vector3(sideStepDistance, start.y * stepDuration, runSpeed * stepDuration);

        while (elapsed < stepDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / stepDuration;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }

        transform.position = end; // 최종 위치 확정
        isSideStep = false;
    }


    bool isJumping = false;
    bool isFalling = false;

    public void OnJump(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == GameState.Waiting||GameManager.Instance.gameState == GameState.GameOver) return;

        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            isJumping = true;
            sfx.PlayClip(SFX.Jump);
            anim.Anim_SetJump(isJumping);
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.5f) + (transform.up * 0.1f), Vector3.down * 2f),
            new Ray(transform.position + (-transform.forward * 0.5f) + (transform.up * 0.1f), Vector3.down * 2f),
            new Ray(transform.position + (transform.right * 0.5f) + (transform.up * 0.1f), Vector3.down * 2f),
            new Ray(transform.position + (-transform.right * 0.5f) + (transform.up * 0.1f), Vector3.down * 2f)
        };
        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.5f) + (transform.up * 0.05f), Vector3.down * 2f),
            new Ray(transform.position + (-transform.forward * 0.5f) + (transform.up * 0.05f), Vector3.down * 2f),
            new Ray(transform.position + (transform.right * 0.5f) + (transform.up * 0.05f), Vector3.down * 2f),
            new Ray(transform.position + (-transform.right * 0.5f) + (transform.up * 0.05f), Vector3.down * 2f)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            Gizmos.DrawLine(rays[i].origin, rays[i].origin + rays[i].direction * 0.1f);
        }
    }

    bool isCrouching = false;

    public void OnCrouchAndSuddenDrop(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.gameState == GameState.Waiting) return;

        if (context.phase == InputActionPhase.Started && !isCrouching && tf.localScale.y == 1)
        {
            Vector3 scale = tf.localScale;
            isCrouching = true;
            anim.Anim_SetCrouch(isCrouching);
            scale.y /= 2;
            tf.localScale = scale;
        }

        if (context.phase == InputActionPhase.Canceled && isCrouching && tf.localScale.y == 0.5f)
        {
            Vector3 scale = tf.localScale;
            isCrouching = false;
            anim.Anim_SetCrouch(isCrouching);
            scale.y *= 2;
            tf.localScale = scale;
        }

        if (!IsGrounded())
        {
            if (context.phase == InputActionPhase.Started)
            {
                /*Vector3 currentPosition = tf.position;*/

                /*currentPosition.y = playerPivotY;
                tf.position = currentPosition;*/
                sfx.PlayClip(SFX.SideStep);
                StartCoroutine(MassUp());
            }
        }
    }


    IEnumerator MassUp() //급강하용 코루틴 
    {
        rb.velocity = Vector3.down * 40;
        yield return new WaitUntil(() => tf.localScale.y < 0.5f);
        rb.velocity = Vector3.zero;
    }
}