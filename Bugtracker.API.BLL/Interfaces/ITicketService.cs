﻿using Bugtracker.API.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Interfaces
{
    public interface ITicketService : IService<int, TicketDto>
    {
        bool Edit(TicketDto dto);
    }
}