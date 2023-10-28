using MediatR;
using SekerTeshisApp.Application.Account.Requests;
using SekerTeshisApp.Application.Account.Responses;
using SekerTeshisApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.Account.Handlers
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordRequest, ResetPasswordResponse>
    {
        private readonly IUserDal _userDal;
        public ResetPasswordCommandHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<ResetPasswordResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var resetPassword = await _userDal.ResetPasswordAsync(request.Mail, request.Token, request.Password);

            return new ResetPasswordResponse { Result = resetPassword };
        }
    }
}
