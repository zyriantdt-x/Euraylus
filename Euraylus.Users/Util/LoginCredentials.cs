﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euraylus.Users.Util;
public struct LoginCredentials : ILoginCredentials {
    public required string Username { get; init; }
    public required string Password { get; init; }
}
