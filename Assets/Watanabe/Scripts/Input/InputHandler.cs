using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 日本語入力を受け付けるクラス </summary>
public class InputHandler
{
    private string _currentInput = "";
    private string _inputAlphabets = "";

    /// <summary>
    /// 入力時に何か処理を渡したい場合に使う
    /// 例：Textに反映
    /// </summary>
    private readonly Action _onInputValueChanged = default;
    #region 五十音表
    /// <summary> 母音 </summary>
    private readonly Dictionary<KeyCode, string> _vowels = new()
    {
        { KeyCode.A, "a" },
        { KeyCode.I, "i" },
        { KeyCode.U, "u" },
        { KeyCode.E, "e" },
        { KeyCode.O, "o" }
    };
    /// <summary> 子音 </summary>
    private readonly Dictionary<KeyCode, string> _consonants = new()
    {
        { KeyCode.K, "k" },
        { KeyCode.S, "s" },
        { KeyCode.T, "t" },
        { KeyCode.N, "n" },
        { KeyCode.H, "h" },
        { KeyCode.M, "m" },
        { KeyCode.Y, "y" },
        { KeyCode.R, "r" },
        { KeyCode.W, "w" },
        { KeyCode.G, "g" },
        { KeyCode.Z, "z" },
        { KeyCode.D, "d" },
        { KeyCode.B, "b" },
        { KeyCode.P, "p" },
    };

    private readonly Dictionary<KeyCode, string> _japaneseVowels = new()
    {
        { KeyCode.A, "あ" },
        { KeyCode.I, "い" },
        { KeyCode.U, "う" },
        { KeyCode.E, "え" },
        { KeyCode.O, "お" }
    };
    private readonly Dictionary<string, string> _alphabeticalTable = new()
    {
        { "ka", "か" },
        { "ki", "き" },
        { "ku", "く" },
        { "ke", "け" },
        { "ko", "こ" },
        { "ga", "が" },
        { "gi", "ぎ" },
        { "gu", "ぐ" },
        { "ge", "げ" },
        { "go", "ご" },
        { "sa", "さ" },
        { "si", "し" },
        { "shi", "し" },
        { "su", "す" },
        { "se", "せ" },
        { "so", "そ" },
        { "za", "ざ" },
        { "zi", "じ" },
        { "zu", "ず" },
        { "ze", "ぜ" },
        { "zo", "ぞ" },
        { "ta", "た" },
        { "ti", "ち" },
        { "chi", "ち" },
        { "tu", "つ" },
        { "tsu", "つ" },
        { "te", "て" },
        { "to", "と" },
        { "da", "だ" },
        { "di", "ぢ" },
        { "du", "づ" },
        { "de", "で" },
        { "do", "ど" },
        { "na", "な" },
        { "ni", "に" },
        { "nu", "ぬ" },
        { "ne", "ね" },
        { "no", "の" },
        { "ha", "は" },
        { "hi", "ひ" },
        { "hu", "ふ" },
        { "fu", "ふ" },
        { "he", "へ" },
        { "ho", "ほ" },
        { "ba", "ば" },
        { "bi", "び" },
        { "bu", "ぶ" },
        { "be", "べ" },
        { "bo", "ぼ" },
        { "pa", "ぱ" },
        { "pi", "ぴ" },
        { "pu", "ぷ" },
        { "pe", "ぺ" },
        { "po", "ぽ" },
        { "ma", "ま" },
        { "mi", "み" },
        { "mu", "む" },
        { "me", "め" },
        { "mo", "も" },
        { "ya", "や" },
        { "yu", "ゆ" },
        { "yo", "よ" },
        { "ra", "ら" },
        { "ri", "り" },
        { "ru", "る" },
        { "re", "れ" },
        { "ro", "ろ" },
        { "wa", "わ" },
        { "wo", "を" },
        { "nn", "ん" },
    };
    #endregion

    protected string CurrentInput
    {
        get => _currentInput;
        private set
        {
            _currentInput = value;
            _onInputValueChanged?.Invoke();
        }
    }

    public InputHandler(params Action[] onValueChangedActions)
    {
        CurrentInput = "";
        foreach (var action in onValueChangedActions) { _onInputValueChanged += action; }
    }

    public void OnUpdate()
    {
        foreach (var vowel in _vowels.Keys)
        {
            if (Input.GetKeyDown(vowel)) { CombinePhoneme(vowel); }
        }

        foreach (var consonant in _consonants.Keys)
        {
            if (Input.GetKeyDown(consonant)) { CombinePhoneme(consonant); }
        }
    }

    /// <summary> 入力があった音同士で日本語に変換 </summary>
    private void CombinePhoneme(KeyCode phoneme)
    {
        if (_vowels.ContainsKey(phoneme))
        {
            if (_inputAlphabets == "") { CurrentInput += _japaneseVowels[phoneme]; }
            else
            {
                int length = _inputAlphabets.Length;
                for (int i = 0; i < length; i++)
                {
                    CurrentInput = CurrentInput.Remove(CurrentInput.Length - 1);
                }
                CurrentInput += _alphabeticalTable[_inputAlphabets + _vowels[phoneme]];
                _inputAlphabets = "";
            }
        }
        else if (_consonants.ContainsKey(phoneme))
        {
            _inputAlphabets += _consonants[phoneme];
            CurrentInput += _consonants[phoneme];
            if (_inputAlphabets == "nn")
            {
                _inputAlphabets = "";
                CurrentInput = CurrentInput.Remove(CurrentInput[^1]) + _alphabeticalTable["nn"];
            }
        }
    }

    public string GetCurrentInput() => CurrentInput;

    public void ClearInput() => CurrentInput = "";

    public void RemoveInput()
    {
        if (_inputAlphabets != "") { _inputAlphabets = _inputAlphabets.Remove(_inputAlphabets.Length - 1); }
        if (CurrentInput != "") { CurrentInput = CurrentInput.Remove(CurrentInput.Length - 1);}
    }
}
