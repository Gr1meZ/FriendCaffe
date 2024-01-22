
using FriendCaffe.Domain.Entities.User.Objects;
using FriendCaffe.Domain.Entities.User.Objects.Address;
using FriendCaffe.Domain.Entities.User.Objects.UserDetails;
using FriendCaffe.Domain.SeedWork;
using Microsoft.AspNetCore.Identity;

namespace FriendCaffe.Domain.Entities.User;

public class User : Entity
{
   private User(Address address, UserDetails? userDetails)
   {
      Address = address;
      UserDetails = userDetails;
   }
   
   protected User(UserDetails? userDetails)
   {
      UserDetails = userDetails;
   }
   
   public Address? Address { get; private set; }
   public UserDetails? UserDetails { get; private set; }
}