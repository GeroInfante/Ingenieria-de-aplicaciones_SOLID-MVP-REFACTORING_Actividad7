public class LastPositionState : IListPositionState
{
	public void SetVisibilityToNextAndPreviousButtomsInUI(IPresenterListOfAllUsers presenterListUI)
	{
        presenterListUI.DeactivateNextButton();
	}
}