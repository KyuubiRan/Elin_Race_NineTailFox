using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace NineTailFox.I18n;

public static class LocalizationManager
{
    private static readonly HashSet<TranslatedText> Texts = [];
    private static readonly JObject LangJson;
    private static string _currentLang = EClass.core.config.lang.ToLowerInvariant();

    static LocalizationManager()
    {
        try
        {
            var json = ModRes.Language;
            var s = Encoding.UTF8.GetString(json, 0, json.Length);
            LangJson = JObject.Parse(s);
        }
        catch (Exception e)
        {
            Plugin.LogError("Failed to load localization data: {0}", e);
        }
    }

    private static void ApplyText(TranslatedText text, string lang)
    {
        var key = text.Key;

        var texts = LangJson[key];
        if (texts == null)
            return;

        var jp = texts["jp"];
        if (jp != null)
            text.Value_JP = jp.ToString();
        
        var t = texts[lang];
        if (t == null)
        {
            text.Value = text.Value_JP;
            return;
        }

        text.Value = t.ToString();
    }

    public static void AddText(TranslatedText text)
    {
        Texts.Add(text);
        ApplyText(text, _currentLang);
    }

    public static void RemoveText(TranslatedText text)
    {
        Texts.Remove(text);
    }

    public static void NotifyChanged(string langCode)
    {
        _currentLang = langCode.ToLowerInvariant();

        foreach (var v in Texts)
        {
            ApplyText(v, _currentLang);
        }
    }
}