using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests;

public class ArchitectureTests
{
    private const string DomainNamespace = "FriendCaffe.Domain";
    private const string ApplicationNamespace = "FriendCaffe.Application";
    private const string InfrastructureNamespace = "FriendCaffe.Infrastructure";
    private const string WebApiNamespace = "FriendCaffe.WebApi";

    [Fact]
    public void Domain_Should_Not_HaveAnyDependencyOnOtherProjects()
    {
        //Arrange
        var assembly = typeof(FriendCaffe.Domain.DomainReference).Assembly;
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            ApplicationNamespace,
            WebApiNamespace
        };
        
        //Act
        
        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        
        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Application_Should_Not_HaveAnyDependencyOnOtherProjects()
    {
        //Arrange
        var assembly = typeof(FriendCaffe.Application.ApplicationReference).Assembly;
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            WebApiNamespace
        };
        
        //Act
        
        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        
        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void WebApi_Should_Not_HaveAnyDependencyOnOtherProjects()
    {
        //Arrange
        var assembly = typeof(FriendCaffe.WebApi.WebApiReference).Assembly;
        //Act
        
        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureNamespace)
            .GetResult();
        
        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Handlers_Should_Have_DependencyOnDomain()
    {
        //Arrange
        var assembly = typeof(FriendCaffe.Application.ApplicationReference).Assembly;
        //Act
        
        var result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Handler")
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();
        
        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Controllers_Should_Have_DependencyOnMediatR()
    {
        //Arrange
        var assembly = typeof(FriendCaffe.WebApi.WebApiReference).Assembly;
        //Act
        
        var result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .HaveDependencyOn("MediatR")
            .GetResult();
        
        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
}