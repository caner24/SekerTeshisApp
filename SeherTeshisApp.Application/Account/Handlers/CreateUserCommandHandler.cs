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
        private readonly IMapper _mapper;
        private readonly IMailSender _mailSender;
        public CreateUserCommandHandler(IUserDal userDal, IMapper mapper, IMailSender mailSender)
        {
            _userDal = userDal;
            _mapper = mapper;
            _mailSender = mailSender;
        }
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            string token = "";
            var user = _mapper.Map<User>(request);
            var result = await _userDal.RegisterUser(request);

            if (result.Succeeded)
            {
                token = await _userDal.GenerateEmailConfirmationTokenAsync();
            }

            return new CreateUserResponse { IsCreated = result, Token = token };
        }
    }
}
