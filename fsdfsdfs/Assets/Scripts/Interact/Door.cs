using UnityEngine;

public class Door : Interactable
{
        [SerializeField] private string sceneTransitionName;
        [SerializeField] private Vector3 transitionPosition;

        protected override void Start()
        {
                base.Start();
                if (!needItem)
                        ChangeState();
        }

        protected override void DoAction()
        {
                GameManager.Instance.SetPlayerPosition(transitionPosition);
                GameManager.Instance.ChangeScene(sceneTransitionName);
        }
}
