﻿using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Business.Concreate
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetCurrentUser(IIdentity getidentity)
        {
            string userid = null;
            if (getidentity is ClaimsIdentity identity)
            {
                if(identity.IsAuthenticated == false)
                {
                    return new ErrorDataResult<User>("Giriş yapılmamış");
                }
                try 
                { userid = identity.FindFirst(ClaimTypes.NameIdentifier).Value; } 
                catch { userid = null; };
            }
            User currentUser = null;
            if (userid != null)
            {
                currentUser = _userDal.Get(p => p.Id == Convert.ToInt32(userid));
            }
           
            if (userid == null)
            {
                return new ErrorDataResult<User>("Giriş yapılmamış");
            }
            return new SuccessDataResult<User>(currentUser);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
