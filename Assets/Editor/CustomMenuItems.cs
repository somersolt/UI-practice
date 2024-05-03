using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomMenuItems : MonoBehaviour
{
    [MenuItem("Tolls/Set Editor language Korean")]
    private static void SetLangKr()
    {
        var texts = FindObjectsOfType<LocalizationTest>();
        foreach ( var text in texts)
        {
            text.OnChangeLanguage(Languages.Korean);
        }
    }
    [MenuItem("Tolls/Set Editor language English")]
    private static void SetLangEn()
    {
        var texts = FindObjectsOfType<LocalizationTest>();
        foreach (var text in texts)
        {
            text.OnChangeLanguage(Languages.English);
        }
    }
    [MenuItem("Tolls/Set Editor language Japanise")]
    private static void SetLangJp()
    {
        var texts = FindObjectsOfType<LocalizationTest>();
        foreach (var text in texts)
        {
            text.OnChangeLanguage(Languages.Japanese);
        }
    }
}
