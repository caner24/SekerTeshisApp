using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SeherTeshisApp.Application.Account.Requests;
using SeherTeshisApp.Application.Account.Responses;
using SekerTeshis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.Account.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var result = await _userManager.CreateAsync(user, request.Password);
            return new CreateUserResponse { IsCreated = result };
        }
    }
}
