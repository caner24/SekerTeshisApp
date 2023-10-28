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
    public class ForgottenPasswordCommandHandler : IRequestHandler<ForgottenPasswordRequest, ForgottenPasswordResponse>
    {
        private readonly IUserDal _userDal;

        public ForgottenPasswordCommandHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }
        async Task<ForgottenPasswordResponse> IRequestHandler<ForgottenPasswordRequest, ForgottenPasswordResponse>.Handle(ForgottenPasswordRequest request, CancellationToken cancellationToken)
        {
            var resetToken = await _userDal.CreatePasswordTokenAsync(request.MailAdress);

            return new ForgottenPasswordResponse { Token = resetToken, MailAdress = request.MailAdress };
        }
    }
}
