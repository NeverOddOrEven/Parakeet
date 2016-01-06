namespace Parakeet.Ui.Mapper
{
    public static class RoleeMapper
    {
        public static Data.Entities.Role ToEntity(this Model.Role role)
        {
            return new Data.Entities.Role
            {
                Id = role.Id,
                Description = role.Description,
                Name = role.Name
            };
        }
    }
}
