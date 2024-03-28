using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgrade
{
    public string UpgradeTitle { get; set; }
    public string UpgradeDescription { get; set; }
    public int CurrentMoneyCost { get; set; }
    public int CurrentUpgradeLevel { get; set; }
}
