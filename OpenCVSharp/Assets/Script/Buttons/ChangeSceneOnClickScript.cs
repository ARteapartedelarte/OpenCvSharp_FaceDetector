﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClickScript : MonoBehaviour
{
   
    public string _nextScene = "";
    public Sprite sprite;
    protected Sprite spritesave;
    protected SpriteRenderer spriterender;
    protected FadingScene fadingScene;
    void Start()
    {
        fadingScene = GameObject.Find("menu").GetComponent<FadingScene>();
        spriterender = GetComponent<SpriteRenderer>();
        if (_nextScene.Equals(""))
        {
            _nextScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        }
        //Debug.Log("yosh");
    }
    protected void OnMouseEnter()
    {

        if (sprite != null)
        {
            spritesave = spriterender.sprite;
            spriterender.sprite = sprite;
        }
        else
        {
            
        }
        //SoundEffectsHelper.Instance.MakeButtonSelectSound();
    }
    protected void OnMouseOver()
    {
        //rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    }
    protected void OnMouseExit()
    {
        //rend.material.color = Color.white;
        if (sprite != null)
        {
            spriterender.sprite = spritesave;
        }

    }
    protected virtual IEnumerator OnMouseDown()
    {
        //SoundEffectsHelper.Instance.MakeButtonSelectedSound();
        float fadeTime = fadingScene.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(_nextScene);
    }

    
}
