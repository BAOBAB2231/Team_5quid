using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �������� ������ �����ϴ� ������
public enum ItemType
{
    Effact,      // ȿ�� ������
    Buff,        // ���� ������
    Resource     // �ڿ� ������ (����)
}

// ȿ�� �������� Ÿ�� ����
public enum EffactType
{
    Magnet,      // �ڼ�
    Power,       // �Ŀ� -> ������Ʈ�� �ı��ϸ鼭 ����
    SuperJump    // ���� ���� -> ����� �ٸ� ������ �̵��ؼ� ���ʽ� ���ΰ� ������ ȹ��
}

// ���� �������� Ÿ�� ����
public enum BuffType
{
    ScoringUp,   // ���� ���� ��
    JumpBoost,   // ���� �ν�Ʈ
    CoinVolumeUp // ���� ȹ�� �� 
}

// ���� �������� �� ���� (ȿ�� ���� �� ��ġ)
[Serializable]
public class ItemDataBuff
{
    public BuffType type;  // ���� ����
    public float value;    // ���� �ð�
}

/// <summary>
/// �κ��丮 �������� ������ ���� ScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;         // ������ �̸�
    public string description;         // ������ ����
    public ItemType type;              // ������ �з�

    [Header("Stacking")]
    public bool canStack;              // ���� �� ���� �� �ִ��� ����
    public int maxStackAmount;         // �ִ� ���� ��

    [Header("Consumable")]
    public ItemDataBuff[] Buff;        // ���� ������ ȿ����
}
