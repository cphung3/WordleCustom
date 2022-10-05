using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Key : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Keycode representing a key")]
    KeyCode m_keyCode = KeyCode.None;

    Image m_image = null;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
        Text text = GetComponentInChildren<Text>();
        if (text && string.IsNullOrEmpty(text.text)) 
            text.text = m_keyCode.ToString();

        m_image = GetComponent<Image>();
    }

    private void OnButtonClick()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
