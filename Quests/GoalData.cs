using UnityEngine;

namespace UnityBlocks.Idle.Quests
{
    [CreateAssetMenu(menuName = "Game/New Goal")]
    public class GoalData : ScriptableObject
    {
        [SerializeField] private string goalTitle = "reach 3";
        [SerializeField] private float count = 3;

        public string GoalTitle => goalTitle;

        public float Count => count;
    }
}