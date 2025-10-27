using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ');
        foreach (var part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        List<Word> visibleWords = _words.FindAll(w => !w.IsHidden());

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(_words.Count);
            _words[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) return false;

        }
        return true;
    }

    public string GetDisplayText()
    {
        string display = _reference.ToString() + " - ";
        foreach (Word word in _words)
        {
            display += word.ToString() + " ";
        }
        return display.Trim();
    }
}