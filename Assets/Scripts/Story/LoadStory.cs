﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Story {
    public class LoadStory : MonoBehaviour {

        [SerializeField] List<Sprite> sprites;
        [SerializeField] GameObject frame;
        private int current = 1;
        private int width;

        void Start() {
            width = Screen.width / 3;
            CreateFrame();
        }

        public void NextFrame() {
            if (current < sprites.Count) {
                current++;
                CreateFrame();
            } else {
                // Load game
            }
        }

        private void CreateFrame() {
            GameObject pic = Instantiate(frame);
            pic.transform.SetParent(gameObject.transform);
            Debug.Log(Screen.height / 2);
            Debug.Log(Screen.height / 3); 
            pic.transform.position = new Vector2(Screen.width / 4 * current, (8 / 6 + 4) * Screen.height / 8);
            pic.GetComponent<Picture>().frame.rectTransform.sizeDelta = new Vector2(width, width + 30);
            pic.GetComponent<Picture>().image.rectTransform.sizeDelta = new Vector2(width - 20, width - 20);
            pic.GetComponent<Picture>().image.sprite = sprites[current - 1];
        }
    }
}