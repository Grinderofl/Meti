using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetiService
{
    public enum RegisterStatus
    {
        EmptyUserName,
        EmptyEmail,
        EmptyPassword,
        UserExists,
        EmailExists,
        Success
    }

    public enum AuthenticationStatus
    {
        EmptyUserName,
        EmptyPassword,
        InvalidUserName,
        InvalidPassword,
        InvalidUserNameOrPassword,
        Success
    }
}