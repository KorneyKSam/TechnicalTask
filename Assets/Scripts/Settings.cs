using System;
using UnityEngine;

[Serializable]
public class Settings
{
    public TypeOfControl SelectedControl { get; set; }
    public KeyCode Left1 { get; set; }
    public KeyCode Left2 { get; set; }
    public KeyCode Right1 { get; set; }
    public KeyCode Right2 { get; set; }
}
