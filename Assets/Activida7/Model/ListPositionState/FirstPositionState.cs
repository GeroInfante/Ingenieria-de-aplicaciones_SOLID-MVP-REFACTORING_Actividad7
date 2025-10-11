public class FirstPositionState : IListPositionState
{
	public void SetVisibilityToNextAndPreviousButtomsInUI(IPresenterListOfAllUsers presenterListUI)
	{
        presenterListUI.DeactivatePreviousButton();
	}
}