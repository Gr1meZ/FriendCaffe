using FriendCaffe.Domain.Entities.Post;
using FriendCaffe.Domain.Entities.Post.Objects.Body;
using FriendCaffe.Domain.Entities.User;
using FriendCaffe.Domain.SeedWork;
using FriendCaffe.UnitTests.Builders;
using Moq;

namespace FriendCaffe.UnitTests.Domain;

public class PostTests
{
    private readonly Mock<IPostRepository> _mockPostRepository = new();
    private readonly Mock<IUserRepository> _mockUserRepository = new();


    [Fact]
    public async Task Post_MustBe_Created()
    {
        //Arrange
        var user = await UserBuilder.CreateSpecificUser(_mockUserRepository.Object);
        var body = Body.Create("Hey, some post here");
        var utc = DateTime.UtcNow;
        //Act
        var post = Post.Create(user.Id, body, utc);

        //Assert
        Assert.Equal(utc, post.CreatedAt);
        Assert.Equal(body.Text, post.Body.Text);
    }

    [Fact]
    public void Post_Body_IsNotValid()
    {
        //Assert & Act
        Assert.Throws<DomainException>(() => Body.Create(string.Empty));
    }
}