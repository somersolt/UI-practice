using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

[RequireComponent(typeof(TextMeshProUGUI))]
[ExecuteInEditMode]
public class LocalizationTest : MonoBehaviour
{
    public string textId;
    private TextMeshProUGUI text;
    public Languages lang;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();


    }

    private void Start()
    {
        if (!Application.isPlaying)
        {
            OnChangeLanguage(Vars.currentLang);
        }

    }


    public void OnChangeLanguage(Languages lang)
    {
        var stringTable = DataTableManager.Get<StringTable>(DataTableIds.String[(int)lang]);
        text.text = stringTable.Get(textId);

    }
}
