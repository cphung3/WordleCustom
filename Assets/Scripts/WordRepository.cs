using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordRepository : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text asset with the words")]
    TextAsset m_wordList = null;
    string temp = null;

    List<string> m_words = null;
    // Start is called before the first frame update
    void Awake()
    {
        temp = m_wordList.text;
        string[] newString = m_wordList.text.Split(new[] { "\n" }, System.StringSplitOptions.None);
        Debug.Log(new List<string>(m_wordList.text.Split(new char[] { '\n' }, System.StringSplitOptions.None)));
        m_words = new List<string>(m_wordList.text.Split(new char[] {'\n'}, System.StringSplitOptions.None));
    }

    public string GetRandomWord()
    {
        return m_words[Random.Range(0, m_words.Count)];
    }

    public bool CheckWordExists(string word)
    {
        return m_words.Contains(word);
    }
}
