﻿namespace user_management.module.user.model
{
    public class CreateUserDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Company { get; set; }

        public string Department { get; set; }

        public string role { get; set; }
    }
}
