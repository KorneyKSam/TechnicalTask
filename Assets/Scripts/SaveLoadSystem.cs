using System.IO;
using UnityEngine;
using EventSystem;

public class SaveLoadSystem : MonoBehaviour
{
    private string _settingPath;
    private Settings _settings = new Settings();

    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
       _settingPath = Application.peristentDataPath;
#else
        _settingPath = Application.dataPath;
#endif
        Events.onControlChanged.AddListener(SetControl);
    }

    private void SetControl(TypeOfControl typeOfControl)
    {
        _settings.SelectedControl = typeOfControl;
    }

    public void SaveSettings()
    {
        File.WriteAllText(Path.Combine(_settingPath, "Settings.json"), JsonUtility.ToJson(_settings));
    }

    public Settings LoadSettings()
    {
        return JsonUtility.FromJson<Settings>(File.ReadAllText(_settingPath));
    }

}
