using PetShop.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public interface ICommentsService
    {
        Task<int> AddComment(int id, string textToAdd);
        Task DeleteComment(int id);
        Task UpdateComment(int id);
    }
}
