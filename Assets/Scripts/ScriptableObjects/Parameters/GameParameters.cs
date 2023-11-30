using System.Collections.Generic;
using UnityEngine;

public abstract class GameParameters : BinarySerializableScriptableObject
{
    public abstract string GetParametersName();
    //public abstract string GetParametersFacção();

    [SerializeField]
    protected List<string> _fieldsToShowInGame;

    public bool ShowsField(string fieldName)
    {
        if (_fieldsToShowInGame == null)
            return false;
        return _fieldsToShowInGame.Contains(fieldName);
    }

    public void ToggleShowField(string fieldName)
    {
        if (_fieldsToShowInGame == null)
            _fieldsToShowInGame = new List<string>();

        if (ShowsField(fieldName))
            _fieldsToShowInGame.Remove(fieldName);
        else
            _fieldsToShowInGame.Add(fieldName);
    }

    public List<string> FieldsToShowInGame => _fieldsToShowInGame;
}
