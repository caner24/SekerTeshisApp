using AutoMapper;
using MediatR;
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
    public class LoginUserCommandHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserDal _userDal;

        public LoginUserCommandHandler(IMapper mapper, IUserDal userDal)
        {
            _mapper = mapper;
            _userDal = userDal;
        }
        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var tryLoggedIn = await _userDal.ValidateUser(request);
            if (!tryLoggedIn)
                return new LoginUserResponse { IsLoggedIn = false };

            var tokenDto = await _userDal
               .CreateToken(populateExp: true);

            var tokenMap = _mapper.Map<LoginUserResponse>(tokenDto);
            tokenMap.IsLoggedIn = true;
            tokenMap.UserId = _userDal.GetUserId();
            return tokenMap;

        }
    }
}
