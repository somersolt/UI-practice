using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UnitStatsData))]
public class UnitStatsDataEditor : Editor
{
    private UnitStatsData stats = null;

    private void OnEnable()
    {
        stats = target as UnitStatsData;
    }

    public override void OnInspectorGUI()
    {
        Undo.RecordObject(stats, "���� ���� ����");

        //ID
        stats.id = EditorGUILayout.IntField("ID", stats.id);

        //ü��
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("ü��");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10,false);
        EditorGUILayout.BeginVertical();
        stats.initHP = Mathf.Clamp(EditorGUILayout.IntField("�ִ� ü��", stats.initHP), 0, int.MaxValue);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("���۰� ���", GUILayout.MaxWidth(65));
        stats.useStartHP = EditorGUILayout.Toggle(stats.useStartHP, GUILayout.Width(15));
        if (stats.useStartHP)
            stats.initHPStart = Mathf.Clamp(EditorGUILayout.IntField(stats.initHPStart), 0, stats.initHP);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        //����
        EditorGUILayout.Space(10);
        EditorGUILayout.PrefixLabel("����");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10, false);
        EditorGUILayout.BeginVertical();
        stats.initAttackDamage = EditorGUILayout.IntField("���ݷ�", stats.initAttackDamage);
        stats.initAttackSpeed = Mathf.Clamp(EditorGUILayout.FloatField("���� �ӵ�", stats.initAttackSpeed),0f,float.MaxValue);
        stats.initAttackRange = Mathf.Clamp(EditorGUILayout.FloatField("���� ����", stats.initAttackRange),0f,float.MaxValue);
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        //��Ÿ
        EditorGUILayout.Space(10);
        EditorGUILayout.PrefixLabel("��Ÿ");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.Space(10, false);
        EditorGUILayout.BeginVertical();
        stats.price = Mathf.Clamp(EditorGUILayout.IntField("��ȯ ����", stats.price),0,int.MaxValue);
        stats.initDropGold = Mathf.Clamp(EditorGUILayout.IntField("óġ ���", stats.initDropGold),0,int.MaxValue);
        stats.initDropExp = Mathf.Clamp(EditorGUILayout.IntField("óġ ����ġ", stats.initDropExp),0,int.MaxValue);
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        PrefabUtility.RecordPrefabInstancePropertyModifications(stats);
        EditorUtility.SetDirty(stats);
    }
}
