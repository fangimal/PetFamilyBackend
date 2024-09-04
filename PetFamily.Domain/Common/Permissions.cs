namespace PetFamily.Domain.Common;

public static class Permissions
{
    public static class Volunteers
    {
        public const string Read = "volunteers.read";
        public const string Create = "volunteers.create";
        public const string Update = "volunteers.update";
        public const string Delete = "volunteers.delete";
    }

    public static class Pets
    {
        public const string Read = "pets.read";
        public const string Create = "pets.create";
        public const string Update = "pets.update";
        public const string Delete = "pets.delete";
    }

    public static class VolunteerApplications
    {
        public const string Read = "volunteer.applications.read";
        public const string Create = "volunteer.applications.create";
        public const string Update = "volunteer.applacations.update";
        public const string Delete = "volunteers.applications.delete";
    }
}