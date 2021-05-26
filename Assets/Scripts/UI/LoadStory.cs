using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Story {
    public class LoadStory : MonoBehaviour {

        [SerializeField] List<Sprite> sprites;
        [SerializeField] TextMeshProUGUI storyText;
        [SerializeField] TextMeshProUGUI buttonText;
        [SerializeField] List<string> text;
        [SerializeField] GameObject frame;
        private int current = 1;
        private int width;

        void Start() {
            width = Screen.width / sprites.Count;
            storyText.text = text[0];
            CreateFrame();
        }

        public void NextFrame() {
            if (current < text.Count) {
                current++;
                storyText.text = text[current - 1];
                if(current <= sprites.Count)
                    CreateFrame();
                if(current == text.Count) {
                    buttonText.text = "< Continue >";
                }
            } else {
                SceneManager.LoadScene("HowTo");
            }
        }

        private void CreateFrame() {
            GameObject pic = Instantiate(frame);
            pic.transform.SetParent(gameObject.transform);
            pic.transform.position = new Vector2(Screen.width / (sprites.Count + 1) * current, (8 / 6 + 4) * Screen.height / 8);
            pic.GetComponent<Picture>().frame.rectTransform.sizeDelta = new Vector2(width, width + 30);
            pic.GetComponent<Picture>().image.rectTransform.sizeDelta = new Vector2(width - 20, width - 20);
            pic.GetComponent<Picture>().image.sprite = sprites[current - 1];
        }
    }
}