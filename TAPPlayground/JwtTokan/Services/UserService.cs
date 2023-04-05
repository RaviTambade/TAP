using ECommerceApp.Models;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services{



    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo){

         _userRepo =userRepo;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
              return _userRepo.Authenticate(request);
        }

        public List<User> GetAll()
        {
              return _userRepo.GetAll();
        }
        public User GetUser(AuthenticateRequest request)
        {
             return _userRepo.GetUser(request);
        }

           public User GetById(int id)
        {
             return _userRepo.GetById(id);
        }


    }
}