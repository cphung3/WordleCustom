using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Key : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Keycode representing a key")]
    KeyCode m_keyCode = KeyCode.None;

    [Serializable]
    public struct LetterStateColor
    {
        public Color Color;
        public LetterState LetterState;
    }

    [SerializeField]
    [Tooltip("Color per state")]
    LetterStateColor[] m_letterStateColors = null;
    List<LetterStateColor> m_letterStateColorsList = null;

    Image m_image = null;

    Color m_startingColor = Color.grey;

    public Action<KeyCode> Pressed;

    public KeyCode KeyCode { get { return m_keyCode; } }
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
        if (text && string.IsNullOrEmpty(text.text)) 
            text.text = m_keyCode.ToString();

        //m_letterStateColorsList = new List<LetterStateColor>();
        //LetterStateColor correctColor = new LetterStateColor();
        //correctColor.LetterState = LetterState.Correct;
        //correctColor.Color = new Color(0f, 214/255f, 14/255f);
        //m_letterStateColorsList.Add(correctColor);        
        
        //LetterStateColor incorrectColor = new LetterStateColor();
        //correctColor.LetterState = LetterState.Incorrect;
        //correctColor.Color = new Color(142/255f, 142/255f, 142/255f);
        //m_letterStateColorsList.Add(incorrectColor);

        //LetterStateColor wrongLocColor = new LetterStateColor();
        //correctColor.LetterState = LetterState.WrongLocation;
        //correctColor.Color = new Color(216/255f, 221/255f, 66/255f);
        //m_letterStateColorsList.Add(wrongLocColor);

        m_image = GetComponent<Image>();
        m_startingColor = m_image.color;
    }

    private void OnButtonClick()
    {
        Pressed?.Invoke(m_keyCode);
    }

    public void SetState(LetterState letterState)
    {
        foreach(LetterStateColor letterStateColor in m_letterStateColors)
        {
            if (letterStateColor.LetterState == letterState)
            {
                // m_image.color = letterStateColor.Color;
                m_image.color = letterStateColor.Color;
                break;
            }
        }
    }

    public void ResetState()
    {
        m_image.color = m_startingColor;
    }
}
