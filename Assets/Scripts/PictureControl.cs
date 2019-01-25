using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.IO;
using UnityEngine.EventSystems;

public class PictureControl : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public List<Sprite> mySprites;
    public List<string> strings = new List<string>();

    public int CountOfToLeft { get; set; }
    public int CountOfToRight { get; set; }

    public Image mainImage;     
    public Text someText;
    public Text toLeftText;
    public Text toRightText;

    private Vector3 firstPos;           //Начальная позиция картинки

    public int RandomSprite { get; set; }

    private void Awake()
    {
        SetMySprites();
        SetStrings();

        CountOfToLeft = 0;
        CountOfToRight = 0;

        RandomSprite = Random.Range(0, mySprites.Count);
        mainImage.GetComponent<Image>().sprite = mySprites[RandomSprite];       
        someText.text = strings[RandomSprite];

        firstPos = mainImage.transform.position;       
    }

    private void Update()
    {
        if (transform.position.x - (mainImage.rectTransform.sizeDelta.x / 2) >= Screen.width)
        {
            ChangePictureAndText();
            CountOfToRight++;
            toRightText.text = CountOfToRight.ToString();
        }
        else if (transform.position.x + (mainImage.rectTransform.sizeDelta.x / 2) <= 0)
        {            
            ChangePictureAndText();
            CountOfToLeft++;
            toLeftText.text = CountOfToLeft.ToString();
        }
    }

    public void SetMySprites()
    {
        Object[] objs;
        objs = Resources.LoadAll("Sprites/", typeof(Sprite));
        for(int i = 0; i < objs.Length; i++)
        {
            mySprites.Add(objs[i] as Sprite);
        }
    }
   
    public void SetStrings()
    {
        for(int i = 0; i < 7; i++)
        {
            strings.Add(mySprites[i].name);
        }        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(eventData.pointerCurrentRaycast.screenPosition.x, transform.position.y, transform.position.z);        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.position.x >= Screen.width - mainImage.rectTransform.sizeDelta.x / 2.5)
        {           
            StartCoroutine(Move_Routine(this.transform, transform.position, new Vector3(firstPos.x * 3f, firstPos.y, firstPos.z)));
        }
        else if (mainImage.transform.position.x < mainImage.rectTransform.sizeDelta.x / 2.5)
        {
            StartCoroutine(Move_Routine(this.transform, transform.position, new Vector3(-(firstPos.x * 3f), firstPos.y, firstPos.z)));           
        }
        else
        {            
            StartCoroutine(Move_Routine(this.transform, transform.position, firstPos));
        }        
    }

    private IEnumerator Move_Routine(Transform transform, Vector3 from, Vector3 to)
    {
        float t = 0f;
        while(t < 1f)
        {
            t += 2 * Time.deltaTime;
            transform.position = Vector3.Lerp(from, to, Mathf.SmoothStep(0f, 1f, t));         
            yield return null;
        }        
    }

    //Замена картинки и текста на случайные новые
    public void ChangePictureAndText()
    {
        mySprites.RemoveAt(RandomSprite);
        strings.RemoveAt(RandomSprite);

        transform.position = firstPos;

        if (mySprites.Count == 0 && strings.Count == 0)
        {            
            SetMySprites();
            SetStrings();           
        }

        RandomSprite = Random.Range(0, mySprites.Count);
        mainImage.GetComponent<Image>().sprite = mySprites[RandomSprite];        
        someText.text = strings[RandomSprite];

        StopAllCoroutines();
    }        
}
