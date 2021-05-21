namespace HoodedCrow.Quiz
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Example/Quiz/Question Sets")]
    public class SOQuizSet: ScriptableObject
    {
        [SerializeField] private List<SOQuestion> _questions = new List<SOQuestion>();

        public List<SOQuestion> GetRandomSet()
        {
            List<SOQuestion> questions = new List<SOQuestion>(_questions);
            List<SOQuestion> randomSet = new List<SOQuestion>();

            while (questions.Count != 0)
            {
                int rngIndex = Random.Range(0, questions.Count);

                randomSet.Add(questions[rngIndex]);
                questions.RemoveAt(rngIndex);
            }

            return randomSet;
        }
    }
}
