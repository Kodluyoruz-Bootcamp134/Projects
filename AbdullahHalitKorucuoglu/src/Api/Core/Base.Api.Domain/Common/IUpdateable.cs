using System;

namespace Base.Api.Domain.Common;

public interface IUpdateable
{
    public DateTime? UpdatedDate { get; set; }
}