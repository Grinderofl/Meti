using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;
using MetiDomain;
using MetiDomain.Entities;
using MetiShared;

namespace MetiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthService" in code, svc and config file together.
    [WebService(Namespace = "MetiApplication")]
    [ServiceBehavior(Namespace = "MetiApplication")]
    public class AuthService : IAuthService
    {
        private DbContext _context;

        public AuthService()
        {
            _context = new DataContext();
        }

        public Guid GetSession(User user)
        {
            var status = Authenticate(user);
            if (status != AuthenticationStatus.Success)
                return Guid.Empty;
            var found =
                _context.Set<User>().FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            Debug.Assert(found != null, "found != null");
            var session = new Session() { UserId = found.Id };
            _context.Set<Session>().Add(session);
            _context.SaveChanges();
            return session.UUID;
        }

        public AuthenticationStatus Authenticate(User user)
        {
            if(user.Name.IsNullOrWhiteSpace())
                return AuthenticationStatus.EmptyUserName;
            if(user.Password.IsNullOrWhiteSpace())
                return AuthenticationStatus.EmptyPassword;
            
            user.Password = Hash.GetHash(user.Password, Hash.HashType.SHA512);
            var found =
                _context.Set<User>().FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            if (found != null)
            {
                
                return AuthenticationStatus.Success;
            }
            return AuthenticationStatus.InvalidUserNameOrPassword;
        }

        public RegisterStatus Register(User user)
        {
            if(user.Name.IsNullOrWhiteSpace())
                return RegisterStatus.EmptyUserName;
            if(user.Password.IsNullOrWhiteSpace())
                return RegisterStatus.EmptyPassword;
            if(user.Email.IsNullOrWhiteSpace())
                return RegisterStatus.EmptyEmail;
            if(_context.Set<User>().FirstOrDefault(x => x.Name == user.Name) != null)
                return RegisterStatus.UserExists;
            if(_context.Set<User>().FirstOrDefault(x => x.Email == user.Email) != null)
                return RegisterStatus.EmailExists;

            user.Password = Hash.GetHash(user.Password, Hash.HashType.SHA512);
            _context.Set<User>().Add(user);
            _context.SaveChanges();
            return RegisterStatus.Success;
        }

    }
}
