using System;

namespace NineTailFox.I18n;

public class TranslatedText
{
    public string Key { get; private set; }

    private Action<string> _onChanged;

    public string Value
    {
        get;
        set
        {
            field = value;
            _onChanged?.Invoke(value);
        }
    } = "";

    public string Value_JP { get; set; } = "";

    public TranslatedText(string key, Action<string> onChanged)
    {
        Key = key;
        _onChanged = onChanged;
        LocalizationManager.AddText(this);
    }

    ~TranslatedText()
    {
        LocalizationManager.RemoveText(this);
    }
}