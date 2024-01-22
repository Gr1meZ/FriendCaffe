using AutoMapper;
using FluentAssertions;
using FriendCaffe.Application;
using FriendCaffe.Application.Configuration.AutoMapper;
using FriendCaffe.Domain;
using FriendCaffe.Infrastructure.Data;
using FriendCaffe.WebApi;
using FriendCaffe.WebApi.Configuration.AutoMapper;
using FriendCaffe.WebApi.Controllers;
using NetArchTest.Rules;

namespace FriendCaffe.UnitTests;

public class ArchitectureTests
{
    private const string DomainNamespace = "FriendCaffe.Domain";
    private const string ApplicationNamespace = "FriendCaffe.Application";
    private const string InfrastructureDataNamespace = "FriendCaffe.Infrastructure.Data";
    private const string PresentationNamespace = "FriendCaffe.WebApi";
    
    [Fact]
    public void Domain_Should_Not_HaveAnyDependencyOnOtherProjects()
    {
        //Arrange
        var assembly = typeof(DomainAssembleReference).Assembly;
        
        var otherProjects = new[]
        {
            InfrastructureDataNamespace,
            ApplicationNamespace,
            PresentationNamespace
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
        var assembly = typeof(ApplicationAssembleReference).Assembly;
        var otherProjects = new[]
        {
            InfrastructureDataNamespace,
            PresentationNamespace
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
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        //Arrange
        var assembly = typeof(PresentationAssembleReference).Assembly;
        //Act
        
        var otherProjects = new[]
        {
            DomainNamespace,
            InfrastructureDataNamespace
        };
        
        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        
        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void InfrastructureIdentity_Should_Not_HaveDependencyOnOtherProjects()
    {
        //Arrange
        var assembly = typeof(InfrastructureAssembleReference).Assembly;
        //Act
        
        var otherProjects = new[]
        {
            DomainNamespace,
            PresentationNamespace
        };
        
        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        
        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Handlers_Should_Have_DependencyOnDomain()
    {
        //Arrange
        var assembly = typeof(ApplicationAssembleReference).Assembly;
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
        var assembly = typeof(PresentationAssembleReference).Assembly;
        //Act
        
        var result = Types
            .InAssembly(assembly)
            .That()
            .Inherit(typeof(ApiController))
            .Should()
            .HaveDependencyOn("MediatR")
            .GetResult();
        
        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Controllers_Should_NotHave_DependencyOnRepositories()
    {
        //Arrange
        var assembly = typeof(PresentationAssembleReference).Assembly;
        //Act
        
        var result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Controller")
            .ShouldNot()
            .HaveDependencyOn($"{InfrastructureDataNamespace}.Repository")
            .GetResult();
        
        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Repositories_Must_DependOnDomain()
    {
        //Arrange
        var assembly = typeof(InfrastructureAssembleReference).Assembly;
        //Act
        
        var result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Repository")
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();
        
        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    
    [Fact]
    public void AutoMapper_ApplicationConfiguration_MustBe_Valid()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<ApplicationProfile>());
        config.AssertConfigurationIsValid();
    }
    
    [Fact]
    public void AutoMapper_PresentationConfiguration_MustBe_Valid()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<PresentationProfile>());
        config.AssertConfigurationIsValid();
    }
}