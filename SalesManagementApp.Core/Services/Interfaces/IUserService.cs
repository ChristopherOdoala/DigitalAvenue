using SalesManagementApp.Core.Models;
using SalesManagementApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesManagementApp.Core.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
        List<ValidationResult> ChangePassword(UserViewModel model, string newPassword);
    }
}
