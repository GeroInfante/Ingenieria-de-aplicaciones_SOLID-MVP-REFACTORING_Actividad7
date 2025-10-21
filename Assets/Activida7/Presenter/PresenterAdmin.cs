public class PresenterAdmin : IPresenterAdmin 
{
    private IModelAdmin AdminModel;
    private IUIAdmin UIAdmin;

    public PresenterAdmin(IUIAdmin uiAdmin)
    {
        AdminModel = new ModelAdmin();
        UIAdmin = uiAdmin;
    }
    public void GenerateNewAgents()
    {
        AdminModel.GenerateNewAgents();
    }

	public void showAllAgents()
	{
		UIAdmin.TellToListTOShowFirstUser();
	}
}