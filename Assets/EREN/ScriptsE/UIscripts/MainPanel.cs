using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    public void LevelTagButton()
    {
        this.gameObject.transform.parent.gameObject.transform.Find("SettingsPanel").gameObject.GetComponent<SettingsPanel>().CloseMenu();
        this.gameObject.SetActive(false);
        this.gameObject.transform.parent.gameObject.transform.Find("MapPanel").gameObject.SetActive(true);
        this.gameObject.transform.parent.gameObject.transform.Find("UpgradePanel").gameObject.SetActive(false);
    }

    public void UpgradeButton()
    {
        if (!this.gameObject.transform.parent.gameObject.transform.Find("UpgradePanel").gameObject.activeSelf)
        {
            this.gameObject.transform.parent.gameObject.transform.Find("UpgradePanel").gameObject.SetActive(true);
        }
        else if (this.gameObject.transform.parent.gameObject.transform.Find("UpgradePanel").gameObject.activeSelf)
        {
            this.gameObject.transform.parent.gameObject.transform.Find("UpgradePanel").gameObject.SetActive(false);
        }

    }

}
