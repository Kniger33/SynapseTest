using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.IO;

public class PictureChange : MonoBehaviour
{
    public List<Sprite> mySprites;
    public List<string> strings = new List<string>();

    int countOfToLeft = 0;
    int countOfToRight = 0;

    public Image mainImage;
    public Text someText;
    public Text toLeftText;
    public Text toRightText;

    private void Start()
    {
        setMySprites();
        setStrings();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)
            && Input.mousePosition.x >= mainImage.transform.position.x - mainImage.rectTransform.sizeDelta.x / 2
            && Input.mousePosition.y >= mainImage.transform.position.y - mainImage.rectTransform.sizeDelta.y / 2
            && Input.mousePosition.x <= mainImage.transform.position.x + mainImage.rectTransform.sizeDelta.x / 2
            && Input.mousePosition.y <= mainImage.transform.position.y + mainImage.rectTransform.sizeDelta.y / 2)
        {
            int a, b;
            a = Random.Range(0, mySprites.Count);
            mainImage.GetComponent<Image>().sprite = mySprites[a];
            mySprites.RemoveAt(a);

            b = Random.Range(0, strings.Count);
            someText.text = strings[b];
            strings.RemoveAt(b);
        }

        if(mySprites.Count == 0 && strings.Count == 0)
        {
            setMySprites();
            setStrings();
        }

    }

    public void setMySprites()
    {
        Object[] objs;
        objs = Resources.LoadAll("Sprites/", typeof(Sprite));
        for(int i = 0; i < objs.Length; i++)
        {
            mySprites.Add(objs[i] as Sprite);
        }
    }

    public void setStrings()
    {
        for(int i = 0; i < 7; i++)
        {
            strings.Add("Some text " + (i + 1));
        }
        
    }

}
