namespace HoodedCrow.Quiz
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Example/Quiz/Question")]
    public class SOQuestion: ScriptableObject
    {
        public string Question => _question;
        public bool IsCorrect => _isCorrect;
        public Sprite Sprite => _sprite;

        [SerializeField] private string _question;
        [SerializeField] private bool _isCorrect;
        [SerializeField] private Sprite _sprite;
    }
}
