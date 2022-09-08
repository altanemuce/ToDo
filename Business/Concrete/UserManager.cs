using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<User> Login(User user)
        {
            var result = _userDal.Get(x => x.UserName == user.UserName && x.UserPassword == user.UserPassword);
            if (result == null)
            {
                return new ErrorDataResult<User>();
            }
            return new SuccessDataResult<User>();
        }
    }
}
