using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// Handles switching between different player input behaviors (mouse or motion).
    /// </summary>
    public class PlayerBehaviourSwitcher : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject mainScript;
        [SerializeField] private GameObject[] hands;

        [Header("UI Elements")]
        [SerializeField] private TMP_Text whichBehaviourText;
        [SerializeField] private GameObject choicePanel;
        [SerializeField] private GameObject countdownPanel;
        [SerializeField] private Countdown countdownScript;

        private IPlayerBehaviour currentBehaviour;

        private void Update()
        {
            currentBehaviour?.HandleInput();
        }

        /// <summary>
        /// Enables mouse input and disables any existing motion input.
        /// </summary>
        public void UseMouseBehaviour()
        {
            RemoveExistingBehaviours();

            currentBehaviour = mainScript.AddComponent<MousePlayerBehaviour>();
            UpdateButtonLabel();
        }

        /// <summary>
        /// Enables motion input on all hand objects and disables mouse input.
        /// </summary>
        public void UseMotionBehaviour()
        {
            RemoveExistingBehaviours();

            foreach (GameObject hand in hands)
            {
                hand.AddComponent<MotionPlayerBehaviour>();
            }

            currentBehaviour = hands[0].GetComponent<IPlayerBehaviour>(); // Assumes all hands have same behaviour
            UpdateButtonLabel();
        }

        /// <summary>
        /// Updates the on-screen label to reflect the current input type.
        /// </summary>
        private void UpdateButtonLabel()
        {
            switch (currentBehaviour)
            {
                case MousePlayerBehaviour:
                    whichBehaviourText.text = "You are using Mouse Input";
                    break;
                case MotionPlayerBehaviour:
                    whichBehaviourText.text = "You are using Motion Input";
                    break;
                default:
                    whichBehaviourText.text = "No input selected";
                    break;
            }
        }

        /// <summary>
        /// Starts the game by hiding the choice panel and enabling the countdown.
        /// </summary>
        public void StartGame()
        {
            choicePanel.SetActive(false);
            countdownPanel.SetActive(true);
            countdownScript.enabled = true;
        }

        /// <summary>
        /// Removes any existing input behaviour scripts to avoid duplicates.
        /// </summary>
        private void RemoveExistingBehaviours()
        {
            var existingMouse = mainScript.GetComponent<MousePlayerBehaviour>();
            if (existingMouse != null) Destroy(existingMouse);

            foreach (GameObject hand in hands)
            {
                var existingMotion = hand.GetComponent<MotionPlayerBehaviour>();
                if (existingMotion != null) Destroy(existingMotion);
            }
        }
    }
}
