using System;
using System.Collections.Generic;
using System.Text;

namespace Fetch.OrderLunch.Core.Interfaces
{
    public interface IAuditEntity
    {
        DateTime CreationTime { get; set; }
        string CreatorUserId { get; set; }
        bool IsDeleted { get; set; }
        bool IsActive { get; set; }
    }
}
