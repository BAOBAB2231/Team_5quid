using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ ������ ��� ���� ƨ�ܳ���, �ڽ��� �����Ǵ� ������
/// </summary>
public class SuperJump : MonoBehaviour
{
    [Header("���� ����")]
    [Tooltip("�÷��̾ ���� ƨ�ܳ� ��")]
    public float jumpForce = 5f;

    /// <summary>
    /// �÷��̾ �浹 �� �������� �ְ� ���� ���� �������� ����
    /// </summary>
    /// <param name="collision">�浹 ����</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("�������� �۵�!");

                // ������ ����
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

                // ������ ���� (0.05�� �� ���ŷ� ó�� ������ Ȯ��)
                Destroy(gameObject, 0.05f);
            }
        }
    }
}
