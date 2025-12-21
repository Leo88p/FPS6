using UnityEngine;
using Unity.FPS.Game;

namespace Unity.FPS.Gameplay 
{ 
    public class ObjectiveCollectCrystals : Objective
    {
        int crystalsToCollect = 3;
        int collectedTotal = 0;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected override void Start()
        {
            base.Start();
            EventManager.AddListener<CrystallCollectEvent>(OnCrystalCollected);
        }

        void OnCrystalCollected(CrystallCollectEvent evt)
        {
            if (IsCompleted)
                return;

            collectedTotal++;

            int crystalRemaining = crystalsToCollect - collectedTotal;

            // update the objective text according to how many enemies remain to kill
            if (crystalRemaining == 0)
            {
                CompleteObjective(string.Empty, GetUpdatedCounterAmount(), "Objective complete : " + Title);
            }
            else if (crystalsToCollect == 1)
            {
                string notificationText = "One crystal left";
                UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
            else
            {
                // create a notification text if needed, if it stays empty, the notification will not be created
                string notificationText = crystalRemaining + " crystals to collect left";

                UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
            }
        }

        string GetUpdatedCounterAmount()
        {
            return collectedTotal + " / " + crystalsToCollect;
        }

        void OnDestroy()
        {
            EventManager.RemoveListener<CrystallCollectEvent>(OnCrystalCollected);
        }
    }
}
