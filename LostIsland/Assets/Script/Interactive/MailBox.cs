using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : Interactive
{
    private SpriteRenderer spriteRenderer;

    private BoxCollider2D c2d;

    public Sprite open;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        c2d = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        EventHandle.AfterSceneloaded += OnAfterSceneloaded;
    }

    private void OnDisable()
    {
        EventHandle.AfterSceneloaded -= OnAfterSceneloaded;
    }

     private void OnAfterSceneloaded()
    {
       if(!isDone){
        transform.GetChild(0).gameObject.SetActive(false);
       }
       else
       {
          spriteRenderer.sprite = open;
          c2d.enabled=false;
       }
    }

    protected override void OnClickedAction()
    {
        spriteRenderer.sprite = open;
         transform.GetChild(0).gameObject.SetActive(true);
    }
}
