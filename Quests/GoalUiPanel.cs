using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UnityBlocks.Idle.Quests
{
    public class GoalUiPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI counter;
        [SerializeField] private Slider slider;
        private RectTransform _rectTransform;
        private Vector3 _initialPosition;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _initialPosition = _rectTransform.anchoredPosition;

            HideFast();
        }

        public void SetTitle(string text)
        {
            title.SetText(text);
        }

        public void SetCounter(float current, float max)
        {
            slider.maxValue = max;
            var curr = Mathf.Clamp(current, 0, max);
            if (Math.Abs(slider.value - curr) > 0.1f)
            {
                slider.DOValue(curr, 0.35f)
                    .SetEase(Ease.OutBack)
                    .SetLink(gameObject);
            }

            counter.SetText(curr + "/" + max);
        }

        [Button]
        public TweenerCore<Vector2, Vector2, VectorOptions> Show()
        {
            DOTween.Kill(_rectTransform);
            return _rectTransform.DOAnchorPos(_initialPosition, 0.75f)
                .SetEase(Ease.InOutBack)
                .SetLink(gameObject);
        }

        [Button]
        public TweenerCore<Vector2, Vector2, VectorOptions> Hide()
        {
            DOTween.Kill(_rectTransform);

            var tempPos = _rectTransform.anchoredPosition;
            tempPos.y += 600;
            _rectTransform.anchoredPosition = tempPos;

            return _rectTransform.DOAnchorPos(tempPos, 0.75f)
                .SetEase(Ease.InOutBack)
                .SetLink(gameObject);
        }

        public void HideFast()
        {
            var tempPos = _rectTransform.anchoredPosition;
            tempPos.y += 600;
            _rectTransform.anchoredPosition = tempPos;
        }


        [Button]
        private void RandomTest()
        {
            var max = 6;
            SetCounter(Random.Range(0, max), max);
        }
    }
}