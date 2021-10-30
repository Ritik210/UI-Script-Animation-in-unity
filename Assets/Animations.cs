using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour
{
    [Header("PopUp")]
    public bool scale;
    public float scaleFactor;
    public float timeDelay;
    public Image scaleImg;

    [Header("Top Dialog")]
    public bool Top = true;
    public Image topImg;

    [Header("Bottom Dialog")]
    public bool Bottom;
    public Image bottomImg;

    [Header("Left Dialog")]
    public bool Left;
    public Image leftImg;

    [Header("Right Dialog")]
    public bool Right;
    public Image rightImg;

    [Header("Button")]
    public Image buttonImg;
    public float z = 0.0f;
    public bool clockrotate;
    public bool antiClockrotate;
    public float rotationSpeed = 75.0f;
    public float waitTime;

    [Header("Wobble width")]
    public bool scaleX;
    public float scalingFactor;
    public float timeWait;
    public Image wobbleImg;

    [Header("Common for Dialog Images")]
    public float speed = 10f;
    
   // public GameObject img;
    private RectTransform rectTransform;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void Update()
    {
        #region Circular Button
        if (clockrotate == true)
        {
            z -= Time.deltaTime * rotationSpeed;

            if (z < -180.0f)
            {
                clockrotate = false;
                
            }
            if (clockrotate == false)
            {
                StartCoroutine(Delay());
            }
        }
        if(antiClockrotate == true)
        {
            z += Time.deltaTime * rotationSpeed;
            if (z > 0f)
            {
                antiClockrotate = false;

            }
        }
        buttonImg.transform.localRotation = Quaternion.Euler(0, 0, z);
        #endregion

        #region PopUp
        if (scale == true)
        {
         StartCoroutine(wait());
         scale = false;
        }
        #endregion

        #region Dialog animations
        if (Top == true )
        {
          if (topImg.transform.localPosition.y > 0f)
            {
                topImg.transform.Translate(Vector3.down * speed * Time.deltaTime);
                
            }
          if(topImg.transform.localPosition.y <= 0f)
            {
                Top = false;
            }
           
        }
        if (Bottom == true)
        {
            if (bottomImg.transform.localPosition.y < 0f)
            {
                bottomImg.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (bottomImg.transform.localPosition.y >= 0f)
            {
               Bottom = false;
            }
        }
        if (Left == true)
        {
            if (leftImg.transform.localPosition.x < 0f)
            {
                leftImg.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (leftImg.transform.localPosition.x >= 0f)
            {
                Left = false;
            }
        }
        if (Right == true)
        {
            if (rightImg.transform.localPosition.x > 0f)
            {
                rightImg.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (rightImg.transform.localPosition.x <= 0f)
            {
                Right = false;
            }
        }
        #endregion

        #region Wobble
        if (scaleX == true)
        {
            StartCoroutine(Wobble());
            scaleX = false;
        }
        #endregion




    }

    public IEnumerator wait()
    {
        scaleImg.rectTransform.localScale = new Vector3((scaleFactor+ 0.25f), (scaleFactor+0.25f), 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+0.5f, scaleFactor +0.5f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+0.75f, scaleFactor+0.75f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+1f, scaleFactor+1f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+0.5f, scaleFactor+0.5f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+0f, scaleFactor+0f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+0.5f, scaleFactor+0.5f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+1f, scaleFactor+1f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+1.5f, scaleFactor + 1.5f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+2f, scaleFactor+2f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+1.5f, scaleFactor+1.5f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+1f, scaleFactor+1f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+1.5f, scaleFactor+1.5f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+2f, scaleFactor+2f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+2.5f, scaleFactor+2.5f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+1.5f, scaleFactor+1.5f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+0.5f, scaleFactor+0.5f, 1);
        yield return new WaitForSeconds(timeDelay);
        scaleImg.rectTransform.localScale = new Vector3(scaleFactor+0f, scaleFactor+0f, 1);

    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(waitTime);
        antiClockrotate = true;
    }

    public IEnumerator Wobble()
    {
        wobbleImg.rectTransform.localScale = new Vector3((scalingFactor + 0.25f), (scalingFactor + 0.05f), 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 0.5f, scalingFactor + 0.1f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 0.75f, scalingFactor + 0.15f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 1f, scalingFactor + 0.2f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 0.5f, scalingFactor + 0.1f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 0f, scalingFactor + 0f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 0.5f, scalingFactor + 0.1f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 1f, scalingFactor + 0.2f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 1.5f, scalingFactor + 0.25f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 2f, scalingFactor + 0.3f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 1.5f, scalingFactor + 0.25f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 1f, scalingFactor + 0.2f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 0.5f, scalingFactor + 0.1f, 1);
        yield return new WaitForSeconds(timeWait);
        wobbleImg.rectTransform.localScale = new Vector3(scalingFactor + 0f, scalingFactor + 0.0f, 1);


    }

}
