using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItem : MonoBehaviour
{
    /// <summary>
    /// ���� �������� ȿ���� �÷��̾�� ����
    /// </summary>
    /// <param name="player">���� ��ȭ �� ��Ʈ�� ���� ȿ���� ������ �÷��̾�</param>
    /// <param name="point">���� ����, ������ ����Ʈ�� ������ ������Ʈ</param>
    /// <param name="data">������ ������ ������</param>
    //public static void Apply(PlayerController player, ItemData data, Point point)
    //{
    //    // �Һ��� �������� �ƴϰų�, �Һ� ȿ�� ������ ������ ó�� �ߴ�
    //    if (data.type != ItemType.Buff || data.Buff == null)
    //        return;

    //    // �� ���� ȿ���� ��ȸ�ϸ鼭 ����
    //    foreach (var buff in data.Buff)
    //    {
    //        switch (buff.type)
    //        {
    //            case BuffType.JumpBoost:
    //                // ���� ��ȭ ȿ�� ���� (���� �ð� ���)
    //                player?.ApplyJumpBoost(buff.value);
    //                break;

    //            case BuffType.ScoringUp:
    //                // ���ھ� ���� ȿ�� ����
    //                point?.ApplyScoringUp(buff.value);
    //                break;

    //            case BuffType.CoinVolumeUp:
    //                // ���� ���� ȿ�� ����
    //                point?.ApplyCoinVolumeUp(buff.value);
    //                break;
    //        }
    //    }
    //}
}
