using PetShop.Data.Repositories;
using PetShop.Models.Dtos;
using PetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentsService(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<int> AddComment(int id, string textToAdd)
        {
            var newComment = new Comment { AnimalId = id, Text = textToAdd };
            return await _commentRepository.Add(newComment);
        }

        public async Task DeleteComment(int id)
        {
            await _commentRepository.Delete(id);
        }

        public Task UpdateComment(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task UpdateComment(int animalId, int commentId)
        //{
        //    var existingComment = await _commentRepository.GetById(id);
        //    if (existingComment != null)
        //    {
        //       existingComment.Text =  
        //    }

        //    await _animalRepository.Update(existingAnimal!);
        //}
    }
}
