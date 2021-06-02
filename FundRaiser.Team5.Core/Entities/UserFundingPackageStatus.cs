using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Model
{
    public enum UserFundingPackageStatus
    {
        CREATED = 0,    // First state On Create
        PROCESSING = 1, // The Creator is processing the Package
        READY = 2,      // The Creator is ready to Send the Package ??
        DELIVERY = 3,   // The Creator Send the Package
        COMPLETED = 4   // The Backer Receive the PAckage
    }
}
