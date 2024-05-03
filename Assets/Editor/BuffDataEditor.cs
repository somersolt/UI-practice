using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BuffData))]
public class BuffDataEditor : Editor
{
    private BuffData buff = null;

    private void OnEnable()
    {
        buff = target as BuffData;
    }

    public override void OnInspectorGUI()
    {
        Undo.RecordObject(buff, "���� ���� ����");

        //ID
        buff.id = EditorGUILayout.IntField("ID", buff.id);

        //���� ��Ģ
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("���� ��Ģ");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10, false);
        EditorGUILayout.BeginVertical();
        buff.duration = Mathf.Clamp(EditorGUILayout.FloatField("���� �ð�", buff.duration), 0f, float.MaxValue);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("����� �� ���ӽð� �ʱ�ȭ",GUILayout.MaxWidth(145));
        EditorGUILayout.Space(0);
        buff.doResetDurationOnApply = EditorGUILayout.Toggle(buff.doResetDurationOnApply,GUILayout.Width(15));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        //ü��
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("ü��");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10, false);
        EditorGUILayout.BeginVertical();
        buff.hp = EditorGUILayout.IntField("�ִ� ü��", buff.hp);
        buff.hp_P = EditorGUILayout.FloatField("�ִ� ü��%", buff.hp_P);
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        //����
        EditorGUILayout.Space(10);
        EditorGUILayout.PrefixLabel("����");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10, false);
        EditorGUILayout.BeginVertical();
        buff.attackDamage = EditorGUILayout.IntField("���ݷ�", buff.attackDamage);
        buff.attackDamage_P = EditorGUILayout.FloatField("���ݷ�%", buff.attackDamage_P);
        buff.attackRange = EditorGUILayout.FloatField("���� �ӵ�", buff.attackRange);
        buff.attackRange_P = EditorGUILayout.FloatField("���� �ӵ�%", buff.attackRange_P);
        buff.attackSpeed = EditorGUILayout.FloatField("���� ����", buff.attackSpeed);
        buff.attackSpeed_P = EditorGUILayout.FloatField("���� ����%", buff.attackSpeed_P);
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        //��Ÿ
        EditorGUILayout.Space(10);
        EditorGUILayout.PrefixLabel("��Ÿ");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10, false);
        EditorGUILayout.BeginVertical();
        buff.dropGold = EditorGUILayout.IntField("óġ ���", buff.dropGold);
        buff.dropGold_P = EditorGUILayout.FloatField("óġ ���%", buff.dropGold_P);
        buff.dropExp = EditorGUILayout.IntField("óġ ����ġ", buff.dropExp);
        buff.dropExp_P = EditorGUILayout.FloatField("óġ ����ġ%", buff.dropExp_P);
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        PrefabUtility.RecordPrefabInstancePropertyModifications(buff);
        EditorUtility.SetDirty(buff);
    }
}
