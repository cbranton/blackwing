using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class typewriterEffect : MonoBehaviour
{
    [SerializeField] private float typewriterSpeed;

    private readonly Dictionary<HashSet<char>,float> punctuations = new Dictionary<HashSet<char>,float>(){
        {new HashSet<char>(){'.','!','?'}, 0.6f},
        {new HashSet<char>(){',',';',':'}, 0.3f},
    };

    public Coroutine Run(string textToType, TMP_Text textLabel){
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel){

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length){
            int lastCharIndex = charIndex;

            t += Time.deltaTime * typewriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            for(int i = lastCharIndex; i<charIndex; i++){
                bool isLast = i >= textToType.Length-1;

                textLabel.text = textToType.Substring(0, i+1);

                if (IsPunctuation(textToType[i], out float waitTime)&& !isLast && !IsPunctuation(textToType[i+1], out _)){
                    yield return new WaitForSeconds(waitTime);
                }
            }

            yield return null;
        }

        textLabel.text = textToType;
    }

    private bool IsPunctuation(char character, out float waitTime){
        foreach(KeyValuePair<HashSet<char>, float> punctuationCategory in punctuations){
            if (punctuationCategory.Key.Contains(character)){
                waitTime = punctuationCategory.Value;
                return true;
            }
        }

        waitTime = default;
        return false;
    }
}
