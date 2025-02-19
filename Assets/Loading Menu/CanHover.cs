﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CanHover : MonoBehaviour
{
    public bool bol;
    private int transformchildindex = -1;
    private float Rotate = 0;
    private bool betweennegativeandpostive = true;
    public void Start()
    {
        if (gameObject.transform.parent.name != "Menu")
        {
            transformchildindex = gameObject.transform.GetSiblingIndex();
            GameObject.Find("SettingsPanel").transform.GetChild(0).gameObject.SetActive(true);

        }

        if (EventSystem.current.firstSelectedGameObject == gameObject)
        {

            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
    public void hover()
    {
        bol = true;
    }
    
    public void clickedon()
    {
        EventSystem.current.firstSelectedGameObject = gameObject;
        //if (EventSystem.current.alreadySelecting != gameObject && gameObject.CompareTag("Select"))
        //{
        //    EventSystem.current.SetSelectedGameObject(gameObject);
        //}
    }
    public void exit()
    {
        bol = false;
    }
    public void Update()
    {

        if (gameObject.transform.parent.name == "Menu")
        {
            // Rotate between negative and postive rotation for epic effect
            if (Rotate < 5 && betweennegativeandpostive == true)
            {
                Rotate += 3f * Time.deltaTime;

            }
            else
            {
                betweennegativeandpostive = false;
                Rotate -= 3f * Time.deltaTime;
            }
            if (Rotate < -5)
            {
                betweennegativeandpostive = true;
            }
            Quaternion rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Rotate);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, 2 * Time.deltaTime);
            // when hover over the text in main menu -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (bol == true && gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta.x < 159f)
            {
                Vector2 widthchange = new Vector2(160, gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta.y);
                gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = Vector2.Lerp(gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta, widthchange, 3.5f * Time.deltaTime);

                Color col = gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().color;
                col.a = Mathf.Lerp(col.a, 0.5f, 3.5f * Time.deltaTime);
                gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().color = col;
            }
            else if (bol == false && gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta.x > 0.1f)
            {
                Vector2 widthchange = new Vector2(0, gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta.y);
                gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = Vector2.Lerp(gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta, widthchange, 3.5f * Time.deltaTime);

                Color col = gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().color;
                col.a = Mathf.Lerp(col.a, 0, 3.5f * Time.deltaTime);
                gameObject.GetComponent<Image>().transform.GetChild(0).GetComponent<Image>().color = col;
            }
        }
        else
        {
            if (EventSystem.current.firstSelectedGameObject == gameObject)
            {

                GameObject.Find("SettingsPanel").transform.GetChild(transformchildindex).gameObject.SetActive(true);
                Vector2 widthchange = new Vector2(1.625655f, 1.0029804f);
                gameObject.GetComponent<Image>().rectTransform.localScale = Vector2.Lerp(gameObject.GetComponent<Image>().rectTransform.localScale, widthchange, 3f * Time.deltaTime);

            }
            else
            {

                GameObject.Find("SettingsPanel").transform.GetChild(transformchildindex).gameObject.SetActive(false);

            }

            if (bol == true && gameObject.GetComponent<Image>().rectTransform.localScale.x < 1.3f && EventSystem.current.firstSelectedGameObject != gameObject)
            {
                Vector2 widthchange = new Vector2(1.425655f, 0.9029804f);
                gameObject.GetComponent<Image>().rectTransform.localScale = Vector2.Lerp(gameObject.GetComponent<Image>().rectTransform.localScale, widthchange, 3f * Time.deltaTime);
            }
            else if (bol == false && gameObject.GetComponent<Image>().rectTransform.localScale.x > 1.2f && EventSystem.current.firstSelectedGameObject != gameObject)
            {
                Vector2 widthchange = new Vector2(1.188046f, 0.7524836f);
                gameObject.GetComponent<Image>().rectTransform.localScale = Vector2.Lerp(gameObject.GetComponent<Image>().rectTransform.localScale, widthchange, 3.5f * Time.deltaTime);
            }


        }
    }
}
