using FluentValidation;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Application.Exceptions;

public class NotFoundException<TEntity> : Exception where TEntity : Entity
{
    public NotFoundException(TEntity entity) : base($"{typeof(TEntity)} is not found")
    {
        
    }
}