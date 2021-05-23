using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Model
{
    public enum BackerFundingPackageStatus
    {
        CREATED,    // First state On Create
        PROCESSING, // The Creator is processing the Package
        READY,      // The Creator is ready to Send the Package ??
        DELIVERY,   // The Creator Send the Package
        COMPLETED   // The Backer Receive the PAckage
    }
}
