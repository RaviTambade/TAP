using ECommerceApp.Models;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services
{



    public class UserService : IUserService
    {

        private readonly IUserRepository _userrepo;
        public UserService(IUserRepository userrepo)
        {

            _userrepo = userrepo;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            return _userrepo.Authenticate(request);
        }

        public List<User> GetAll()
        {
            return _userrepo.GetAll();
        }
        public User GetUser(AuthenticateRequest request)
        {
            return _userrepo.GetUser(request);
        }

        public User GetById(int id)
        {
            return _userrepo.GetById(id);
        }

        public bool ForgotPassword(User user)
        {
            return _userrepo.ForgotPassword(user);
        }

        public bool UpdatePassword(ChangedCredential credential)
        {
            return _userrepo.UpdatePassword(credential);
        }

        public bool UpdateEmail(ChangedCredential credential)
        {
            return _userrepo.UpdateEmail(credential);
        }
    }
}