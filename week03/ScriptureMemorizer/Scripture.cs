using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        for (int i = 0; i < numberToHide; i++)
        {
            List<Word> visibleWords = new List<Word>();

            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    visibleWords.Add(word);
                }
            }

            if (visibleWords.Count == 0)
            {
                break;
            }

            int index = _random.Next(visibleWords.Count);

            visibleWords[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText() + "\n";

        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }

        return text.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public int GetHiddenWordCount()
    {
        int hiddenCount = 0;

        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                hiddenCount++;
            }
        }

        return hiddenCount;
    }

    public int GetTotalWordCount()
    {
        return _words.Count;
    }

    public int GetProgressPercentage()
    {
        if (_words.Count == 0)
        {
            return 100;
        }

        return GetHiddenWordCount() * 100 / _words.Count;
    }
}