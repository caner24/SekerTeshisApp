﻿using MediatR;
using SekerTeshis.Entity.DTO;
using SekerTeshisApp.Application.CQRS.Home.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Home.Requests
{
    public record CalculateSugarRequest: DiabetDetailForDto,IRequest<CalculateSugarResponse>
    {

    }
}
