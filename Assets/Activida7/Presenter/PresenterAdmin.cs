public class PresenterAdmin : IPresenterAdmin 
{
    private IModelAdmin AdminModel;

    public PresenterAdmin()
    {
        AdminModel = new ModelAdmin();
    }
    public void GenerateNewAgents()
    {
        AdminModel.GenerateNewAgents();
        UnityEngine.Debug.Log("Termina PResenter");
    }

	public void showAllAgents()
	{
		
	}
}