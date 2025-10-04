using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModelLogin
{
    ILoginState authenticateLogin(string username, string password);
}
