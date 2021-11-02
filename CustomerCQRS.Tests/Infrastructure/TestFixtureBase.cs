using AutoMapper;
using CustomerCQRS.Core.Domain;
using CustomerCQRS.Core.Interfaces;
using CustomerCQRS.Infrastructure.Common.Mappings;
using MediatR;
using MockQueryable.Moq;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerCQRS.Tests.Infrastructure
{
    public abstract class TestFixtureBase : IDisposable
    {
        private readonly IConfigurationProvider _configuration;
       
        public readonly Mock<IApplicationDbContext> _dbContext;
        public readonly Mock<IMediator> _mediator;
        public readonly IMapper _mapper;

        public IEnumerable<Customer> Customers => new Customer[]{
            new Customer() { FirstName = "Janet", LastName = "Jackson", DateOfBirth = new DateTime(1970, 1, 1), Id = Guid.Parse("00000000-0000-0000-0000-000000000001") },
            new Customer() { FirstName = "Nicolas", LastName = "Cage", DateOfBirth = new DateTime(1961, 1, 1), Id = Guid.Parse("00000000-0000-0000-0000-000000000002")  },
            new Customer() { FirstName = "Jack", LastName = "Nicolson", DateOfBirth = new DateTime(1950, 1, 1), Id = Guid.Parse("00000000-0000-0000-0000-000000000003")  },
        };

        public TestFixtureBase()
        {
            _dbContext = new Mock<IApplicationDbContext>();
            _dbContext.Setup(x => x.Customers).ReturnsDbSet(Customers);
            _dbContext.Setup(x => x.Customers).Returns(Customers.AsQueryable().BuildMockDbSet().Object);
            
            _mediator = new Mock<IMediator>();

            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
            
        }

        public void Dispose()
        {
            
        }
    }
}
