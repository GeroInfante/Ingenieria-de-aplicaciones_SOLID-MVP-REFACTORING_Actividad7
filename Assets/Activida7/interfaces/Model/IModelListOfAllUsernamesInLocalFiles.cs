using System.Collections.Generic;

public interface IModelListOfAllUsernamesInLocalFiles
{
    Agent GetFirstAgent();
    Agent GetNextAgent();
    Agent GetPreviousAgent();
    IListPositionState GetPositionState();

}