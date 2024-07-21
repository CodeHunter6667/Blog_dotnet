﻿using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories;

public class UserRepository
{
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<User> Get()
        => _connection.GetAll<User>();

    public User GetById(int id)
        => _connection.Get<User>(id);
    
    public void Insert(User user)
        => _connection.Insert(user);
}
