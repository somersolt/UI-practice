using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CumstomMenuItems
{
    private static void UpdateLanguage()
    {
        var texts = Component.FindObjectsOfType<LocalizationText>();
        foreach (var text in texts)
        {
            text.OnChangeLanguage(Vars.editorLang);
            EditorUtility.SetDirty(text);
        }
    }

    [MenuItem("Tools/Set Editor Language Korean", priority = 1)]

    private static void SetLangKr()
    {
        Vars.editorLang = Languages.Korean;
        UpdateLanguage();
    }

    [MenuItem("Tools/Set Editor Language English", priority = 2)]
    private static void SetLangEn()
    {
        Vars.editorLang = Languages.English;
        UpdateLanguage();
    }

    [MenuItem("Tools/Set Editor Language Japanese", priority = 3)]
    private static void SetLangJp()
    {
        Vars.editorLang = Languages.Japanese;
        UpdateLanguage();
    }
}
