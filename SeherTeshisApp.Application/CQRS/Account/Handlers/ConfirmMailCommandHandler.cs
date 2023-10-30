using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SekerTeshisApp.Application.CQRS.Account.Requests;
using SekerTeshisApp.Application.CQRS.Account.Responses;
using SekerTeshisApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Account.Handlers
{
    public class ConfirmMailCommandHandler : IRequestHandler<ConfirmMailRequest, ConfirmMailResponse>
    {

        private readonly IUserDal _userDal;
        public ConfirmMailCommandHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<ConfirmMailResponse> Handle(ConfirmMailRequest request, CancellationToken cancellationToken)
        {
            var validateResult = await _userDal.ConfirmMailAsync(request.Mail, request.Token);

            return new ConfirmMailResponse() { Result = validateResult };
        }
    }
}
