using UnityEngine;

public class MetaProgressManager : MonoBehaviour
{
    public static MetaProgressManager Instance;

    [Header("Currency")]
    public int currency = 0;

    [Header("Update Costs")]
    public int dashCost = 50;
    public int speedBoostCost = 100;
    public int biggerStartCost = 150;

    [Header("Upgrade Owned Status")]
    public bool hasDash = false;
    public bool hasSpeedBoost = false;
    public bool hasBiggerStart = false;

    void Awake()
    {
        Instance = this;
        LoadProgress();
    }

    void LoadProgress()
    {
        string json = PlayerPrefs.GetString("MetaProgress", "");

        if (string.IsNullOrEmpty(json))
        {
            currency = 0;
            hasDash = false;
            hasSpeedBoost = false;
            hasBiggerStart = false;
        }
        else
        {
            MetaProgressData data = JsonUtility.FromJson<MetaProgressData>(json);
            currency = data.currency;
            hasDash = data.hasDash;
            hasSpeedBoost = data.hasSpeedBoost;
            hasBiggerStart = data.hasBiggerStart;
        }
    }

    public void SaveProgress()
    {
        MetaProgressData data = new MetaProgressData();
        data.currency = currency;
        data.hasDash = hasDash;
        data.hasSpeedBoost = hasSpeedBoost;
        data.hasBiggerStart = hasBiggerStart;

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("MetaProgress", json);
        PlayerPrefs.Save();
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        SaveProgress();
    }

    public bool PurchaseDash()
    {
        if (hasDash) return false;
        if (currency < dashCost) return false;

        currency -= dashCost;
        hasDash = true;
        SaveProgress();
        return true;

    }

    public bool PurchaseSpeedBoost()
    {
        if (hasSpeedBoost) return false;
        if (currency < speedBoostCost) return false;

        currency -= speedBoostCost;
        hasSpeedBoost = true;
        SaveProgress();
        return true;
    }

    public bool PurchaseBiggerStart()
    {
        if (hasBiggerStart) return false;
        if (currency < biggerStartCost) return false;

        currency -= biggerStartCost;
        hasBiggerStart = true;
        SaveProgress();
        return true;
    }
    [System.Serializable]
    public class MetaProgressData
    {
        public int currency;
        public bool hasDash;
        public bool hasSpeedBoost;
        public bool hasBiggerStart;
    }
}