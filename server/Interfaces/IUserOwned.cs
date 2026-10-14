using System;

namespace server.Models;

public interface IUserOwned
{
    public int Id { get; set; }

    public string UserId { get; set; }
}
