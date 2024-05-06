using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
[ExecuteInEditMode]
public class LocalizationText : MonoBehaviour
{
    public string textId;
    public Languages lang;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {

        if (Application.isPlaying)
        {
            OnChangeLanguage(Vars.currentLang);
        }
        else
        {
            OnChangeLanguage(Vars.editorLang);
        }
    }

    public void OnChangeLanguage(Languages lang)
    {
        var stringTable = DataTableMgr.Get<StringTable>(DataTableIds.String[(int)lang]);
        text.text = stringTable.Get(textId);
    }
}
