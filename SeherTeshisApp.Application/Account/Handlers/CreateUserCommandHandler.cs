using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SeherTeshisApp.Application.Account.Requests;
using SeherTeshisApp.Application.Account.Responses;
using SekerTeshis.Core.CrossCuttingConcerns.MailService;
using SekerTeshis.Entity;
using SekerTeshisApp.Application.Mail.Abstract;
using SekerTeshisApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.Account.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserDal _userDal;
        public CreateUserCommandHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var (result, token) = await _userDal.RegisterUser(request);
            return new CreateUserResponse { IsCreated = result, Token = token };
        }
    }
}
