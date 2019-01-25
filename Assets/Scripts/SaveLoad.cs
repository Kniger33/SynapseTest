using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    private PictureControl pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Main Image").GetComponent<PictureControl>();
        LoadInfo();
    }

    // Update is called once per frame
    void Update()
    {   
       
    }       

    private void OnApplicationPause()
    {
        SaveInfo();
    }

    public void SaveInfo()
    {
        PlayerPrefs.SetInt("CountOfToLeft", pc.CountOfToLeft);
        PlayerPrefs.SetInt("CountOfToRight", pc.CountOfToRight);
        PlayerPrefs.SetString("LastSpriteAndText", pc.strings[pc.RandomSprite]);

        PlayerPrefs.Save();
    }

    public void LoadInfo()
    {
        int loadRandomSprite = 0;
        for(int i = 0; i < pc.strings.Count; i++)
        {
            if (pc.strings[i] == PlayerPrefs.GetString("LastSpriteAndText"))
            {
                loadRandomSprite = i;
            }
        }
        
        pc.CountOfToLeft = PlayerPrefs.GetInt("CountOfToLeft");
        pc.CountOfToRight = PlayerPrefs.GetInt("CountOfToRight");
        pc.RandomSprite = loadRandomSprite;

        pc.mainImage.GetComponent<Image>().sprite = pc.mySprites[pc.RandomSprite];
        pc.someText.text = pc.strings[pc.RandomSprite];
        pc.toLeftText.text = pc.CountOfToLeft.ToString();
        pc.toRightText.text = pc.CountOfToRight.ToString();
    }
}
