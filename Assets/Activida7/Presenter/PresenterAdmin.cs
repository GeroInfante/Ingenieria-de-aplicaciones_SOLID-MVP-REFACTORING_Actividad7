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
    }

	public void showAllAgents()
	{
		
	}
}