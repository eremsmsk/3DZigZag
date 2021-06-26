using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cogaltma : MonoBehaviour
{
    [Header("Objeler")]
    public GameObject slot;
    public List<Items> items;
    public Image image;

    [Header("Para")]
    public int Para;
    void Start()
    {
        MarketiCagir();
        image.sprite = items[0].Resim;
    }

    void MarketiCagir()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject cogalanSlot = Instantiate(slot, transform);
            cogalanSlot.GetComponent<Image>().sprite = items[i].Resim;
            int gecici = 1;
            cogalanSlot.transform.Find("buy").GetComponent<Button>().onClick.AddListener(() => SatinAl(gecici, cogalanSlot));
        }
    }

    public void SatinAl(int id, GameObject gameObject)
    {
        if (Para >= items[id].Fiyat && !items[id].State)
        {
            image.sprite = items[id].Resim;
            gameObject.transform.Find("buy").transform.Find("Text").GetComponent<Text>().text = "OK";
            Para -= items[id].Fiyat;
            items[id].State = true;
        }
        else
        {
            Debug.Log("Yetersiz nakit");
        }
        if (items[id].State)
        {
            image.sprite = items[id].Resim;
        }
    }
}
[System.Serializable]
public class Items
{
    public string Isım;
    public Sprite Resim;
    public int Fiyat;
    public bool State;

    public Items(string ısım, Sprite resim, int fiyat, bool state)
    {
        Isım = ısım;
        Resim = resim;
        Fiyat = fiyat;
        State = state;
    }
}
