using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public GameObject noAdsButton;
    private bool noAds = false;
    public void RemoveAds()
    {
        noAds = true;
        noAdsButton.SetActive(false);
    }
}
