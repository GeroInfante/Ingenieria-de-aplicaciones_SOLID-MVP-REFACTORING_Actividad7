public class IntermediatePositionState : IListPositionState
{
    public void SetVisibilityToNextAndPreviousButtomsInUI(IPresenterListOfAllUsers presenterListUI)
    {
        presenterListUI.ActivatePreviousButton();
        presenterListUI.ActivateNextButton();
	}
}