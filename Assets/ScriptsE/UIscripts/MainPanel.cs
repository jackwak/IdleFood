using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    public void LevelTagButton()
    {
        this.gameObject.transform.parent.gameObject.transform.Find("SettingsPanel").gameObject.GetComponent<SettingsPanel>().CloseMenu();
        this.gameObject.SetActive(false);
        this.gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

}
