namespace Yuki.Common.Database;

public interface IBaseEntity
{
    public int Id { get; set; }

    public DateTime? LastModified { get; set; }
}