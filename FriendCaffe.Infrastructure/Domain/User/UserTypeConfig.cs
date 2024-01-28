using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FriendCaffe.Infrastructure.Domain.User;

public class UserTypeConfig : IEntityTypeConfiguration<FriendCaffe.Domain.Entities.User.User>
{
    public void Configure(EntityTypeBuilder<FriendCaffe.Domain.Entities.User.User> builder)
    {
        builder.OwnsOne(p => p.Address);
        builder.OwnsOne(p => p.UserDetails);
        builder.OwnsOne(p => p.Email);
        builder.OwnsOne(p => p.Password);
        
    }
}